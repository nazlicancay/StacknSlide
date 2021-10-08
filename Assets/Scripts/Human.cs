using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using Dreamteck.Splines.Primitives;
using UnityEngine;
using Random = UnityEngine.Random;

public class Human : MonoBehaviour
{
    public float maxSpeed;
    public float minSpeed;

    public SplineHorizontalMovementController _horizontalMovementController;
    public SplineFollower splineFollower;
    public SplineHorizontalMovementController horizontalController;
    public PlayerController playerController;
    public bool hitObstacle;

    public bool humanAlive = true;

    private bool isMovingHorizontally = false;

    private float timer = 0;
    

    public float changeBehaviourInSeconds;
    public float horizontalLerpTime;

    public float startPos;

    private void Start()
    {
        StartCoroutine(ChangeBehaviour());
    }

    private void Update()
    {
        if (hitObstacle)
        {
            transform.Translate(Vector3.up * Time.deltaTime*8);

        }

        if (transform.position.y > 8)
        {
            Destroy(gameObject);
        }

    }
    
 /*   private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            hitObstacle = true;
            Destroy(other.gameObject);
            Debug.Log("hitting an onstacle");

        }

        if (other.gameObject.CompareTag("Player"))
        {
            playerController.once = true;
            Destroy(gameObject);
            playerController.createChild = true;
        }
    }
    */


    IEnumerator MoveHorizontal( float v_start, float v_end, float duration )
    {
        float elapsed = 0.0f;
        while (elapsed < duration )
        {
            _horizontalMovementController.horizontalPosition = Mathf.Lerp( v_start, v_end, elapsed / duration );
            elapsed += Time.deltaTime;
            yield return null;
        }
        _horizontalMovementController.horizontalPosition = v_end;
    }

    IEnumerator ChangeBehaviour()
    {
        while (humanAlive)
        {
            splineFollower.followSpeed = Random.Range(minSpeed, maxSpeed);
            startPos = _horizontalMovementController.horizontalPosition;
            StartCoroutine(MoveHorizontal(startPos, Random.Range(0f, 1f), horizontalLerpTime));
            yield return new WaitForSeconds(changeBehaviourInSeconds);
            isMovingHorizontally = false;
        }

    }
    
  
}
