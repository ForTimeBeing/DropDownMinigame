using UnityEngine;
using UnityEngine.UI;

public class ScoreboardManager : MonoBehaviour
{
    Client_Server client = new Client_Server();

    public int score = 0;

    public static ScoreboardManager Instance;

    Text myTextObject;

    void Awake()
    {
        Instance = this;
        myTextObject = gameObject.GetComponent<Text>();
    }
    public void addScore()
    {
        score += 1;
        myTextObject.text = score.ToString();

        client.SendScore();
    }
}
