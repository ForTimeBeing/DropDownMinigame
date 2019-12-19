using UnityEngine;
using UnityEngine.UI;

public class ScoreboardManager : MonoBehaviour
{
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
        Client_Server.Instance.SendScore(score);
    }
}
