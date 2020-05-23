using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public BoxCollider2D Collider2D;
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(deal_damage(other));
    }

    IEnumerator deal_damage(Collider other)
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
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}
