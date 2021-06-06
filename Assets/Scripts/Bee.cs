using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public LayerMask ground;
    public Collider2D coll;
    public float speed;
    public float jumpforce;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Death()
    {
        Destroy(gameObject);

    }
    public void JumpOn()
    {
        anim.SetTrigger("death");

    }
}
