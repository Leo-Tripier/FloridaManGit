using System;
using System.IO;
using UnityEngine;
// author : Leo Tripier
namespace Script
{
    public class Room : MonoBehaviour
    {
        public bool up;
        public bool down;
        public bool left;
        public bool right;
        public string name;

        public Room(bool up, bool down, bool left, bool right, string name)
        {
            this.up = up;
            this.down = down;
            this.left = left;
            this.right = right;
            this.name = name;
        }
    }
}