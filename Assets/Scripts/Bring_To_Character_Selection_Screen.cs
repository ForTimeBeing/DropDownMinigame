using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bring_To_Character_Selection_Screen : MonoBehaviour {

	public Button yourButton;

	void Start () {
		//Button btn = yourButton.GetComponent<Button>();
		yourButton.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
	}
}
