using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FATOU
public class Boss : MonoBehaviour
{

    public int vie = 500;
    public int damage = 3;
    public float speed = 3f;

    private Transform player;
    private Stat stat;
    private Rigidbody2D rb;
    private Animator anim;

    public bool flip = false;

    public bool isAttacking;
    private static readonly int Attacking = Animator.StringToHash("Attacking");

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stat = player.GetComponent<Stat>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        LookAtPlayer();

        if (Math.Abs(player.transform.position.x - transform.position.x) <= 3f)
        {
            anim.SetBool(Attacking, true);
            Attack();
        }
        else
        {
            anim.SetBool(Attacking, false);
            Following();
        }
        
        Following();
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;

        if (transform.position.x > player.position.x && !flip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f,0f);
            flip = true;
        }
        else if (transform.position.x < player.position.x && flip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            flip = false;
        }
    }

    public void GetHurt(int damage)
    {
        vie -= damage;

        if (vie <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    void Following()
    {
        if (Math.Abs(player.transform.position.y - transform.position.y) >= 3f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        
    }

    void Attack()
    {
        if (isAttacking & stat.alive)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            
            anim.SetBool(Attacking, true);
            stat.TakeDamage(damage);
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation & RigidbodyConstraints2D.FreezePositionY;
            
            anim.SetBool(Attacking, false);
        }
    }
}
