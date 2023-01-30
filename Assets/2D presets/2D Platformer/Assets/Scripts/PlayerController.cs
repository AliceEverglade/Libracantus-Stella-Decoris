using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private float movementInputDirection;
    [SerializeField] private bool isFacingRight = true;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;


    [SerializeField] private animationStates currentState = animationStates.PlayerIdle;
    public animationStates CurrentState
    {
        get
        {
            return currentState;
        }
        private set
        {
            if(currentState != value)
            {
                anim.Play(value.ToString()); //replace with an event to an animation script or a generalized function
                currentState = value;
            }
        }
    }

    public enum animationStates
    {
        PlayerIdle,
        PlayerRun,
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        CheckInput();
        CheckMovementDirection();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void CheckSurrounding()
    {
        //isGrounded = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, )
    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");
        if(Mathf.Abs(movementInputDirection) < 0.1f)
        {
            CurrentState = animationStates.PlayerIdle;
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void CheckMovementDirection()
    {
        if(isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }
        else if(!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }
    }

    private void ApplyMovement()
    {
        rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
        if(Mathf.Abs(movementInputDirection) > 0.1f)
        {
            CurrentState = animationStates.PlayerRun;
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180f, 0.0f);
    }
}
