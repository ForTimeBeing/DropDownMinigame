using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn_DIP : MonoBehaviour {
	public GameObject prefab;
	float timeLeft = 1f;
	
	// Update is called once per frame
	void Update () {
		float randomSpawnTime = (Random.Range(.2f,.6f));
		 timeLeft -= Time.deltaTime;
         if(timeLeft < 0)
         {
             Invoke("Spawn", 0f);
			 timeLeft = randomSpawnTime;
		 }
	}
	void Spawn(){
		float randomNumber = Random.Range(-4.5f,5f);
		GameObject dip = Instantiate(prefab);
		Destroy(dip , 6);
		dip.transform.position = new Vector2(randomNumber,6);
	}


}
