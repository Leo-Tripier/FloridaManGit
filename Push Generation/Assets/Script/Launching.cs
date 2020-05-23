using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class Launching : MonoBehaviour
    {
        public static int x_current = 0;
        public static int y_current = 0;
        public static Generation niveau = new Generation();
        public static ChangeRoom passage = new ChangeRoom();

        // Start is called before the first frame update
        void Start()
        {
            SceneManager.LoadScene(niveau.current.level[0, 0].name);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}