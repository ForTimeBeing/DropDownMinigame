using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenResolution : MonoBehaviour {

	public bool maintainWidth = true;
	public bool maintainHeight = true;

	float defaultWidth;
	float defaultHeight;

	Vector3 CameraPos;
	// Use this for initialization
	void Start () {
		CameraPos = Camera.main.transform.position;

		defaultHeight = Camera.main.orthographicSize* Camera.main.aspect;
		defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
	}
	
	// Update is called once per frame
	void Update () {
		if (maintainWidth)
		{
			Camera.main.orthographicSize = defaultWidth/Camera.main.aspect;

			Camera.main.orthographicSize = defaultHeight/Camera.main.aspect;
		}
		else{

		}
	}
}
