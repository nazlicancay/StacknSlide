using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public FloatingJoystick floatingJoystick;
    public Rigidbody rb;
    public SplineHorizontalMovementController horizontalController;
    public SplineFollower splineFollower;

/*    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right *floatingJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
    */

public void Update()
{
  
    if (floatingJoystick.Horizontal < 0)
    {
        horizontalController.horizontalPosition -= 0.01f;

    }

    if (floatingJoystick.Horizontal > 0)
    {
        horizontalController.horizontalPosition += 0.01f;
    }
}
}