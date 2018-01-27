using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTextRender : MonoBehaviour {
	public Transform target;
	public string renderKey;
	Camera cam;
	// Use this for initialization
	void Start () {
		//renderKey = "KEY";
		//cam = GetComponent<Camera>();
		target = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI(){
        GUI.enabled=true;
		cam=Camera.current;
        //Vector3 screenPos = cam.WorldToViewportPoint(target.position);
        Vector3 pos=cam.WorldToViewportPoint(target.position);
        
        Debug.Log("TARGET POSITION:" + target.position + "Vector3 pos:" + pos);
        //Rita ut en GUI Label med text en specifik position:
        GUI.Label(new Rect(pos.x,pos.y,150,130),renderKey);
        //GUI.Label(new Rect(0,0,150,130),renderKey);
    }
}