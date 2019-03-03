using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGUI : MonoBehaviour
{
    private bool gameMenu = true;

    public GameObject menu;

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameMenu) {
                menu.SetActive(gameMenu);
                gameMenu = false;
            }
            else
            {
                menu.SetActive(gameMenu);
                gameMenu = true;
            }
        }
        
    }
}
