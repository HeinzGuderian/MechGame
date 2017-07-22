using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechShoot : MonoBehaviour {
    
    Object varBullet;
    void Start()
    {
        varBullet = Resources.Load("Rocket");
        //Vector3 bulletPosition = new Vector3(0,2,0);
        Debug.Log("Bullet prefab loaded");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("PEW!");
            //Instantiate(varBullet);

            Instantiate(varBullet, transform.position + transform.forward, transform.localRotation);
        }

    }

}
