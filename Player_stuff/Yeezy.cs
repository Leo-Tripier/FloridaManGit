﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeezy : MonoBehaviour
{
   public BoxCollider2D HitBox;

   private void OnTriggerEnter(Collider other)
   { 
      Player_Control player = other.GetComponent<Player_Control>();
      if (player != null)
      {
         player.Inventory.AddItem(3);
      }
      Destroy(gameObject);
   }
}
