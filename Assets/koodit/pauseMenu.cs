using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour 
{
    public GameObject pausedMenu;
    public GameObject panel;
    public GameObject canvas;
    private GameObject hero;
    public static bool paused = false;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) //&& (!canvas.active))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        //hero = GameObject.FindWithTag("hero");
    }

    public void Resume()
    {
        pausedMenu.SetActive(false);
        panel.SetActive(true);
        Time.timeScale = 1f;
        paused = false;  
            Cursor.visible = false;
    }

    void Pause ()
    {
        pausedMenu.SetActive(true);
        panel.SetActive(false);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Quit ()
    {
        SceneManager.LoadScene("Menu");
    }

    public void NewGame ()
    {
        SceneManager.LoadScene("FirstSmallRoom");
    }
}