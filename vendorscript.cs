using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vendorscript : MonoBehaviour
{
    public Inventory inv;

    private CircleCollider2D vendorcollider;

    public Collider2D playercollider;

    public GameObject store;
    // Start is called before the first frame update
    void Start()
    {
        vendorcollider = this.gameObject.GetComponent<CircleCollider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("floridaman"))
        {
            store.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("floridaman"))
        {
            store.gameObject.SetActive(false);
        }
    }
}
