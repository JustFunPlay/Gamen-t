using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnESCmenuPressed: MonoBehaviour
{
    public GameObject escMenu;
    public GameObject mainMenu;
    public bool escMenuBool;
    void OnESCMenu(InputValue value)
    {
        if (escMenuBool == false)
        {

            escMenuBool = true;
            escMenu.SetActive(true);

            Time.timeScale = 0.0000001f;


        }
        else
        {
            if (escMenuBool == true)
            {
                escMenuBool = false;
                escMenu.SetActive(false);
                Time.timeScale = 1f;
            }

        }
        print("Pressed ESC");
    }
}
