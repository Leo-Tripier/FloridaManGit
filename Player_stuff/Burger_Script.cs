using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger_Script : MonoBehaviour
{
    public int nutritional_value;
    public BoxCollider2D hit_box;

    private void OnTriggerEnter(Collider other)
    {
        Stat player_stat = other.GetComponent<Stat>();
        if (player_stat != null)
        {
            player_stat.Heal(nutritional_value);
        }
        Destroy(gameObject);
    }
}
