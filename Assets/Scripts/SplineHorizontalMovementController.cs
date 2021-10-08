using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;


public class SplineHorizontalMovementController : MonoBehaviour
{
   // positive values means right side of the mesh. Lerp spline offsets by referencing value
   [Range(0,1)]
   public float horizontalPosition = 0.5f;

   public SplineFollower splineComputer;

   [Header("Spline Follower Max And Min Offsets")]

   public float minOffsetYPos;
   public float maxOffsetYPos;
   [Space]
   public float minOffsetXPos;
   public float maxOffsetXPos;
   [Space]
   public float minOffsetZRot;
   public float maxOffsetZRot;

   private void Reset()
   {
       splineComputer = GetComponent<SplineFollower>();
   }

   public void SetPosition()
   {
       float offsetXPos = Mathf.Lerp(minOffsetXPos, maxOffsetXPos, horizontalPosition);
       float offsetZRot = Mathf.Lerp(minOffsetZRot, maxOffsetZRot, horizontalPosition);
       float offsetYPos;
       if (horizontalPosition  + 0.5f > 1)
       {
           
           offsetYPos = Mathf.Lerp(minOffsetYPos, maxOffsetYPos, horizontalPosition - 0.5f);
       }
       else
       {
           offsetYPos = Mathf.Lerp(maxOffsetYPos, minOffsetYPos , horizontalPosition + 0.5f);
       }
       
       

       splineComputer.motion.offset = new Vector2(offsetXPos, offsetYPos);
      // transform.rotation = Quaternion.Euler(0,0,offsetZRot);
      splineComputer.motion.rotationOffset = new Vector3(splineComputer.motion.rotationOffset.x, splineComputer.motion.rotationOffset.y,offsetZRot);
   }

   private void Update()
   {
       //Touch  firstDetectedTouch = Input.GetTouch(0);
       // Debug.Log(firstDetectedTouch.deltaPosition);
       SetPosition();
   }
}