using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auteur = Simon Zakeyh

// cette classe code la base de donnée d'items du jeu, elle doit être attachée à un GameObject vide auquel on ajoutera le tag "Database"
public class DataBase : MonoBehaviour
{
    private List<ItemClass> itemlist;

    public List<ItemClass> Itemlist
    {
        get => itemlist;
    }

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
            new ItemClass("berd soda","the final product of evil imperialism... restores health", 1,
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
                }),
            new ItemClass("Yeezys", "lightest shoes in the west", 3,
                new Dictionary<string, int>
                {
                    {"triple jump", 1},
                    {"price", 500}
                }),
            new ItemClass("podcaster shoes", "you are now fast as f", 4,
                new Dictionary<string, int>
                {
                    {"dash", 1},
                    {"price", 200}
                }),
            new ItemClass("nice word pass", "something is growing inside of you", 5,
                new Dictionary<string, int>
                {
                    {"big projectiles", 1},
                    {"price", 300}
                }),
            new ItemClass("blue pill", "go as hard as you can", 6,
                new Dictionary<string, int>
                {
                    {"max health", 60},
                    {"price", 150}
                }),
            new ItemClass("turtle helm", "I didn't poach this !", 7,
                new Dictionary<string, int>
                {
                    {"defense", 10},
                    {"price", 200}
                }),
            new ItemClass("high tech helm", "pew, pew", 8,
                new Dictionary<string, int>
                {
                    {"projectile", 2},
                    {"price", 300}
                }),
            new ItemClass("SJW shirt", "that's a lot of damage !", 9,
                new Dictionary<string, int>
                {
                    {"2xdamage", 1},
                    {"max health", -100}
                })
        };
    }
}
