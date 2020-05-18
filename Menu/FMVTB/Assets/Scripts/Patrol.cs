using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Pathfinding.Examples;
using UnityEngine;
using UnityEngine.Serialization;

//FATOU
public class Patrol : MonoBehaviour
{
    public float speed;
    public int vie = 60;
    public int damage = 10;

    public bool goingRight = true;
    Vector3 placementGround;
    public GameObject CeilingDetect;
    public GameObject groundDetectLeft;
    private BoxCollider2D bc;

    public Animator anim;
    public Rigidbody2D rb;
    private GameObject target;

    public bool flip = true;

    public bool isAttacking;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        gameObject.GetComponent<SpriteRenderer>().flipX = true;

        bc = gameObject.GetComponent<BoxCollider2D>();

        rb = gameObject.GetComponent<Rigidbody2D>();

        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {

        if (target.transform.position.y - transform.position.y <= 5f)
        {
            if (goingRight)
            {
                if (target.transform.position.x - transform.position.x <= -0f && target.transform.position.x - transform.position.x >= 5f)
                {
                    PlayerAttack();
                }
                else
                {
                    Patrolling();
                }
            }
            else
            {
                if (target.transform.position.x - transform.position.x >= 0f && target.transform.position.x - transform.position.x <= 5f)
                {
                    PlayerAttack();
                }
                else
                {
                    Patrolling();
                }
            }
        }
        else
        {
            Patrolling();
        }
        
    }

    void PlayerAttack()
    {
        LookAtPlayer();
        
        if (isAttacking)
        {
            rb.velocity = new Vector2(0f,0f);
            anim.SetBool(EnemyAttack.id, true);
            target.GetComponent<Stat>().HP -= damage;
        }
        else
        {
            anim.SetBool(EnemyAttack.id, false);
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

    void Following()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
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
