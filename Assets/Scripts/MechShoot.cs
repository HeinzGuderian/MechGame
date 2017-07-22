using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechShoot : MonoBehaviour {
    
    Object varBullet;
    void Start()
    {
        varBullet = Resources.Load("Rocket");
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(varBullet, transform.position + transform.forward, transform.localRotation);
        }
    }
}
