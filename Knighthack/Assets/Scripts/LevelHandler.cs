using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    private bool gameMenu = false;

    public GameObject menu;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           
        }
    }


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
