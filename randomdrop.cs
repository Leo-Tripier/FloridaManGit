using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

// Auteur = Simon Zakeyh

public class randomdrop : MonoBehaviour
{
    public Inventory inventory;
    private DataBase data;
    private int range;
    private Random r;
    public void Start()
    {
        data = GameObject.FindGameObjectWithTag("Database").GetComponent<DataBase>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        r = new Random();
        range = data.Itemlist.Count;
        Debug.Log(range);
    }

    public void OnButtonPress()
    {
        inventory.AddItem(r.Next(0, range));
        Debug.Log("random drop given");
    }
}
