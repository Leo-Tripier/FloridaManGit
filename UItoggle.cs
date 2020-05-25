using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Internal.Experimental.UIElements;
using UnityEngine.UI;
// simon zakeyh
//this script is for toggling inventory display
public class UItoggle : MonoBehaviour
{
    public GameObject Panel;
    private bool is_inventory_showing;


    public void Start()
    {
        is_inventory_showing = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            is_inventory_showing = !is_inventory_showing;
            ToggleInventory();
        }
    }


    public void ToggleInventory()
    {
        Panel.gameObject.SetActive(is_inventory_showing);
    }
}
