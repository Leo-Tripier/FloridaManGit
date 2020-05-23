using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storm_trooper_helmet : MonoBehaviour
{
    public BoxCollider2D hitbox;
    public GameObject lazer_projectile;

    private void OnTriggerEnter(Collider other)
    {
        Player_Control player = other.GetComponent<Player_Control>();
        if (player != null)
        {
            player.Projectile2 = lazer_projectile;
            player.Inventory.AddItem(8);
        }
        Destroy(gameObject);
    }
}
