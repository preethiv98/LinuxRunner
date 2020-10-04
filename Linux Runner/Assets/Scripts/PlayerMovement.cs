using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float moveSpeed;

    private bool facingRight;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    private bool isGrounded;

    private bool jump;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private LayerMask whatIsLadder;

    public float distance;

    private bool isClimbing;

    private float inputVertical;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    void Awake()
    {
        facingRight = true;
    }

    void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        isGrounded = IsGrounded();
        HandleInput();
        if (!isGrounded)
        {
            //anim.Play("Player_JUMP", 0);
        }
        HandleMovement(horizontal);
        Flip(horizontal);
        ResetValues();

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
       
        if(hitInfo.collider != null)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                isClimbing = true;
                anim.SetTrigger("Climbing");
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                isClimbing = false;
            }
        }

        if(isClimbing && hitInfo.collider != null)
        {
            anim.SetTrigger("Climbing");
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * moveSpeed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

    void Update()
    {
        //Debug.Log("nice");
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
       
        Flip(horizontal);
    }

    private void HandleMovement(float horizontal)
    {
        //Debug.Log("nice");
        //rb.velocity = Vector2.left;
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        if(isGrounded && jump)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0, jumpForce));
        }
        anim.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void Flip(float horizontal)
    {
        
        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            transform.Rotate(0f, 180f, 0f);

        }
    }

    private void ResetValues()
    {
        jump = false;
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    private bool IsGrounded()
    {
        if(rb.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for(int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
               
            }
            

        }
        return false;
       
    }

    
}
