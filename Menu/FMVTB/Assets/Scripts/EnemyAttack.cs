﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FATOU
public class EnemyAttack : MonoBehaviour
{
    public static int id;
    private void Start()
    {
        id = Animator.StringToHash("Attack");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            gameObject.GetComponent<Patrol>().isAttacking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        gameObject.GetComponent<Patrol>().isAttacking = false;
    }
}
