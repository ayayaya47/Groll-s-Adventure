using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection_kill : MonoBehaviour
{

    //private Rigidbody2D rb;
    //private Animator anim;
    //public Collider2D coll;
    

    // Start is called before the first frame update
    void Start()
    {
        
        //rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        //coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Death()
    {
        
        FindObjectOfType<PlayerControler>().StarCount();

        Destroy(gameObject);
        
    }

    //public void killOff()
    //{
        
    //    Destroy(gameObject);
    //}
    
}
