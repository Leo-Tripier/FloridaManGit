using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
// simon zakeyh
public class moneydisplay : MonoBehaviour
{
    public Text money;

    public Text currency;

    public Inventory inv;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (inv)
        {
            money.text = Convert.ToString(inv.coins);
            currency.text = Convert.ToString(inv.currency);
        }
    }
}
