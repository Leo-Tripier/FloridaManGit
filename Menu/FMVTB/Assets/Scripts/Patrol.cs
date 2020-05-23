using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

//FATOU
public class Patrol : MonoBehaviour
{
    public float speed;
    public int vie = 30;
    public int damage = 3;

    public bool goingRight = true;
    public GameObject groundDetectLeft;

    public Animator anim;
    public Rigidbody2D rb;
    private GameObject target;
    private Stat stat;

    public bool flip = true;

    public bool isAttacking;
    private static readonly int Attack = Animator.StringToHash("Attack");

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        gameObject.GetComponent<SpriteRenderer>().flipX = true;

        rb = gameObject.GetComponent<Rigidbody2D>();

        anim = gameObject.GetComponent<Animator>();

        stat = target.GetComponent<Stat>();
    }

    private void Update()
    {

        if (Math.Abs(target.transform.position.y - transform.position.y) <= 3f)
        {
            if (Math.Abs(target.transform.position.x - transform.position.x) <= 5f)
            {
                LookAtPlayer();
                anim.SetBool(Attack, true);
                
                PlayerAttack();
            }
            else
            {
                anim.SetBool(Attack, false);
                Patrolling();
            }
        }
        else
        {
            anim.SetBool(Attack, false);
            Patrolling();
        }
        
    }

    void PlayerAttack()
    {
        LookAtPlayer();
        
        if (isAttacking)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            anim.SetBool(Attack, true);

            stat.TakeDamage(damage);
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation & RigidbodyConstraints2D.FreezePositionY;
            anim.SetBool(Attack, false);
        }
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;

        if (transform.position.x > target.transform.position.x && !flip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            flip = true;
        }
        else if (transform.position.x < target.transform.position.x && flip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            flip = false;
        }
    }

    void Patrolling()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D solGauche = Physics2D.Raycast(groundDetectLeft.transform.position, Vector2.down, 2f);

        if (solGauche.collider == false)

        {
            if (goingRight)
            {
                transform.eulerAngles = new Vector3(0,-180,0);
                goingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0,0,0);
                goingRight = true;
            }
        }

    }
    public void GetHurt(int damage)
    {
        if (vie <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            vie -= damage;
        }
    }
}
