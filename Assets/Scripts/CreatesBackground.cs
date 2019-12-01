using UnityEngine;

public class CreatesBackground : MonoBehaviour {

	void OnMouseDown()
    {
		Debug.Log("2");
    string name = "selection_background(Clone)";
    GameObject go = GameObject.Find(name);
        //if the object exist then destroy it
    if (go)
    {
      Destroy(go.gameObject);
       Debug.Log(name + "has been destroyed.");
    }
    GameObject newLobbyGameObject = (GameObject)Instantiate(Resources.Load("selection_background", typeof (GameObject))) as GameObject;
    newLobbyGameObject.transform.SetParent(gameObject.transform);
    newLobbyGameObject.gameObject.transform.localPosition = new Vector2(-10,0);
    }
}
