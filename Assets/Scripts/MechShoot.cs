using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MechShoot : MonoBehaviour {
    
    Object varBullet;
    Object homingRocket;
    Object selectedWeapon;
    WeaponBase selectedWeaponBase;
    List<Object> mechWeapons = new List<Object>();
    public float LookRotationSpeed = 1f;
    public Rigidbody rb;
    public Camera gunnerCam;
    public Transform MechParent;
    public Transform CurrentTarget;
    public bool UseMouse = false;
    float nextFire = 0.0f;

    void Awake() {
        varBullet = Resources.Load("Rocket");
        mechWeapons.Add(varBullet);
        homingRocket = Resources.Load("HomingRocket");
        mechWeapons.Add(homingRocket);
        selectedWeapon = mechWeapons.First();
        selectedWeaponBase = (selectedWeapon as GameObject).GetComponent<WeaponBase>();
        rb = GetComponent<Rigidbody>();
        gunnerCam = transform.parent.gameObject.GetComponentInChildren<Camera>();
    }
    
    void Update() {
        if(UseMouse) {
            if (Input.GetButton("FireMouse1") && Time.time > nextFire) {
                FireMainGun();
                nextFire = Time.time + selectedWeaponBase.RateOfFire;
            }
            else if(Input.GetButtonDown("FireMouse2")) {
                LockTarget();
            }
            if (Input.GetButtonDown("Weapon1")) selectedWeapon = mechWeapons[0];
            if (Input.GetButtonDown("Weapon2")) selectedWeapon = mechWeapons[1];
            selectedWeaponBase = (selectedWeapon as GameObject).GetComponent<WeaponBase>();
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
        GameObject newRocket = Instantiate(selectedWeapon, transform.position + transform.forward, transform.rotation) as GameObject;
        ILockTarget lockTarget = newRocket.GetComponent<ILockTarget>();
        if (CurrentTarget != null && lockTarget != null)
            lockTarget.SetTarget(CurrentTarget);
    }
}
