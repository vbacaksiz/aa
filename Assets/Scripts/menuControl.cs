using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{
    public void newGame()
    {
        PlayerPrefs.DeleteAll();
        startGame();
    }

    public void startGame()
    {
        int savedLevel = PlayerPrefs.GetInt("save");
        if(savedLevel == 0)
        {
            SceneManager.LoadScene(savedLevel + 1);
        }
        else
        {
            SceneManager.LoadScene(savedLevel);
        }
    }
    public void exit()
    {
        Application.Quit();
    }
    
}
