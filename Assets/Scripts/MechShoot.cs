using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechShoot : MonoBehaviour {
    
    Object varBullet;
    public float LookRotationSpeed = 1f;
    public Rigidbody rb;
    public Camera gunnerCam;
    public Transform MechParent;

    void Start()
    {
        varBullet = Resources.Load("Rocket");
        rb = GetComponent<Rigidbody>();
        gunnerCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(varBullet, transform.position + transform.forward, transform.rotation);
        }

        var mousePos = Input.mousePosition;
        var screenPos = gunnerCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, gunnerCam.farClipPlane));// transform.localPosition.z - gunnerCam.transform.localPosition.z));
        transform.LookAt(screenPos);
        //transform.rotation.eulerAngles.z = Mathf.Atan2((screenPos.y - transform.position.y), (screenPos.x - transform.position.x)) * Mathf.Rad2Deg;
    }

    void FixedUpdate()
    {
        //Quaternion deltaRotation = Quaternion.Euler(TurnVector * Time.deltaTime);

        var mousePos = Input.mousePosition;
        var screenPos = gunnerCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.localPosition.z - gunnerCam.transform.localPosition.z));

       // rb.MovePosition(new Vector3(MechParent.position.x, MechParent.position.y) + MechParent.forward * Time.deltaTime);
       /* rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles + new Vector3(LookRotationSpeed * -(screenPos.y - transform.position.y), 
                                                                             LookRotationSpeed * (screenPos.x - transform.position.x), 0f) * Time.deltaTime) ;
        rb.MoveRotation(rb.rotation); */

    }
}
