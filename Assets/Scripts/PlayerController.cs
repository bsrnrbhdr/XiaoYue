using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : LivingThings
{
    Rigidbody2D playerRB;
    Animator playerAnim;

    public float moveSpeed = 1f;
    public float jumpSpeed = 1f, jumpFrequency = 1f, nextJumpTime = 1f;


    //bool facingRight = true;
    public bool isGrounded = false;
    public bool onAttack = false;
    public Transform groundCkeckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();
        onGroundCheck();
        if (playerRB.velocity.x < 0 && getFacingRight())
        {
            FlipFace();
        }
        else if (playerRB.velocity.x > 0 && !getFacingRight())
        {
            FlipFace();
        }
        if (ScreenTouch.direction == "Up" && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
        IsOnAttack();
      
    }

    void HorizontalMove()
    {
        if(ScreenTouch.direction =="Right" )
        {
            playerRB.velocity = new Vector2( moveSpeed, playerRB.velocity.y);

        }
        else if(ScreenTouch.direction == "Left")
        {
            playerRB.velocity = new Vector2(moveSpeed*-1, playerRB.velocity.y);
        }
        playerAnim.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
        
    }

  

    void Jump()
    {
        playerRB.AddForce(new Vector2(0f,jumpSpeed));
    }

    void onGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCkeckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnim.SetBool("isOnGround", isGrounded);
    }

    void IsOnAttack()
    {
       
        if (ScreenTouch.direction == "Attack")
        {

            onAttack = true;
        }
        else
        {
            onAttack = false;
        }
   
         playerAnim.SetBool("onAttack", onAttack);
      

    }
}
