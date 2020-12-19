using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class GameOverCode : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void playGame() 
    {
        SceneManager.LoadScene("ekascene");
    }
 
    public void goToMenu() 
    {
        SceneManager.LoadScene("menu");
    }
    public void exitGame() 
    {
        Application.Quit();
    }
}