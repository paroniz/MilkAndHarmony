using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void PlayGame() 
    {
        SceneManager.LoadScene("ekascene");
    }
 
    public void Options() 
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        
    }
    
    public void OptionsReturn() 
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
 
    public void ExitGame() 
    {
        Application.Quit();
    }
}