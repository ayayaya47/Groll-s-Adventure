using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeChange : MonoBehaviour
{
    public float runSpeed;
    private Animator myAnim;
    private Rigidbody2D myRigidbody;
    public Transform groundCheck;
    public LayerMask ground;
    private Collider2D coll;
    public Collider2D discoll;
    public bool isGround;
    private bool canDoubleJump;
    public Transform TopCheck;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        //Climb();
        //Attack();
        CheckGrounded();
        //CheckLadder();
        SwitchAnimation();
        //OneWayPlatformCheck();
        Slide();
    }
    void CheckGrounded()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        //isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) ||
        //           myFeet.IsTouchingLayers(LayerMask.GetMask("MovingPlatform")) ||
        //           myFeet.IsTouchingLayers(LayerMask.GetMask("DestructibleLayer")) ||
        //           myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
        ////isOneWayPlatform = myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
    }
    void Run()
    {
        
        myAnim.SetBool("running2",true);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
          
                myAnim.SetBool("jumping", true);
               
           
        }
    }
    void SwitchAnimation()
    {
        myAnim.SetBool("idle", false);
        if (myAnim.GetBool("jumping"))
        {
            if (myRigidbody.velocity.y < 0.0f) //到达最高点
            {
                myAnim.SetBool("jumping", false);
                myAnim.SetBool("fall", true);
            }
        }
        else if (isGround)
        {
            myAnim.SetBool("fall", false);
            myAnim.SetBool("idle", true);
        }

        if (myAnim.GetBool("Doublejump"))
        {
            if (myRigidbody.velocity.y < 0.0f)
            {
                myAnim.SetBool("Doublejump", false);
                myAnim.SetBool("Doublefall", true);
            }
        }
        else if (isGround)
        {
            myAnim.SetBool("Doublefall", false);
            myAnim.SetBool("idle", true);
        }
    }

    void Slide()
    {
        if (!Physics2D.OverlapCircle(TopCheck.position, 0.2f, ground))
        {


            if (Input.GetButtonDown("Slide"))
            {

                myAnim.SetBool("slide", true);
                discoll.enabled = false;

            }
            else if (Input.GetButtonUp("Slide"))
            {
                myAnim.SetBool("slide", false);
                discoll.enabled = true;
            }
        }
    }
}
