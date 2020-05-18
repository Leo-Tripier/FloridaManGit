using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Daniel Miguel

public class Stat : MonoBehaviour
{
    public int HP;
    public int Defense;

    void TakeDamage(int damage, int knockback)
    {
        HP -= (damage - Defense / 4);
        if (HP == 0)
        {
            GameObject.Destroy(gameObject);
            // Game Over Screen
        }
    }
}
