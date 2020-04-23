using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Pathfinding.Examples;
using UnityEngine;
using UnityEngine.Serialization;

public class Patrol : MonoBehaviour
{
    public float speed;
    public int vie = 60;
    public int damage = 10;

    public bool goingRight = true;
    Vector3 placementGround;
    private GameObject newGround;
    public GameObject groundDetectLeft;

    public float stopDistance;
    private GameObject target;

    public bool flip = true;

    public bool isAttacking;

    private void Start()
    {
        placementGround = new Vector3(0f, transform.position.y, 0f);
        newGround = Instantiate(groundDetectLeft, placementGround,
            Quaternion.identity, gameObject.transform);

        target = GameObject.FindGameObjectWithTag("Player");

        gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }

    private void Update()
    {
        LookAtPlayer();

        if (Vector2.Distance(transform.position, target.transform.position) < 100f)
        {
            Following();
            PlayerAttack();
        }
        else if (Vector2.Distance(transform.position, target.transform.position) > 50f)
        {
            Patrolling();
        }
    }
    
    void PlayerAttack()
    {
    if (isAttacking)
    {
        gameObject.GetComponent<Animator>().SetBool(EnemyAttack.id, true);
        target.GetComponent<Stat>().HP -= damage;
    }
    else
    {
        gameObject.GetComponent<Animator>().SetBool(EnemyAttack.id, false);
    }
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;

        if (transform.position.x > target.transform.position.x && !flip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f,0f);
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
        if (Vector2.Distance(transform.position,target.transform.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    void Patrolling()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D solGauche = Physics2D.Raycast(newGround.transform.position, Vector2.down);

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
        if (vie <= 0 )
        {
            Destroy(gameObject);
        }
        else
        {
            vie -= damage;
        }
    }
}
