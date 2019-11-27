using UnityEngine;

public class CreatesBackground : MonoBehaviour {

	public GameObject backgroundPrefab;

	void OnMouseDown()
    {
		Debug.Log("SDSD");
      GameObject newLobbyGameObject = Instantiate(backgroundPrefab, new Vector2(0, 0), Quaternion.identity, gameObject.transform);
    }
}
