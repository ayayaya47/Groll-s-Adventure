using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    public float speed, jumpForce;
    public Transform groundCheck;
    public LayerMask ground;
    public LayerMask ladder;
    public AudioSource starAudio;
    public float climbSpeed;
    public Joystick joystick;

    public int Star;

    public Text StarNum;


    public bool isHurt;

    public bool isGround, isJump,isFall, isLadder, isClimbing;

    bool jumpPressed;
    int jumpCount;
    bool climbPressed;

    private float playerGravity;

    
    private Vector2 move;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Vertical>0.5f && jumpCount > 0)
        //if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;
        }
        if (Input.GetButtonDown("climb"))
        {
            climbPressed = true;
        }
    }


    private void FixedUpdate()
    {

        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        isLadder = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ladder);


        //GroundMovement();
        Jump();

        if (!isHurt)
        {
            GroundMovement();
        }

        SwitchAnim();
       // CheckLadder();
        
    }

    //void CheckLadder()
    //{
    //    isLadder = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ladder);
    //    //Debug.Log("isLadder:" + isLadder);
    //}

    void GroundMovement()
    {
        float horizontalMove = joystick.Horizontal;
        //float horizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        if (horizontalMove > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        if (horizontalMove < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
    }

    void Jump()
    {
        if (isGround)
        {
            jumpCount = 2;
            isJump = false;
        }
        if (jumpPressed && isGround)
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
        else if (jumpPressed && jumpCount > 0 && isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
    }


    void SwitchAnim()
    {
        anim.SetFloat("running", Mathf.Abs(rb.velocity.x));


        anim.SetBool("idle", false);
        if (rb.velocity.y < 0.1f && !coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", true);
        }
        if (!isGround && rb.velocity.y > 0)
        {
            anim.SetBool("jumping", true);
        }
        else if (rb.velocity.y < 0)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);

        }
        if (isHurt)
        {
            anim.SetBool("hurt", true);
            anim.SetFloat("running", 0);

            if (Mathf.Abs(rb.velocity.x) < 0.1f)
            {
                anim.SetBool("hurt", false);
                anim.SetBool("idle", true);
                isHurt = false;
            }
        }
        if (isGround)
        {
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
        }
    }

    void Climb()
    {
        float moveY = Input.GetAxis("Vertical");

        if (isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveY * climbSpeed);
            isJump = false;
        }

        if (isLadder)
        {
            if (moveY > 0.5f || moveY < -0.5f)
            {
                anim.SetBool("jumping", false);
                
                anim.SetBool("climbing", true);
                rb.velocity = new Vector2(rb.velocity.x, moveY * climbSpeed);
                rb.gravityScale = 0.0f;
            }
            else
            {
                if (isJump || isFall)
                {
                    anim.SetBool("climbing", false);
                }
                else
                {
                    anim.SetBool("climbing", false);
                    rb.velocity = new Vector2(rb.velocity.x, 0.0f);

                }
            }
        }
        else
        {
            anim.SetBool("climbing", false);
            rb.gravityScale = playerGravity;
        }

        if (isLadder && isGround)
        {
            rb.gravityScale = playerGravity;
        }

        //Debug.Log("myRigidbody.gravityScale:"+ myRigidbody.gravityScale);
    }


    //碰撞触发器
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //收集物品
        if (collision.tag == "Collection")
        {
            //Collection_kill star = collision.gameObject.GetComponent < Collection_kill >();

            //star.killOff();
            //Destroy(collision.gameObject);

            //Star += 1;
            
            starAudio.Play();
            collision.GetComponent<Animator>().Play("starkill");
            
            //StarNum.text = Star.ToString();

        }
        if (collision.tag == "Deadline")
        {
            Invoke("Restart", 1f);
        }
        if (collision.tag == "Door")
        {
            Invoke("Clear", 0.5f);
        }

    }

   

    //消灭敌人(判断掉落时消灭）
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
            Bee bee = collision.gameObject.GetComponent<Bee>();

            if (collision.gameObject.tag == "Enemy")

            {
                if (anim.GetBool("falling"))
                {
                    bee.JumpOn();


                    //            // Destroy(collision.gameObject);

                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);

                    anim.SetBool("jumping", true);//反弹起跳
                }

                else if (transform.position.x < collision.gameObject.transform.position.x)
                {

                    rb.velocity = new Vector2(-6, rb.velocity.y);
                    isHurt = true;
                }
                else if (transform.position.x > collision.gameObject.transform.position.x)
                {
                    rb.velocity = new Vector2(6, rb.velocity.y);
                    isHurt = true;
                }
            }
        
    //撞到后击飞
     }



    void Restart()
    {

        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    //void Clear()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}

    public void StarCount()
    {
        Star += 1;
        StarNum.text = Star.ToString();
        
    }
   
}

