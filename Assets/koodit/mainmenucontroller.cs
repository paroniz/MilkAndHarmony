using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class mainmenucontroller : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void playGame() 
    {
        SceneManager.LoadScene("ekascene");
    }
 
    public void options() 
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        
    }
    
    public void optionsreturn() 
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        
    }
 
    public void exitGame() 
    {
        Application.Quit();
    }
}