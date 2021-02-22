using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movement_speed = 5f;
    private bool hasitem;
    public Rigidbody2D rb;
    public Animator animator;
    public bool canMove;
    Vector2 movement; //stores an x and a y

    // Update is called once per frame
    void Update()
    { //will take inputs, do not put physics here because framerate can vary

        if (!canMove)
        {
            movement.x = 0;
            movement.y = 0;
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 0);
            return;
        }
        this.enabled = true;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    { //does movement, called at a constant 50 frames per second
        rb.MovePosition(rb.position + movement * movement_speed * Time.fixedDeltaTime); //Time.fixedDeltaTime keeps time that has elapsed since last function call, helps keep movement speed constant
    }
}
