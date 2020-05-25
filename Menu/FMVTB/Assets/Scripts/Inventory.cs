using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Auteur = Simon Zakeyh
public class Inventory : MonoBehaviour
{
    public GameObject slots;
    
    public List<GameObject> slotlist = new List<GameObject>();
    
    public List<ItemClass> inventory = new List<ItemClass>();

    private DataBase data;

    private int x = -127;
    private int y = 129;
    // Start is called before the first frame update
    void Start()
    {
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
                
                //Debug.Log(inventory[slotcount].name);  //check si l'inventaire est rempli d'objets "empty"
                
                x += 65;                                      
                slotcount++;
                
            }

            y -= 65;
            x = -127;                                     // on modifie les variables x et y pour que les slots ne soient pas affichés superposés
        }
        
        AddItem(2);
        Debug.Log(inventory[0].name); // teste si l'objet a bien été ajouté
        Debug.Log(inventory[0].sprite); //teste si la ressource a été chargée
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

    public bool IsInInventory(ItemClass item)
    {
        int l = item.count;
        int count = 0;
        while (count < l && inventory[count] != item)
        {
            count++;
        }

        return !(count >= l);
    }
}

