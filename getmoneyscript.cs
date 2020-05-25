using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class getmoneyscript : MonoBehaviour
{
    public Inventory inv;

    private Random r;
    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        r = new Random();
    }

    // Update is called once per frame
    public void OnButtonPress()
    {
        inv.VaryMoney(r.Next(0,10),r.Next(0,11)/10);
    }
}
