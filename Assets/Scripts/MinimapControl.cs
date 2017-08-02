using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	
	//kvar att skapa: public variabler för camSize minimum och maximum

public class MinimapControl : MonoBehaviour {
	//deklarera variabler: objektet, dess component, och variabeln camSize:
	public GameObject minimapCamera;
	public Camera camera;
	public float camSize;

	// Use this for initialization
	void Awake () {
		//här hugger vi objektets komponent Camera och sätter den i variabeln camera
		camera = minimapCamera.GetComponent<Camera>();
		//camSize = minimapCamera.GetComponent<Camera>.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire2") && camSize<=110f){
			camSize = camSize+10;
			camera.orthographicSize=camSize;
			Debug.Log(camSize);
		} else if (Input.GetButtonDown("Fire3") && camSize>=19f){
			camSize = camSize-10;
			camera.orthographicSize=camSize;
			Debug.Log(camSize);
		}
	}
}
