using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class ChangeRoom : MonoBehaviour
    {
        public void LoadRoom(Generation set, int x_current, int y_current)
        {
            SceneManager.LoadScene(set.current.level[x_current, y_current].name);
        }
    }
}