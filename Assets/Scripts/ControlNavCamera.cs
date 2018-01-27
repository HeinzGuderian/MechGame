using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNavCamera : MonoBehaviour {
    public Camera navigatorCam;
	public bool UseMouse = false;
    public float LookRotationSpeed = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(UseMouse) {
            var mousePos = Input.mousePosition;
            var screenPos = navigatorCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, navigatorCam.farClipPlane));
            transform.LookAt(screenPos);
        }
        else{
 
            var controller2X = Input.GetAxis("Horizontal 2nd axis");
            var controller2Y = Input.GetAxis("Vertical 2nd axis");
            transform.Rotate(-controller2Y * LookRotationSpeed, controller2X * LookRotationSpeed, 0.0f);
        }
        
        Quaternion q = transform.rotation;
        q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, 0);
        transform.rotation = q;
	}
}
