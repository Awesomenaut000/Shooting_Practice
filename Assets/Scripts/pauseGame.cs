using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseGame : MonoBehaviour
{
    GameObject pauseMenu;
    GameObject crosshair;
    private bool crosshairActive = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("pauseButton");
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.GamePaused)
            {
                GameManager.GamePaused = false;
                Time.timeScale = 1;
            }

            else if(!GameManager.GamePaused)
            {
                GameManager.GamePaused = true;
                Time.timeScale = 0;
            }
                
        }

        //if game is paused
        if (Time.timeScale == 0 && crosshairActive)
        {
            pauseMenu.SetActive(true);
            crosshair.SetActive(false);
            crosshairActive = false;
        }

        //if game isn't paused
        else if(Time.timeScale == 1 && !crosshairActive)
        {
            pauseMenu.SetActive(false);
            crosshair.SetActive(true);
            crosshairActive = true;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        GameManager.GamePaused = false;
    } 
}
