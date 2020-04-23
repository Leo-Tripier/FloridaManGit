using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// cette classe code la base de donnée d'items du jeu, elle doit être attachée à un GameObject vide auquel on ajoutera le tag "Database"
public class DataBase : MonoBehaviour
{
    public List<ItemClass> itemlist;

    private void Awake()
    {
        InitDataBase();
    }

    // les deux fonctions suivantes permettent d'accéder aux objets de la database grace a leur nom ou leur ID
    public ItemClass FindItem(int id) 
    {
        return itemlist.Find(item => item.id == id);
    }

    public ItemClass FindItem(string name)
    {
        return itemlist.Find(item => item.name == name);
    }
    
    // c'est ici que l'on ajoute a la main tous les objets que l'on souhaite en précisant leurs caractéristiques.
    void InitDataBase()
    {
        itemlist = new List<ItemClass>()
        {
            new ItemClass("empty", "nothing here",0,
                new Dictionary<string, int>
                {
                    // well that's empty
                }),
            new ItemClass("berd_soda","the final product of evil imperialism... restores health", 1,
                new Dictionary<string, int>
                {
                    {"health regen", 100},
                    {"price" ,30},
                }),
            new ItemClass("Hamburger", "The perfect food if you're in for death in your mid 40s", 2,
                new Dictionary<string, int>
                {
                    {"health regen", 99999},
                    {"price", 200}
                })
        };
    }
}
