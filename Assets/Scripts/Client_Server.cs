using UnityEngine.Networking;
using UnityEngine;

public class Client_Server : MonoBehaviour {
	

	private const int MAX_USER = 10;
	private const int PORT = 26000;
	private const int WEB_PORT = 26001;
	private const string SERVER_IP = "127.0.0.1";

	private byte reliableChannel;
	private int hostID;
	private byte error;

	private bool isStarted = false;

	private void Start(){
		DontDestroyOnLoad(gameObject);
		Init();
	}
	public void Init(){
		NetworkTransport.Init();
		ConnectionConfig cc = new ConnectionConfig();
		cc.AddChannel(QosType.Reliable);

		HostTopology topo = new HostTopology(cc, MAX_USER);

		//Client only code
		hostID = NetworkTransport.AddHost(topo,0);
#if UNITY_WEBGL && !UNITY_EDITOR
		//Web Client
		NetworkTransport.Connect(hostID,SERVER_IP,PORT,0, out error);
		Debug.Log(string.Format("Connecting from web"));
#else
		//Standalone Client
		NetworkTransport.Connect(hostID,SERVER_IP,PORT,0, out error);
		Debug.Log(string.Format("Connecting from standalone"));
#endif
		Debug.Log(string.Format("Attempting to connect on {0}...", SERVER_IP));
		isStarted = true;
	}
	public void Shutdown(){
		isStarted = false;
		NetworkTransport.Shutdown();
	}
}
