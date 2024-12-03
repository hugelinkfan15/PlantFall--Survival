using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public bool gameOver;
    public bool timerDone;
    public TextMeshProUGUI gameOverText;

    public GameObject extrationPoint;
    // Start is called before the first frame update
    void Start()
    {
        timerDone = false;
        gameOverText.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerDone)
        {
            extrationPoint.SetActive(true);
            gameOverText.color = Color.red;
            gameOverText.text = "GET TO THE EXTRACTION POINT!";
        }
        if (gameOver)
        {
            Time.timeScale = 0.0f;
            gameOverText.color = Color.white;
            gameOverText.text = (PlayerHealth.GetHealth() > 0) ? "You Win!\n Press R to restart!" : "You Lose!\nPress R to restart!";

            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
