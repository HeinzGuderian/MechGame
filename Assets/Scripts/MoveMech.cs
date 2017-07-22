using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMech : MonoBehaviour {

    //private Transform tempPosition;
    public float Speed = 10;
    public float TurnSpeed = 2;
    public float Translation;
    public Rigidbody rb;

    /*public Animation ship_idle;
    public Animation ship_moveUp;
    public Animation ship_moveDown;
    public Animation ship3danim; */
    // Use this for initialization
    void Start()
    {
        //tempPosition.translate = transform.translate;
        Translation = Input.GetAxis("Vertical") * Speed;
        rb = GetComponent<Rigidbody>();
        //ship3danim = GetComponentInChildren<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        // Turns the mech
        transform.Rotate(0.0f, -Input.GetAxis("Horizontal") * TurnSpeed, 0.0f);
        //moves the ship: takes vertical axis input, multipies with delta time, adjusts player position accordingly
        Translation = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        transform.Translate(0, 0, Translation);
        /*
        if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
        {
            //ship_moveDown.Play();
            //blend from current playing animation to anim_moveDown
            ship3danim.Blend("anim_shipMoveDown");

            //Debug.Log("down pressed");
        }
        else if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
        {
            //blend from current playing animation to anim_moveUp
            ship3danim.Blend("anim_shipMoveUp");
        }
        else if (Input.GetKeyUp("down") || Input.GetKeyUp("s") || Input.GetKeyUp("up") || Input.GetKeyUp("w"))
        {
            ship3danim.Play("anim_shipIdle");
        }
        */

    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
    }
}
