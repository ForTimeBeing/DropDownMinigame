using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bring_To_Character_Selection_Screen : MonoBehaviour {

	public Button yourButton;

	void Start () {
		//Button btn = yourButton.GetComponent<Button>();
		yourButton.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		SceneManager.LoadScene("Character_Selection");
	}
}
