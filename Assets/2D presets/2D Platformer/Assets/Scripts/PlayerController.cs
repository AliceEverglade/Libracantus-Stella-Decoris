using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [Header("State Booleans")]
    [SerializeField] private bool isFacingRight = true;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isTouchingWall;

    [Header("Movement")]
    [SerializeField] private float movementInputDirection;
    [SerializeField] private float movementSpeed;

    [Header("Jumping")]
    [SerializeField] private float jumpForce;
    [SerializeField] private int jumpCount;
    [SerializeField] private int currentJumpCount;
    [SerializeField] private bool canJump;

    [Header("groundCheck")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayerMask;
    private float hoverRange = 7f;

    [Header("WallCheck")]
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;

    [Header("AnimationState")]
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
                anim.Play(value.ToString());
                currentState = value;
            }
        }
    }

    public enum animationStates
    {
        PlayerIdle,
        PlayerRun,
        PlayerAscent,
        PlayerHover,
        PlayerDescent
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
        CheckSurrounding();
        CheckIfCanJump();
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (Mathf.Abs(movementInputDirection) < 0.1f && isGrounded)
        {
            CurrentState = animationStates.PlayerIdle;
        }

        if (Mathf.Abs(movementInputDirection) > 0.1f && isGrounded)
        {
            CurrentState = animationStates.PlayerRun;
        }

        if (rb.velocity.y > 0.1f)
        {
            CurrentState = animationStates.PlayerAscent;
        }
        else if (rb.velocity.y < hoverRange && rb.velocity.y > -hoverRange && !isGrounded)
        {
            CurrentState = animationStates.PlayerHover;
        }
        else if(rb.velocity.y < -hoverRange && !isGrounded)
        {
            CurrentState = animationStates.PlayerDescent;
        }

    }

    private void CheckSurrounding()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayerMask);
        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, groundLayerMask);
    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");
        
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
    }

    private void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            currentJumpCount--;
        }
        
    }

    private void CheckIfCanJump()
    {
        if(isGrounded && rb.velocity.y <= 0)
        {
            currentJumpCount = jumpCount;
        }
        if(currentJumpCount <= 0)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180f, 0.0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
