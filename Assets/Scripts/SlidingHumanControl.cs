using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Dreamteck.Splines;
using UnityEditor.Scripting;
using UnityEngine;

public class SlidingHumanControl : MonoBehaviour
{
    // Start is called before the first frame update
    public SplineHorizontalMovementController horizontalController;
    public PlayerController playerController;
    public SplineFollower splineFollower;
    public bool hitObstacle;
   
  
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
      /*  if (playerController.onCollison == true)
        {
            splineFollower.followSpeed = 3;
        }
        */

        if (hitObstacle)
        {
            transform.Translate(Vector3.up * Time.deltaTime*8);

        }

        if (transform.position.y > 8)
        {
            Destroy(gameObject);
        }
      


    }
    
    

    private void OnCollisionEnter(Collision other)
    {
      /*  if (other.gameObject.CompareTag("obstacle"))
        {
            hitObstacle = true;
            Destroy(other.gameObject);
            Debug.Log("hitting an onstacle");

        }*/

        if (other.gameObject.CompareTag("Player"))
        {
            playerController.once = true;
            Destroy(gameObject);
            playerController.createChild = true;
        }
    }
}
