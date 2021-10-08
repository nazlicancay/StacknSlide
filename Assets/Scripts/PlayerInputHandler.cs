using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private SplineHorizontalMovementController _horizontalMovementController;

    [SerializeField] private float moveMultiplier;

    private void Awake()
    {
        _horizontalMovementController = GetComponent<SplineHorizontalMovementController>();
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float val = Mathf.Clamp(moveMultiplier * Time.deltaTime * touch.deltaPosition.x + _horizontalMovementController.horizontalPosition, 0, 1);
                _horizontalMovementController.horizontalPosition = val;
            }
        }
    }
}
