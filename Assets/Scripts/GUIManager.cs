using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour {

	public Button createButton;

	public InputField lobbyTextBoxField;

	public GameObject lobbyGameObject;

	public GameObject scrollViewParent;

	public ScrollRect myScrollBar;


	int amountOfLobbies = 0;
	//On load check to see how many lobby's there are and populate them. Store the amount
	void Start () {
		//Button btn = yourButton.GetComponent<Button>();
		createButton.onClick.AddListener(TaskOnClick);
		lobbyTextBoxField.characterLimit = 20;
		lobbyTextBoxField.lineType = InputField.LineType.SingleLine;
		lobbyTextBoxField.contentType = InputField.ContentType.Alphanumeric;
	}
	
	void TaskOnClick(){
		if (string.IsNullOrEmpty(lobbyTextBoxField.text)){
			//Display pop up saying textbox cannot be empty
			Debug.Log("Inputbox is empty");
		}
		else{
			// Use server amount to append new lobbies
			// Instantiate at position (0, 0) and zero rotation.
			//lobbyGameObject = new GameObject();
			//lobbyGameObject.AddComponent<Text>();
			Text lobbyText = lobbyGameObject.GetComponent<Text>(); 
			lobbyText.text = lobbyTextBoxField.text;
        	GameObject newLobbyGameObject = Instantiate(lobbyGameObject, new Vector2(0, 0), Quaternion.identity);
			newLobbyGameObject.transform.SetParent (scrollViewParent.gameObject.transform);
			newLobbyGameObject.transform.localPosition = new Vector2(0,amountOfLobbies * 20);
			amountOfLobbies = amountOfLobbies + 1;
			Debug.Log("we good fam");
		}
		//SceneManager.LoadScene("Character_Selection");
	}
}
