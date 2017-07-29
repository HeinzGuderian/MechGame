using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechShoot : MonoBehaviour {
    
    Object varBullet;
    public float LookRotationSpeed = 1f;
    public Rigidbody rb;
    public Camera gunnerCam;
    public Transform MechParent;
    public bool UseMouse = false;

    void Start()
    {
        varBullet = Resources.Load("Rocket");
        rb = GetComponent<Rigidbody>();
        gunnerCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    
    void Update()
    {
        if(UseMouse)
        {
            if (Input.GetButtonDown("FireMouse1"))
            {
                FireMainGun();
            }
            var mousePos = Input.mousePosition;
            var screenPos = gunnerCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, gunnerCam.farClipPlane));
            transform.LookAt(screenPos);
        }
        else
        {
            if (Input.GetButtonDown("FireJoy360A") || Input.GetButtonDown("FireJoy360Right"))
            {
                FireMainGun();
            }
            var controller2X = Input.GetAxis("Horizontal 2nd axis");
            var controller2Y = Input.GetAxis("Vertical 2nd axis");
            transform.Rotate(-controller2Y * LookRotationSpeed, controller2X * LookRotationSpeed, 0.0f);
        }
        
        Quaternion q = transform.rotation;
        q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, 0);
        transform.rotation = q;
    }

    public void FireMainGun()
    {
        Instantiate(varBullet, transform.position + transform.forward, transform.rotation);
    }
}
