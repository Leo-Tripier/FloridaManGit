using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//FATOU
public class LostMenu : MonoBehaviour
{
    public GameObject menu;
    private GameObject player;
    private Stat stat;
    
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        stat = player.GetComponent<Stat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == false)
        {
            menu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
