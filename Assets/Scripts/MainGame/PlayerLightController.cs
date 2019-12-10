using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine;
using System.Collections;


public class PlayerLightController : MonoBehaviour
{
    public static string playerlightcolor = "#ffffff";
    public static bool flashred = false;
    public static bool changelightcolor = false;
    public static bool hasspecial = false;

    public UnityEngine.Experimental.Rendering.LWRP.Light2D m_Light2D;

    Color playerlight = Color.white;
    Color currentcolor = Color.white;
    float duration = 1f;
    float redDuration = .3f;

    Light2D mylight;
    // Start is called before the first frame update
    void Start()
    {
        mylight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //changes light color
        if (changelightcolor == true)
        {
            ColorUtility.TryParseHtmlString(playerlightcolor, out playerlight);
            mylight.color = Color.Lerp(currentcolor, playerlight, 1);
            currentcolor = playerlight;
            changelightcolor = false;
        }
        //flashes red
        if (flashred == true)
        {
            StartCoroutine(FlashRed());
            flashred = false;
        }
        if (hasspecial == false && currentcolor != Color.white)
        {
            mylight.color = Color.Lerp(currentcolor, Color.white, 1);
            currentcolor = Color.white;
        }
        //Pulses red
        if (m_Light2D.pointLightOuterRadius < 16)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            mylight.color = Color.Lerp(currentcolor, Color.red, t);
            mylight.color = Color.Lerp(Color.red, currentcolor, t);
        }
        //Gameover
        if (m_Light2D.pointLightOuterRadius < 10){
            m_Light2D.pointLightOuterRadius = 0;
            GameOver.gameover = true;
        }
    }
    IEnumerator FlashRed()
    {
        mylight.color = Color.Lerp(currentcolor, Color.red, 1);
        yield return new WaitForSeconds(.3f);
        mylight.color = Color.Lerp(Color.red, currentcolor, 1);
    }
}
