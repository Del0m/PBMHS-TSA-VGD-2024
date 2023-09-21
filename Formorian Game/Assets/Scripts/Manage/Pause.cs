using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Image ui;
    private static bool gamePause;
    public static bool IsPaused
    {
        get { return gamePause; }
        set 
        { 
            gamePause = !gamePause;
        } 
    }
    public void Menu(InputAction.CallbackContext ctx) // enable menu
    {
        try
        {
            if (ctx.performed)
            {
                if (gamePause) // check field, getset meant to be changed
                {
                    UIController.HideUI(ui);
                    return;
                }
                UIController.ShowUI(ui);
            }
        }
        catch (System.Exception)
        {
            Debug.LogError("Must set UI variable");
            throw;
        }

    }
}

