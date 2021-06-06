using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public float startTime;
    public float time;

    private Animator anim;
    private PolygonCollider2D collider2D;
    public AudioSource atkAudio;
    public Joystick joystick1;

    //private PlayerInputActions controls;

    //void Awake()
    //{
    //    controls = new PlayerInputActions();

    //    controls.GamePlay.Attack.started += ctx => Attack();
    //}

    //void OnEnable()
    //{
    //    controls.GamePlay.Enable();
    //}

    //void OnDisable()
    //{
    //    controls.GamePlay.Disable();
    //}

    //// Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if(joystick1.Vertical>0)
        //if(Input.GetButtonDown("Atk1"))
        {
            
            collider2D.enabled = true;
            anim.SetTrigger("attack1");
            atkAudio.Play();
            StartCoroutine(StartAttack());
            
        }
        if(joystick1.Horizontal>0)
        //if (Input.GetButtonDown("Atk2"))
        {
            collider2D.enabled = true;
            anim.SetTrigger("attack2");
            atkAudio.Play();
            StartCoroutine(StartAttack());
        }
    }

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(startTime);
        collider2D.enabled = true;
        StartCoroutine(disableHitBox());
    }

    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        collider2D.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}