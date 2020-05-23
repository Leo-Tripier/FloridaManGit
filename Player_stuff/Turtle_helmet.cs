using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle_helmet : MonoBehaviour
{
    public BoxCollider2D Hitbox;
    public int Defense_up;

    private void OnTriggerEnter(Collider other)
    {
        Stat player_stat = other.GetComponent<Stat>();
        if (player_stat != null)
        {
            player_stat.Defense += Defense_up;
            player_stat.Inventory.AddItem(7);
        }
        Destroy(gameObject);
    }
}
