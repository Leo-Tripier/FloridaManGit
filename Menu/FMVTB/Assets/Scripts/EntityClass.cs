using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EntityClass : ScriptableObject
{
    public string name;
    
    public (int,int) hp; // premier int = max hp, deuxième = current hp
    public int lvl; // pas sûr que cette variable devienne utile
    public int attack;
    
    private bool dead;
    

    public EntityClass (int lvl, int attack, (int,int) hp, string name)
    {
        this.hp = hp;
        this.lvl = lvl;
        this.attack = attack;
        this.name = name;
    }
        
    // fonctions annexes :

    public void HpChange(int variation)
    {
        hp.Item2 += variation;
            
        if (hp.Item2 < 0 )
        {
            dead = true;
        }

        if (hp.Item2>hp.Item1)
        {
            hp.Item2 = hp.Item1;
        }
    }

    public void Attack(EntityClass ennemy)
    {
        if (ennemy.GetType() == typeof(Player))
        {
            (ennemy as Player).HpChange_No_OneShot(-attack);
        }
        else
        {
            ennemy.HpChange(-attack);
        }
    }
    
}
