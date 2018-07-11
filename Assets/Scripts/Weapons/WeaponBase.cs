using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour {
    public int Damage = 10;
    public float TravelSpeed = 10f;
    public float SelfDestructFloatTime = 30f;
    protected Rigidbody rb;
    public float RateOfFire = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, SelfDestructFloatTime);
        AdditionalStartTimeCode();
    }

    protected virtual void AdditionalStartTimeCode() { }

    void OnCollisionEnter(Collision col)
    {
        GameObject hitGo = col.gameObject;
        IHealth hitGoHealth = hitGo.GetComponent<IHealth>();
        if (hitGoHealth != null)
        {
            hitGoHealth.DoDamage(Damage);
        }
        Destroy(gameObject, 0.001f);
    }

    protected void MoveForward() {
        rb.MovePosition(transform.localPosition + transform.forward * TravelSpeed * Time.deltaTime);
    }
}
