using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    Vector2? currentTargetPosition = null;
    // if false, mouse movment won't be able to change the target position
    bool allowTargetPositionOverride = true;

    public float movementSpeed = 3.0f;
    public DialogManager dialogManager;
    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void MoveTo(Vector2 destination)
    {

        Vector2 currentPos = this.transform.position;
        Vector2 distance = destination - currentPos;
        // Get the movment velocity vector based on the distance
        // The velocity will gradually decrese this way
        Vector2 movement = distance;

        // Consider a distance smaller than an epsilon = 0
        if(Mathf.Abs(movement.x) < 0.05)
        {
            movement.x = 0;
        }

        if(Mathf.Abs(movement.y) < 0.05)
        {
            movement.y = 0;
        }

        if(movement.x == 0 && movement.y == 0)
        {
            Debug.Log("Hello");
            // Destination reached          
            this.isMoving = false;
            this.currentTargetPosition = null;

            // Allow mouse movment if it was disabled before
            this.allowTargetPositionOverride = true;

        }

        movement.Normalize();
        rigidBody2D.velocity = movement * movementSpeed;
    }

    public void SetDestination(Vector2 destination, bool allowOverride)
    {
         // We have a destination so we are moving
        this.isMoving = true;
        this.currentTargetPosition = destination;
        this.allowTargetPositionOverride = allowOverride;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0) && this.allowTargetPositionOverride)
        {
            // Left clicked was pressed. Change the target position
            // The input is taken in screen space so convert in world space
            this.currentTargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }

        if(this.currentTargetPosition == null)
        {
            // No need to move
            return;
        }
        // We have a destination so we are moving
        this.isMoving = true;

        this.MoveTo((Vector2)this.currentTargetPosition);

       
    }
}

