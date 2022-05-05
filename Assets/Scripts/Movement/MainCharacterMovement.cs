using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    Vector2? currentTargetPosition = null;
    // if false, mouse movment won't be able to change the target position
    bool allowTargetPositionOverride = true;
    bool preventMovement = false;

    public float movementSpeed = 3.0f;
    public DialogManager dialogManager;
    public bool isMoving = false;
    public Animator anim;

    void SetWalkingAniamtion(bool isWalking)
    {
        anim.SetBool("IsWalking", isWalking);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void PauseMovement()
    {
        this.preventMovement = true;
        // Delete the current velocity
        // When resumed, the next call to update will set back the velocity
        rigidBody2D.velocity = new Vector2(0,0);
        this.SetWalkingAniamtion(false);
    }

    public void ResumeMovement()
    {
         this.preventMovement = false;
         this.SetWalkingAniamtion(true);
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
            // Destination reached          
            this.isMoving = false;
            this.SetWalkingAniamtion(false);

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
        this.SetWalkingAniamtion(true);
        this.currentTargetPosition = destination;
        this.allowTargetPositionOverride = allowOverride;
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if(this.preventMovement)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && this.allowTargetPositionOverride)
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

