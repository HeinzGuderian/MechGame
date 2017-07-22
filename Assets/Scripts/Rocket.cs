﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    private float birthTime = 0f;
    public float bulletSpeed = 20f;
    public Rigidbody rb;

    void Awake()
    {
        birthTime = Time.time;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter()
    {
        //Bullet collides with anything, print it
        Debug.Log("Bullet collides with something. Destroys self.");
        //destroys itself
        Destroy(gameObject, 0.001f);
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * bulletSpeed * Time.deltaTime);
    }
}
