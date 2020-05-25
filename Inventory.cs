using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Internal.Experimental.UIElements;
using UnityEngine.UI;
// Auteur = Simon Zakeyh
public class Inventory : MonoBehaviour
{
    public int coins;

    public int currency;
    
    public GameObject slots;

    public List<GameObject> slotlist = new List<GameObject>();
    
    public List<ItemClass> inventory = new List<ItemClass>();

    private DataBase data;

    private float x;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        var position = this.gameObject.transform.position;
        var scale = this.gameObject.transform.lossyScale;
        x = -381;
        y = 175;
        data = GameObject.FindGameObjectWithTag("Database").GetComponent<DataBase>();
        int slotcount = 0;
        for (int i = 0; i < 5; i++) // cette double boucle remplit l'inventaire d'objets vides, et affiche un inventaire vide
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject slot = Instantiate(slots, this.gameObject.transform, true); // créé le slot dans le jeu
                slot.GetComponent<RectTransform>().localPosition = new Vector2(x,y); // donne une position au slot sur l'écran
                slot.GetComponent<SlotScript>().index = slotcount; // attribue au slot sa place dans linventaire (de gauche à droite puis de haut en bas)
                slot.name = "Slot [ " + i + " ; " + j + " ]"; // donne un joli nom reconnaissable au slot dans unity
                slotlist.Add(slot);                           // ajoute le slot a la liste des slots
                inventory.Add(data.Itemlist[0]);              // le slot contient initialement un objet vide
                
                Debug.Log(inventory[slotcount].name);  //check si l'inventaire est rempli d'objets "empty"
                
                x += 575*scale.x;                                      
                slotcount++;
                
            }

            y -= 125*scale.y;
            x = -381; // on modifie les variables x et y pour que les slots ne soient pas affichés superposés
        }
        coins = 0;
        currency = 0;
    }

    public void AddItem(int id) //ajoute l'item avec l'id spécifié à l'inventaire 
    {
        int i = 0;
        while ( i < data.Itemlist.Count && data.Itemlist[i].id != id )
        {
            i++;
        }
        ItemClass item = data.Itemlist[i];
        ReplaceEmptyWith(item);
       
    }

    private int ReplaceEmptyWith(ItemClass item) // remplace le premier objet vide par l'objet spécifié
    {
        int i = 0;
        while (i < inventory.Count && inventory[i].id != 0)
        {
            i++;
        }

        if (i< inventory.Count)
        {
            inventory[i] = item;
            Debug.Log("index to add" + i);
            return i;

        }
        else
        {
            return -1;
        }
    }

    public bool IsInInventory(string name)
    {
        int l = inventory.Count;
        int count = 0;
        while (count < l && inventory[count].name != name)
        {
            count++;
        }

        return !(count >= l);
    }

    public bool IsInInventory(int id)
    {
        int l = inventory.Count;
        int count = 0;
        while (count < l && inventory[count].id != id)
        {
            count++;
        }

        return !(count >= l);
    }

    public void VaryMoney(int varcoin, int varcurrency)
    {
        coins += varcoin;
        currency += varcurrency;
    }
}
