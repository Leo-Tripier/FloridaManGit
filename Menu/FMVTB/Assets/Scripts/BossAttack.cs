using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FATOU
public class BossAttack : MonoBehaviour
{

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
