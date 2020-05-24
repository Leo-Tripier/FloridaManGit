using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public BoxCollider2D Collider2D;
    public int damage;

    private void Start()
    {
        StartCoroutine(Shot());
    }

    IEnumerator Shot()
    {
        yield return new  WaitForSeconds(0.25f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Patrol info = other.GetComponent<Patrol>();
        if (info != null)
        {
            info.GetHurt(damage);
        }

        Boss boss = other.GetComponent<Boss>();
        if (boss != null)
        {
            boss.GetHurt(damage);
        }
        damage = 0;
    }
}
