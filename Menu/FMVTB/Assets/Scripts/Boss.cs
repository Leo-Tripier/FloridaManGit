using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FATOU
public class Boss : MonoBehaviour
{

    public int vie = 500;
    public int damage = 5;
    public float speed = 5f;

    Transform player;

    public bool flip = false;

    public bool isAttacking;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        LookAtPlayer();
        Following();
        Attack();
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
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void Attack()
    {
        if (isAttacking)
        {
            gameObject.GetComponent<Animator>().SetBool(BossAttack.id, true);
            player.GetComponent<Stat>().HP -= damage;
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool(BossAttack.id, false);
        }
    }

}
