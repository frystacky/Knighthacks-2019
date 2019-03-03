using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public void ToLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
  
    public void QuiGame()
    {
        Application.Quit();
    }

}
