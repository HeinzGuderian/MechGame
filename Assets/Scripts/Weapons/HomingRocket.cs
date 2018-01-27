using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRocket : WeaponBase, ILockTarget {
    private Transform Target;
    public float force = 0.1f;
    private bool hasRecievedTarget = false;
    
    // Update is called once per frame
    void FixedUpdate () {
        if(Target != null) {
            HomeInOnTarget();
        }
        else if(Target == null && !hasRecievedTarget)
        {
            MoveForward();
        }
        else if(Target == null && hasRecievedTarget)
        {
            Destroy(gameObject, 0.001f);
        }
        
    }

    public void SetTarget(Transform target) {
        Target = target;
        hasRecievedTarget = true;
    }

    private void HomeInOnTarget() {
        Vector3 targetDelta = Target.position - transform.position;

        //get the angle between transform.forward and target delta
        float angleDiff = Vector3.Angle(transform.forward, targetDelta);

        // get its cross product, which is the axis of rotation to
        // get from one vector to the other
        Vector3 cross = Vector3.Cross(transform.forward, targetDelta);

        // apply torque along that axis according to the magnitude of the angle.
        rb.AddTorque(cross * angleDiff * force);
        MoveForward();
    }

}
