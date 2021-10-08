using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Dreamteck.Splines;
using UnityEngine;
using Random = System.Random;

public class HumanStackController : MonoBehaviour
{
    Stack<GameObject> trainStack = new Stack<GameObject>();
    private int index = 0;

    private void StackHuman()
    {
        
    }

    IEnumerator StackHuman( Vector3 v_start, Vector3 v_end, float duration, Transform pos )
    {
        pos.parent = transform;
        float elapsed = 0.0f;
        while (elapsed < duration )
        {
            pos.localPosition = Vector3.Lerp( v_start, v_end, elapsed / duration );
            elapsed += Time.deltaTime;
            yield return null;
        }
        pos.localPosition = v_end;
        
    }
    private void Stack(GameObject human)
    {
       // StartCoroutine(StackHuman(human.transform.position,transform.position + new Vector3(0,2,0),2,human.transform));
       human.transform.parent = transform;
      human. transform.localRotation = transform.localRotation;
        human.transform.localPosition = new Vector3(0, 0, -trainStack.Count );
        
    }

    private void UnStack()
    {
        GameObject human = trainStack.Pop();
        human.GetComponent<Human>().enabled = true;
        Rigidbody rb = human.AddComponent<Rigidbody>();
        rb.AddForce(new Vector3(UnityEngine.Random.Range(0,100),UnityEngine.Random.Range(0,100),UnityEngine.Random.Range(0,100)),ForceMode.Impulse);
        
    }

    private void Update()
    {
        Debug.Log(trainStack.Count);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("SlidingHuman"))
        {
            Human human = other.gameObject.GetComponent<Human>();
            other.gameObject.GetComponent<SplineFollower>().enabled = false;
            Destroy(other.gameObject.GetComponent<Rigidbody>());
            human.enabled = false;
            human.tag = "Untagged";
            trainStack.Push(human.gameObject);
            Stack(human.gameObject);
        }
        
        else if (other.gameObject.CompareTag("obstacle"))
        {
            UnStack();
        }
    }
}
