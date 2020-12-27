using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class gameOver : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void PlayGame() 
    {
        SceneManager.LoadScene("ekascene");
    }
 
    public void GoToMenu() 
    {
        SceneManager.LoadScene("menu");
    }

    public void ExitGame() 
    {
        Application.Quit();
    }
}