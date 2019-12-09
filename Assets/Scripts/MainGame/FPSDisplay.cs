using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{

    public int avgFrameRate;
	
    public Text display_Text;

	bool isInvokRunning = false;

    public void Update()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
		if (isInvokRunning == false){
			isInvokRunning = true;
			InvokeRepeating("DisplayText", 0.5f, 0f);
		}
		
    }
	void DisplayText()
    {
		display_Text.text = avgFrameRate.ToString() + " FPS";
		isInvokRunning = false;
	}
}
