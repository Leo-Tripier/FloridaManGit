using System;
using UnityEngine;
using Random = UnityEngine.Random;
// author : Leo Tripier
namespace Script
{
    public class Level : MonoBehaviour 
    {
        public Room[,] level;
        public Level(int hauteur, int y_exit, int largeur, Room[,,,] stock)
        {
            
            int x = hauteur - 1;
            int y = 0;
            
            this.level = new Room[hauteur,largeur];
            bool up = false;
            bool down = true;
            bool left = true;
            bool right = false;

            int a = 0;
            int b;
            int c;
            int d = 0;

            Room actual;
            
            while ((x,y) != (0, largeur - 1))
            {
                up = false;
                if (x == hauteur - 1 && y != 0) {down = false;}
                if (y == 0) {left = false;}
                right = false;

                while (!(up || right))
                {
                    if (x != 0)
                    {
                        a = Random.Range(0, 10);
                        if (a >= 5)
                        {
                            up = true;
                        }
                    }
                    else
                    {
                        a = Random.Range(0, 5);
                    }

                    if (y != largeur - 1)
                    {
                        d = Random.Range(0, 10);
                        if (d >= 5)
                        {
                            right = true;
                        }
                    }
                    else
                    {
                        d = Random.Range(0, 5);
                    }
                }
            
                if (down)
                {
                    b = Random.Range(5, 10);
                }
                else
                {
                    b = Random.Range(0, 5);
                }

                if (left)
                {
                    c = Random.Range(5, 10);
                }
                else
                {
                    c = Random.Range(0, 5);
                }
                    

                if ((x,y) == (0,y_exit))
                {
                    actual = stock[a,b,c,d];

                    level[x, y] = actual;
                    left = actual.right;
                    down = level[x + 1, y].up;
                }
                else
                {

                    actual = stock[a,b,c,d];
                    level[x, y] = actual;
                    
                    left = actual.right;
                    if (x < hauteur - 1)
                    {
                        down = level[x + 1, y].up;
                    }
                }

                if (y == largeur - 1)
                {
                    x -= 1;
                    y = 0;
                }
                else
                {
                    y += 1;
                }
            }
        }
    }
}