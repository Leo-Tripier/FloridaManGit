using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class N_pass : MonoBehaviour
{
    public BoxCollider2D HitBox;
    public GameObject Gros_Projectile;

    private void OnTriggerEnter(Collider other)
    {
        Player_Control player = other.GetComponent<Player_Control>();
        if (player != null)
        {
            player.Projectile = Gros_Projectile;
            player.Inventory.AddItem(5);
        }
        Destroy(gameObject);
    }
}
