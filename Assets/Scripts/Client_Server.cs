using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.Networking;
using UnityEngine;

public class Client_Server : MonoBehaviour
{
    public static Client_Server Instance { private set; get; }

    private const int MAX_USER = 10;
    private const int PORT = 26000;
    private const int WEB_PORT = 26001;
    private const string SERVER_IP = "127.0.0.1";
    private const int BYTE_SIZE = 1024;

    private byte reliableChannel;
    private int ConnectionID;
    private int hostID;
    private byte error;

    private bool isStarted = false;

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Init();
    }
    private void Update()
    {
        UpdateMessagePump();
    }
    public void Init()
    {
        NetworkTransport.Init();
        ConnectionConfig cc = new ConnectionConfig();
        cc.AddChannel(QosType.Reliable);

        HostTopology topo = new HostTopology(cc, MAX_USER);

        //Client only code
        hostID = NetworkTransport.AddHost(topo, 0);
#if UNITY_WEBGL && !UNITY_EDITOR
		//Web Client
		ConnectionID = NetworkTransport.Connect(hostID,SERVER_IP,PORT,0, out error);
		Debug.Log(string.Format("Connecting from web"));
#else
        //Standalone Client
        ConnectionID = NetworkTransport.Connect(hostID, SERVER_IP, PORT, 0, out error);
        Debug.Log(string.Format("Connecting from standalone"));
#endif
        Debug.Log(string.Format("Attempting to connect on {0}...", SERVER_IP));
        isStarted = true;
    }
    public void UpdateMessagePump()
    {
        if (!isStarted)
            return;

        int recHostID;      //Is this from Web? Or standalone
        int connectionID;   //Which user is sending my this?
        int channelID;      //Which lane is he senting that message from

        byte[] recBuffer = new byte[BYTE_SIZE];
        int dataSize;

        NetworkEventType type = NetworkTransport.Receive(out recHostID, out connectionID, out channelID, recBuffer, BYTE_SIZE, out dataSize, out error);
        switch (type)
        {

            case NetworkEventType.Nothing:
                break;

            case NetworkEventType.ConnectEvent:
                Debug.Log("We have connected to the server");
                break;

            case NetworkEventType.DisconnectEvent:
                Debug.Log("We have been disconnected");
                break;

            case NetworkEventType.DataEvent:
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream ms = new MemoryStream(recBuffer);
                NetMsg msg = (NetMsg)formatter.Deserialize(ms);

                OnData(connectionID, channelID, recHostID, msg);
                break;

            default:
            case NetworkEventType.BroadcastEvent:
                Debug.Log("Unexpected network event type");
                break;

        }
    }
    public void Shutdown()
    {
        isStarted = false;
        NetworkTransport.Shutdown();
    }

    #region Send
    public void SendServer(NetMsg msg)
    {
        //This is where we hold out data
        byte[] buffer = new byte[BYTE_SIZE];

        //this is where you crush your data into a byte[]
        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream ms = new MemoryStream(buffer);
        formatter.Serialize(ms, msg);

        NetworkTransport.Send(hostID, ConnectionID, reliableChannel, buffer, BYTE_SIZE, out error);
    }
    #endregion

    #region OnData
    public void OnData(int connectionID, int channelID, int recHostID, NetMsg msg)
    {
        switch (msg.OP)
        {
            case NetOP.None:
                break;
        }
        #endregion
    }
    //CLICKING BUTTON SENDS TO CLIENT, PLACING IT IN SCOREBOARDMANAGER CLASS AND CALLING IT DOES NOT ALTHOUGH PRINTS TO CLIENT
    public void SendScore(int score)
    {
        Net_SendScore net_score = new Net_SendScore();
        net_score.score = score;
        print(score);
        SendServer(net_score);
    }
}
