using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movement_speed = .5f;
    public Transform movepoint;
    private bool hasitem;
    public Rigidbody2D rb;
    public Animator animator;
    public bool canMove;
    public LayerMask Walls;
    public LayerMask Pushable;
    Vector2 movement; //stores an x and a y
    void Start()
    {
        movepoint.parent = null;

    }
    // Update is called once per frame
    void FixedUpdate()
    { //will take inputs, do not put physics here because framerate can vary

        if (!canMove)
        {
            animator.SetFloat("Speed", 0);
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, movepoint.position, movement_speed * Time.fixedDeltaTime);
        if (Vector3.Distance(transform.position, movepoint.position) <= 0.5f)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!(Physics2D.OverlapCircle(movepoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, Walls)))
                {
                    if ((Physics2D.OverlapCircle(movepoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, Pushable)))
                    {
                        if (!(Physics2D.OverlapCircle(movepoint.position + (2 * (new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f))), 0.2f, Walls)) && !(Physics2D.OverlapCircle(movepoint.position + (2 * (new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f))), 0.2f, Pushable)))
                        {
                            movepoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        }
                    }
                    else
                    {
                        movepoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    }
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!(Physics2D.OverlapCircle(movepoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, Walls)))
                {
                    if ((Physics2D.OverlapCircle(movepoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, Pushable)))
                    {
                        if (!(Physics2D.OverlapCircle(movepoint.position + (2 * (new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f))), 0.2f, Walls)) && !(Physics2D.OverlapCircle(movepoint.position + (2 * (new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f))), 0.2f, Pushable)))
                        {
                            movepoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        }
                    }
                    else
                    {

                        movepoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    }
                }
            }
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
