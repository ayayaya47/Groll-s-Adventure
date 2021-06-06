using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemKill : MonoBehaviour
{

    //private Rigidbody2D rb;
    //private Animator anim;
    //public Collider2D coll;
    //public int count;//血量
    //public int blinks;

    // Start is called before the first frame update
    void Start()
    {
        //CollBar.CollMax = count;
        //CollBar.CollCurrent = count;
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

        FindObjectOfType<PlayerControler2>().GemCount();

        Destroy(gameObject);

    }

    //public void CollictionCount(int collnum)
    //{
    //    //sf.FlashScreen();
    //    count += collnum;

    //    if (count > 10)
    //    {
    //        count = 10;
    //    }
    //    CollBar.CollMax = count;
        
    //    //BlinkPlayer(blinks, time);
    //    //polygonCollider2D.enabled = false;
    //    // StartCoroutine(ShowPlayerHitBox());
    //}

    //public void killOff()
    //{

    //    Destroy(gameObject);
    //}

}
