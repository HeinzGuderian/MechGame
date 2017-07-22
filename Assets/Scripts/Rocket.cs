using System.Collections;
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
    // Use this for initialization
    void Start()
    {
        //bullet kills itself after 3 seconds of existing
        //Destroy(gameObject, 3.0f);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
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
        rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
    }
}
