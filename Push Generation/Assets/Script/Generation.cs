using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
// author : Leo Tripier
namespace Script
{
    public class Generation : MonoBehaviour
    {
        public Room[,,,] stock = new Room[3,3,3,3];
        public Level current;
        public int y_exit;
        public Generation()
        {
            int left = 0;
            int right = 0;
            int down = 0;
            int up = 0;
            Room actual;
            foreach (var scene in Directory.EnumerateFiles("Assets/Scenes/"))
            {
                actual = new Room((up <2),(down < 2), (left<2),(right <2),scene);
                stock[up, down, left, right] = actual;
                if (up < 2)
                {
                    up += 1;
                }
                else if (down < 2)
                {
                    down += 1;
                }
                else if (left < 2)
                {
                    left += 1;
                }
                else if (right < 2)
                {
                    right += 1;
                }
            }

            int hauteur = Random.Range(3, 10);
            int largeur = Random.Range(3, 10);
            y_exit = Random.Range(0, largeur);
            current = new Level(hauteur,y_exit,largeur,stock);
        }
        
        
    }
}