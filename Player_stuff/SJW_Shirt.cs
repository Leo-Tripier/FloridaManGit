using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SJW_Shirt : MonoBehaviour
{
    public BoxCollider2D HitBox;

    private void OnTriggerEnter(Collider other)
    {
        Stat Player_Stat = other.GetComponent<Stat>();
        Player_Control player = other.GetComponent<Player_Control>();
        if (Player_Stat != null)
        {
            Player_Stat.Max_HP /= 2;
            Player_Stat.Inventory.AddItem(9);
            Bullet_Scriptt bullet = player.Projectile.GetComponent<Bullet_Scriptt>();
            if (bullet != null)
            {
                bullet.damage *= 2;
            }
        }
        Destroy(gameObject);
    }
}
