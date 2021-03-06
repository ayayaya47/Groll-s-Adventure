using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneA : Enemy
{
    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform movePos;
    public Transform leftpoint, rightpoint;

    //public float Speed;
    //private float leftx, rightx;


    //private bool Faceleft = true;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
    }

    // Update is called once per frame
    public void Update()
    {
        //调用父类的Update()方法
        base.Update();

        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftpoint.position.x, rightpoint.position.x), Random.Range(leftpoint.position.y, rightpoint.position.y));
        return rndPos;
    }


}
