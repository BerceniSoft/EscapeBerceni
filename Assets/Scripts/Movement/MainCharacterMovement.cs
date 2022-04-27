using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    Rigidbody2D rigidBody2D;
    Vector2? currentTargetPosition = null;
    public DialogManager dialogManager;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidBody2D = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0))
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

        Vector2 currentPos = this.transform.position;
        Vector2 distance = (Vector2)this.currentTargetPosition - currentPos;
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

        movement.Normalize();
        rigidBody2D.velocity = movement * movementSpeed;

    }
}

