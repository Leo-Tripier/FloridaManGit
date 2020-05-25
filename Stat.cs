    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Daniel Miguel

public class Stat : MonoBehaviour
{
    public int HP;
    public int Max_HP;
    public int Defense;
    public bool can_be_damaged;
    public Inventory Inventory;

    private void Start()
    {
        Defense = 0;
        HP = Max_HP;
        can_be_damaged = true;
    }

    public void TakeDamage(int damage)
    {
        if (can_be_damaged)
        {
            HP -= (damage - Defense / 4);
            if (HP == 0)
            {
                gameObject.SetActive(false);
                // Game Over Screen
            }

            can_be_damaged = false;
            can_be_damaged = true;
        }
    }

    public void Heal(int heal)
    {
        HP += heal;
        if (HP >= Max_HP)
        {
            HP = Max_HP;
        }
    }
}
