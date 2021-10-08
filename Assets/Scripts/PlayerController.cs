using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Dreamteck.Splines;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool onCollison;
    public bool obstaclecollision =false;
    public Human slidingHumanControl;
    public GameObject obstacle;
    public bool createChild;
    public bool once = false;
    public int childCount = 0;
    public GameObject placeHolder;
    public bool destroychild;
    public List<GameObject> childSpheres;


    public void Update()
    {
        if (createChild &&once)
        {
            childCount += 1;
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.gameObject.tag = "otherPlayer";
           
            var transformRotation = sphere.transform.rotation;
            
            sphere.transform.position = new Vector3(placeHolder.transform.position.x,placeHolder.transform.position.y + childCount ,placeHolder.transform.position.z);
            //sphere.transform.position = placeHolder.transform.position + Vector3.up* childCount;
            sphere.transform.SetParent(transform);
            childSpheres.Add(sphere);
            Debug.Log(childSpheres.Count);


           once = false;
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            Destroy(childSpheres[childSpheres.Count -1 ]);
            childCount -= 1;
        }
    }


    /*  public void OnCollisionEnter(Collision other) 
    {
        
        if(other.gameObject.CompareTag("SlidingHuman"))
        {
           
            other.transform.parent = transform;
            Debug.Log("collition");
            onCollison = true;
            other.gameObject.GetComponent<SplineFollower>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<Collider>().enabled = false;
        }

        if (other.gameObject.CompareTag("obstacle") && transform.childCount > 0)
        {
            other.gameObject.GetComponent<Collider>().enabled = true;
        }
        
      

    }
    

    public void OnCollisionExit(Collision other)
    {
        if (slidingHumanControl.hitObstacle)
        {
            other.transform.parent = null;
            Debug.Log("not child");

        }
    }
    */
}



    
