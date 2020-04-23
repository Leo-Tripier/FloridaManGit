using System;
using UnityEngine;
using static UnityEngine.GameObject;

public class Player : EntityClass
{
    public int defense;
    public float jump_speed = 10f;
    public float run_speed = 5f;
    public float gravity_modifier = 0.001f;
        
    DataBase data = new DataBase();
    public Inventory inventory;
        
    public Player(int lvl, int attack, (int,int) hp, string name) : base(lvl,  attack,  hp, name)
    {
        this.name = "Player";
        this.hp = (500, 500);
        this.lvl = 1;
        this.attack = attack;
        ItemClass empty = data.FindItem(0);
    }

        
        
    public void HpChange_No_OneShot(int variation)
    {
        if (variation < 0 && variation > -hp.Item2 && hp.Item2 > 10)
        {
            hp.Item2 = 1;
        }

        else
        {
            HpChange(variation/defense);
        }
    }
}