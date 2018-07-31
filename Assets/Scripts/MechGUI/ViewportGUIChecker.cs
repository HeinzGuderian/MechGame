using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewportGUIChecker : MonoBehaviour {

	//public bool enter = true;
	//public bool exit = true;
    public GameObject GUIText;
    public float wtime;


//	ScriptNameToDisable script;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<KeyTextRender>().enabled=false;
		Debug.Log("Viewport GUI Checker script initiated");
        //GUIText.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        //if not colliding with anything disable KeyTextRender.
		
	}
	void OnTriggerEnter (Collider col){
        if(col.gameObject.name == "CameraNavigator")
        //if(enter)
        {
            Debug.Log("Camera looked at button");
            gameObject.GetComponent<KeyTextRender>().enabled = true;
            //enablar GUIText för den kan startar i disabled-läge:
            GUIText.GetComponent<UnityEngine.UI.Text>().enabled = true;
        }
    }

    void OnTriggerExit(Collider col){
    	if(col.gameObject.name =="CameraNavigator")
    	//if(exit)
    	{
    		Debug.Log("Camera looked AWAY");
    		gameObject.GetComponent<KeyTextRender>().enabled = false;
            //disable the Canvas\Text objektet så det inte ritas ut mitt på skärmen enligt direktiv från Canvas.
            GUIText.GetComponent<UnityEngine.UI.Text>().enabled = false;
    	}
    }
}
