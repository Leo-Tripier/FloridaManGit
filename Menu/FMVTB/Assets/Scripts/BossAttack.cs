using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FATOU
public class BossAttack : MonoBehaviour
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
            gameObject.GetComponent<Boss>().isAttacking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            gameObject.GetComponent<Boss>().isAttacking = false;
        }
    }
}
