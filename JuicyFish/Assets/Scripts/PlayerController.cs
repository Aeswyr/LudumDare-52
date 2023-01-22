using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    // [SerializeField] private BoxCollider2D hitBox;
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private GroundedCheck gcheck;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] TrailRenderer trail;
    [SerializeField] private InputHandler input;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject dash_vfx;

    [Header("Stats")]
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float dashForce = 125.0f;
    [SerializeField] private float jumpForce = 20.0f;

    [Header("Misc")]
    [SerializeField] private float dashTimer = 100.0f;
    int dashFrames;
    private float dashDecay = 1;
    // Start is called before the first frame update
    void Start()
    {
        trail.emitting = false;
    }

    void FixedUpdate()
    {
        //Set dash on a timer (counting up)
        if (dashTimer < 100.0f)
            dashTimer += 1.0f;

        //Set up initial movement 
        Vector2 movement = new Vector2(speed * input.dir.x, rbody.velocity.y);

        //Dash Input (even though it says dodge)
        if (dashTimer == 100.0f && input.dodge.pressed)
        {
            rbody.gravityScale = 0;
            movement.y = 0;
            movement.x = dashForce;
            dashFrames = 10;
            dashTimer = 0.0f;
            trail.emitting = true;
            //animation state for dash
            animator.SetTrigger("dash");
        }
        //Lingering frames after intial dash (decay speed)
        if (dashFrames > 0)
        {
            movement.y = 0;
            dashFrames -= 1;
            dashDecay += 1;
            movement.x = dashForce / dashDecay;
        }
        else //Reset dash decay, turn gravity back on after dash ends
        {
            trail.emitting = false;
            dashDecay = 1;
            rbody.gravityScale = 7;
        }

        //Flip sprite direction based on input
        if (input.dir.x != 0)
            sprite.flipX = input.dir.x == -1;
        //Based on sprite, flip direction of dashFroce
        if (sprite.flipX)
        {
            dashForce = -125.0f;
        }
        else
        {
            dashForce = 125.0f;
        }

        //Jump input
        bool grounded = gcheck.CheckGrounded();
        animator.SetBool("grounded", grounded);

        if (grounded && this.input.jump.pressed)
        {
            Debug.Log("jumping");
            movement.y = jumpForce;
        }

        //Update velocity with movement
        rbody.velocity = movement;
        animator.SetBool("moving", movement.x != 0);


        //Attack input
        if (input.primary.pressed)
            animator.SetTrigger("attack");
    }

    public void onDeath()
    {
        Debug.Log("DEDGE!");
    }

    void onDash()
    {
        Instantiate(dash_vfx, transform.position, Quaternion.identity);
    }
}

