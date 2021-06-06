using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.InputSystem;

public class PlayerControler2 : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    public float doulbJumpSpeed;
    //public float climbSpeed;
    //public float restoreTime;

    public Transform groundCheck;
    public LayerMask ground;

    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    private Collider2D coll;
    public Collider2D discoll;
    public Transform TopCheck;
    //private BoxCollider2D myFeet;
    public bool isGround;
    private bool canDoubleJump;

    public AudioSource GemAudio;
    public Joystick joystick;




    public int Gem;

    public Text GemNum;

    public int count;

    //private bool isOneWayPlatform;

    //private bool isLadder;
    //private bool isClimbing;

    //private bool isJumping;
    //private bool isFalling;
    //private bool isDoubleJumping;
    //private bool isDoubleFalling;

    //private float playerGravity;

    //private PlayerInputActions controls;
    //private Vector2 move;

    //void Awake()
    //{
    //    controls = new PlayerInputActions();

    //    controls.GamePlay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
    //    controls.GamePlay.Move.canceled += ctx => move = Vector2.zero;
    //    controls.GamePlay.Jump.started += ctx => Jump();
    //}

    //void OnEnable()
    //{
    //    controls.GamePlay.Enable();
    //}

    //void OnDisable()
    //{
    //    controls.GamePlay.Disable();
    //}

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        discoll = GetComponent<Collider2D>();
        CollBar.CollMax = count;
        CollBar.CollCurrent = count;
        //myFeet = GetComponent<BoxCollider2D>();
        //playerGravity = myRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameController.isGameAlive)
        //{
            //CheckAirStatus();
            Flip();
            Run();
            Jump();
            //Climb();
            //Attack();
            CheckGrounded();
            //CheckLadder();
            SwitchAnimation();
        //OneWayPlatformCheck();
        Slide();
       // }
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

    //void CheckLadder()
    //{
    //    isLadder = myFeet.IsTouchingLayers(LayerMask.GetMask("Ladder"));
    //    //Debug.Log("isLadder:" + isLadder);
    //}

    void Flip()
    {
        bool plyerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (plyerHasXAxisSpeed)
        {
            if (myRigidbody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (myRigidbody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    void Run()
    {
        float moveDir=joystick.Horizontal;
        //float moveDir = Input.GetAxis("Horizontal");
        ////Debug.Log("moveDir = " + moveDir.ToString());
        Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVel;
        //bool plyerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        //myAnim.SetBool("running2", plyerHasXAxisSpeed);

        //Vector2 playerVelocity = new Vector2(move.x * runSpeed, myRigidbody.velocity.y);
        //myRigidbody.velocity = playerVelocity;
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnim.SetBool("running2", playerHasXAxisSpeed);
    }

    void Jump()
    {
        
        if(joystick.Vertical>0.5f)
        //if (Input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                myAnim.SetBool("jumping", true);
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                myRigidbody.velocity = Vector2.up * jumpVel;
                canDoubleJump = true;
            }
                        else
                        {
                            if (canDoubleJump)
                            {
                                myAnim.SetBool("Doublejump", true);
                                Vector2 doubleJumpVel = new Vector2(0.0f, doulbJumpSpeed);
                                myRigidbody.velocity = Vector2.up * doubleJumpVel;
                                canDoubleJump = false;
                            }
                        }
                    }
        }


    //    void Climb()
    //    {
    //        float moveY = Input.GetAxis("Vertical");

    //        if (isClimbing)
    //        {
    //            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, moveY * climbSpeed);
    //            canDoubleJump = false;
    //        }

    //        if (isLadder)
    //        {
    //            if (moveY > 0.5f || moveY < -0.5f)
    //            {
    //                myAnim.SetBool("Jump", false);
    //                myAnim.SetBool("DoubleJump", false);
    //                myAnim.SetBool("Climbing", true);
    //                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, moveY * climbSpeed);
    //                myRigidbody.gravityScale = 0.0f;
    //            }
    //            else
    //            {
    //                if (isJumping || isFalling || isDoubleJumping || isDoubleFalling)
    //                {
    //                    myAnim.SetBool("Climbing", false);
    //                }
    //                else
    //                {
    //                    myAnim.SetBool("Climbing", false);
    //                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0.0f);

    //                }
    //            }
    //        }
    //        else
    //        {
    //            myAnim.SetBool("Climbing", false);
    //            myRigidbody.gravityScale = playerGravity;
    //        }

    //        if (isLadder && isGround)
    //        {
    //            myRigidbody.gravityScale = playerGravity;
    //        }

    //        //Debug.Log("myRigidbody.gravityScale:"+ myRigidbody.gravityScale);
    //    }

    //void Attack()
    //{
    //    if (Input.GetButtonDown("Atk1"))
    //    {
    //        myAnim.SetTrigger("attack1");
    //    }
    //    if (Input.GetButtonDown("Atk2"))
    //    {
    //        myAnim.SetTrigger("attack2");
    //    }
    //}

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
        if (!Physics2D.OverlapCircle(TopCheck.position,0.2f,ground))
        {


            if (joystick.Vertical<-0.5)
            //if (Input.GetButtonDown("Slide"))
            {

                myAnim.SetBool("slide", true);
                discoll.enabled = false;

            }
            
            else if (joystick.Vertical<-0.5)
            //else if (Input.GetButtonUp("Slide"))
            {
                myAnim.SetBool("slide", false);
                discoll.enabled = true;
            }
        }
    }
    
    //    void OneWayPlatformCheck()
    //    {
    //        if (isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
    //        {
    //            gameObject.layer = LayerMask.NameToLayer("Player");
    //        }

    //        float moveY = Input.GetAxis("Vertical");
    //        if (isOneWayPlatform && moveY < -0.1f)
    //        {
    //            gameObject.layer = LayerMask.NameToLayer("OneWayPlatform");
    //            Invoke("RestorePlayerLayer", restoreTime);
    //        }
    //    }

    //    void RestorePlayerLayer()
    //    {
    //        if (!isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
    //        {
    //            gameObject.layer = LayerMask.NameToLayer("Player");
    //        }
    //    }

    //    void CheckAirStatus()
    //    {
    //        isJumping = myAnim.GetBool("Jump");
    //        isFalling = myAnim.GetBool("Fall");
    //        isDoubleJumping = myAnim.GetBool("DoubleJump");
    //        isDoubleFalling = myAnim.GetBool("DoubleFall");
    //        isClimbing = myAnim.GetBool("Climbing");
    //        //Debug.Log("isJumping:" + isJumping);
    //        //Debug.Log("isFalling:" + isFalling);
    //        //Debug.Log("isDoubleJumping:" + isDoubleJumping);
    //        //Debug.Log("isDoubleFalling:" + isDoubleFalling);
    //        //Debug.Log("isClimbing:" + isClimbing);
    //    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //收集物品
    if (collision.tag == "Collection")
    {
    //    //    //Collection_kill star = collision.gameObject.GetComponent < Collection_kill >();

    //    //    //star.killOff();
    //    //    //Destroy(collision.gameObject);

    //    //    //Star += 1;

        GemAudio.Play();
        collision.GetComponent<Animator>().Play("gemkill");

    //    //    //StarNum.text = Star.ToString();

    }
        if (collision.tag == "Deadline")
        {
            Invoke("Restart", 1f);
        }
        //if (collision.tag == "Door")
        //{
        //    Invoke("Clear", 0.5f);
        //}

    }

    void Restart()
    {

        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void GemCount()
    {
        Gem += 1;
        GemNum.text = Gem.ToString();

        //if (Gem > 10)
        //{
        //    Gem = 10;
        //}
        //CollBar.CollMax = Gem;
    }

    public void CollictionCount(int Gem)
    {
        //sf.FlashScreen();
        count += Gem;

        if (count > 10)
        {
            count = 10;
        }
        CollBar.CollMax = count;

        //    //BlinkPlayer(blinks, time);
        //    //polygonCollider2D.enabled = false;
        //    // StartCoroutine(ShowPlayerHitBox());
        }
    
}
