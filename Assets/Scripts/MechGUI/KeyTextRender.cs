using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyTextRender : MonoBehaviour {
	public string label;
	public Text buttonLabel;
	public Camera cam;
	void Start(){
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 labelPos = cam.WorldToScreenPoint(this.transform.position);
		buttonLabel.transform.position = labelPos;
		
	}
	//void OnGUI(){
		//Vector3 labelPos = cam.WorldToScreenPoint(this.transform.position);
		//GUI.Label(new Rect(labelPos.x, Screen.height-labelPos.y, 150, 130),label); 
	//}
}