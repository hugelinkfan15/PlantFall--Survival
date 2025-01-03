using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseMenu : Singleton<PauseMenu>
{
    // Start is called before the first frame update

    public PlayerStats stats;
    public GameObject menu;
    public TextMeshProUGUI statsText;
    public static bool isPaused;

    void Start()
    {
        stats.statsBox = statsText;
        stats.Display();
        menu.SetActive(false);
        
        isPaused = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the menu is alreadt active when P is pressed by the user
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(menu.activeSelf)
            {
                resumeGame();
            }
            else
            {
                menu.SetActive(true);
                stats.Display();
                pauseGame();
            }
        }
    }

    /// <summary>
    /// Resumes the game by setting timescale to 1,removing the menu object, and setting isPaused to false
    /// </summary>
    public void resumeGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    /// <summary>
    /// "Pauses" the game by setting time scale to 0 to pause game psychics, and changes the public boolean isPaused to true so other scripts can access it 
    /// </summary>
    public void pauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }
}
