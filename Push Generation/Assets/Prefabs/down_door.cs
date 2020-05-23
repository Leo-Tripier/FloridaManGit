using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script;

public class down_door : MonoBehaviour
{
    public BoxCollider2D door;
    
    private void OnTriggerEnter(Collider other)
    {
        Player_Control player = other.GetComponent<Player_Control>();
        if (player != null)
        {
            Launching.x_current -= 1;
            Launching.passage.LoadRoom(Launching.niveau, Launching.x_current ,Launching.y_current);
        }
    }
}
