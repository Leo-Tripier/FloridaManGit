using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// cette classe code les Objets items, base de la structure d'itemization
// il est fortement possible que d'autres attributs soient ajoutés dans le temps
public class ItemClass
{
    public string name;
    public string description;
    public Sprite sprite;
    public int id;
    public int count;
    public Dictionary<string, int> stats;
    

    public ItemClass(string name, string description, int id, Dictionary<string,int> stats)
    {
        this.name = name;
        this.description = description;
        this.id = id;
        sprite = Resources.Load<Sprite>(name);  // cette commande n'accède pas à un chemin mais seulement à un fichier à l'intérieur du dossier Assets/Resources
                                                // du projet unity. ici, il suffit de renommer les sprites dans le dossier par le nom qui leur est donné dans la database
                                                // pour qu'ils soient attribués.
        this.stats = stats;
        count = 1;
    }
}
