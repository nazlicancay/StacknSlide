using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderSurfaceScanner : MonoBehaviour
{
    /// <summary>
    /// NOT !! BU SCRIPT KULLANILMICAK, ANLAMAYA CALISMA
    /// 
    /// Raycast surface and place object to given height offset.
    /// </summary>
    
    [Tooltip("Raycast only specific layer.")]
    public LayerMask surfaceLayerForScan;
    
    [Tooltip("height offset")]
    public float placeOffset;


    private void FixedUpdate()
    {
       SetOffset();
    }


    /// <summary>
    /// Raycasts from bottom of the object, set the offset height and returns the hitpoint.
    /// </summary>
    /// <returns></returns>
    private Vector3 ScanSurface()
    {
        Vector3 transformForward = Vector3.up * -1;
        RaycastHit hit;
        // Does the ray intersect any slider object
        if (Physics.Raycast(transform.position, transformForward, out hit, Mathf.Infinity, surfaceLayerForScan))
        {
            Debug.DrawRay(transform.position, transformForward * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            return hit.point;
        }
        else
        {
            Debug.DrawRay(transform.position, transformForward * 1000, Color.white);
            Debug.Log("Did not Hit");
            return Vector3.zero;
        }
    }

    private void SetOffset()
    {
        Vector3 hitPoint = ScanSurface();

        transform.position  = hitPoint + new Vector3(0,placeOffset,0);
        transform.LookAt(hitPoint);
    }
    
}
