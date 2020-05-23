using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_pill : MonoBehaviour
{
    public BoxCollider2D Hitbox;
    public int Hp_up;

    private void OnTriggerEnter(Collider other)
    {
        Stat player_stat = other.GetComponent<Stat>();
        if (player_stat != null)
        {
            player_stat.Max_HP += Hp_up;
            player_stat.Inventory.AddItem(6);
        }
        Destroy(gameObject);
    }
}
