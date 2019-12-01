using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{

    public Button createButton;

    public InputField lobbyTextBoxField;

    public GameObject contentPrefab;

    public GameObject contentParent;

    public GameObject backgroundPrefab;

    int amountOfLobbies = 0;
    //On load check to see how many lobby's there are and populate them. Store the amount
    void Start()
    {
        //Button btn = yourButton.GetComponent<Button>();
        createButton.onClick.AddListener(CreateLobby);
        lobbyTextBoxField.characterLimit = 20;
        lobbyTextBoxField.lineType = InputField.LineType.SingleLine;
        lobbyTextBoxField.contentType = InputField.ContentType.Alphanumeric;
    }
    void CreateLobby()
    {
        if (string.IsNullOrEmpty(lobbyTextBoxField.text))
        {
            //Display pop up saying textbox cannot be empty
            Debug.Log("Inputbox is empty");
        }
        else
        {
            // Use server amount to append new lobbies store new lobbies on server
            Text lobbyText = contentPrefab.GetComponent<Text>();
            lobbyText.text = lobbyTextBoxField.text;
            GameObject newLobbyGameObject = Instantiate(contentPrefab, new Vector2(0, 0), Quaternion.identity, contentParent.gameObject.transform);
            newLobbyGameObject.gameObject.transform.localPosition = new Vector2(0, amountOfLobbies * 20);
            newLobbyGameObject.AddComponent<CreatesBackground>();
            BoxCollider2D myBoxCollider = newLobbyGameObject.AddComponent<BoxCollider2D>();
            myBoxCollider.offset = new Vector2(-1.52f, -1.05f);
            myBoxCollider.size = new Vector2(503, 21);



            amountOfLobbies = amountOfLobbies - 1;
            Debug.Log("we good fam");
        }

    }
    //SceneManager.LoadScene("Character_Selection");
}
