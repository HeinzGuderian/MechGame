using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    //    private float birthTime = 0f;
    public int Damage = 10;
    public float bulletSpeed = 40f;
    public Rigidbody rb;

    void Awake()
    {
//        birthTime = Time.time;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 30f);
    }

    void OnCollisionEnter(Collision col)
    {
        GameObject hitGo = col.gameObject;
        IHealth hitGoHealth = hitGo.GetComponent<IHealth>();
        if(hitGoHealth != null)
        {
            hitGoHealth.DoDamage(Damage);
        }
        Destroy(gameObject, 0.001f);
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.localPosition + transform.forward * bulletSpeed * Time.deltaTime);
    }
    
}
