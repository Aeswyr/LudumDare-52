using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float dashForce = 125.0f;
    private float dashDecay = 1;
    [SerializeField] private float dashTimer = 100.0f;
    [SerializeField] private float jumpForce = 20.0f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private GroundedCheck gcheck;
    [SerializeField] SpriteRenderer sprite = null;
    [SerializeField] private InputHandler input;
    int dashFrames;
    // Start is called before the first frame update
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per RENDER frame
    void FixedUpdate() //why is this not defaulted
    {
        if (dashTimer < 100.0f)
            dashTimer += 1.0f;



        Vector2 movement = new Vector2(speed * input.dir.x, rbody.velocity.y);
        if (dashTimer == 100.0f && input.dodge.pressed)
        {
            rbody.gravityScale = 0;
            movement.y = 0;
            movement.x = dashForce;
            dashFrames = 10;
            dashTimer = 0.0f;

        }

        if (dashFrames > 0)
        {
            movement.y = 0;
            dashFrames -= 1;
            dashDecay += 1; 
            movement.x = dashForce / dashDecay;
            
        }
        else
        {
            dashDecay = 1;
            rbody.gravityScale = 7;
        }

        if (input.dir.x != 0)
            sprite.flipX = input.dir.x == -1;

        if (sprite.flipX)
        {
            dashForce = -125.0f;
        }
        else
        {
            dashForce = 125.0f;
        }
            


        bool grounded = gcheck.CheckGrounded();

        if (grounded && this.input.jump.pressed)
        {
            movement.y = jumpForce;
        }
        rbody.velocity = movement;



        if (input.primary.pressed)
            Instantiate(enemyPrefab, transform.position + 5 * Vector3.right, Quaternion.identity);



    }
}

