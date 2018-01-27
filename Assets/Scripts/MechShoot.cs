using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechShoot : MonoBehaviour {
    
    Object varBullet;
    Object homingRocket;
    public float LookRotationSpeed = 1f;
    public Rigidbody rb;
    public Camera gunnerCam;
    public Transform MechParent;
    public Transform CurrentTarget;
    public bool UseMouse = false;

    void Start() {
        varBullet = Resources.Load("Rocket");
        homingRocket = Resources.Load("HomingRocket");
        rb = GetComponent<Rigidbody>();
        gunnerCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    
    void Update() {
        if(UseMouse) {
            if (Input.GetButtonDown("FireMouse1")) {
                FireMainGun();
            }
            else if(Input.GetButtonDown("FireMouse2")) {
                LockTarget();
            }
            var mousePos = Input.mousePosition;
            var screenPos = gunnerCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, gunnerCam.farClipPlane));
            transform.LookAt(screenPos);
        }
        else
        {
            if (Input.GetButtonDown("FireJoy360A") || Input.GetButtonDown("FireJoy360Right")) {
                FireMainGun();
            }
            else if (Input.GetButtonDown("FireJoy360B")) {
                LockTarget();
            }
            var controller2X = Input.GetAxis("Horizontal 2nd axis");
            var controller2Y = Input.GetAxis("Vertical 2nd axis");
            transform.Rotate(-controller2Y * LookRotationSpeed, controller2X * LookRotationSpeed, 0.0f);
        }
        
        Quaternion q = transform.rotation;
        q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, 0);
        transform.rotation = q;
    }

    public void LockTarget() {
        RaycastHit objectHit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd * 50, Color.red, duration: 1200, depthTest: false);
        if (Physics.Raycast(transform.position, fwd, out objectHit, 50) && objectHit.transform.tag == "TestEnemy")
            CurrentTarget = objectHit.transform;
    }

    public void FireMainGun() {
        GameObject newRocket = Instantiate(homingRocket, transform.position + transform.forward, transform.rotation) as GameObject;
        if(CurrentTarget != null)
            newRocket.GetComponent<HomingRocket>().SetTarget(CurrentTarget);
    }
}
