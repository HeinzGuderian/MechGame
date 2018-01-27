﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyTextRender : MonoBehaviour {

	public Text buttonLabel;
	public Camera cam;

	
	// Update is called once per frame
	void Update () {
		Vector3 labelPos = cam.WorldToScreenPoint(this.transform.position);
		buttonLabel.transform.position = labelPos;
	}
	
}