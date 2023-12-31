using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    [SerializeField] float JumpSpeed;
    [SerializeField] private LayerMask JumpableGround;
    [SerializeField] private AudioSource jump;
    
    float horizontalInput;

    private Rigidbody2D rb;
    private Animator Anim;
    private SpriteRenderer sr;
    private BoxCollider2D Coll;

    private enum MovementState {idle, running, jump, fall }
   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        Coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

        Movement();

        Jump();

        UpdateAnimation();
       
    }

    private void Movement() 
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput* MoveSpeed, rb.velocity.y);
        
    }
    private void Jump()
    {
       
        if (Input.GetButtonDown("Jump")&& IsGrounded())
        {
            rb.velocity = new Vector2(0, JumpSpeed);
            jump.Play();
        }

       
    }
    private void UpdateAnimation() 
    {

        MovementState state;


        if (horizontalInput > 0)
        {
            sr.flipX = false;
            state = MovementState.running;
        }
        else if (horizontalInput < 0)
        {
            sr.flipX = true;
            state = MovementState.running;
        }
        else 
        {
            state=MovementState.idle;
        }

        if (rb.velocity.y > .1f) 
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }

        Anim.SetInteger("state",(int) state);
    }

    private bool IsGrounded() 
    {
       return Physics2D.BoxCast(Coll.bounds.center, Coll.bounds.size, 0f, Vector2.down, .5f, JumpableGround);
    } 
}



    



   