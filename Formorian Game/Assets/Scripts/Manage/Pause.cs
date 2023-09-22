using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject ui;
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
                UIController.UpdateUI(ui, !IsPaused); // check game pause state, change UI accordingly
            }
        }
        catch (System.Exception)
        {
            Debug.LogError("Must set UI variable");
            throw;
        }

    }
}

