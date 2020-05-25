using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simon Zakeyh
public class musicscript : MonoBehaviour
{
    public GameObject character;
    
    public AudioSource chill_source;

    public AudioSource combat_source;

    private bool combat;

    private Stat stats;

    private int lasthealth;

    private int nodamage;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("floridaman");
        stats = character.GetComponent<Stat>();
        combat = false;
        nodamage = 0;
        lasthealth = stats.HP;
        chill_source.Play();
        InvokeRepeating(nameof(CheckIfInCombat),1,1);
    }

    
    //this method will be invoked every second, its role is to check wether the main character is in combat
    void CheckIfInCombat()
    {
        int newhealth = stats.HP;
        if (newhealth < lasthealth && !combat)
        {
            PlayCombat();
        }
        if (newhealth >= lasthealth && combat)
        {
            PlayChill();
        }

        if (newhealth < lasthealth)
        {
            nodamage = 0;
        }

        lasthealth = stats.HP;
    }

    void PlayCombat()
    {
        chill_source.Pause();
        combat_source.Play();
        combat = true;
        nodamage = 0;
    }

    void PlayChill()
    {
        nodamage += 1;
        if (nodamage >= 15 && combat)
        {
            combat_source.Pause();
            chill_source.Play();
            combat = false;
            nodamage = 0;
        }
    }
    

    
}
