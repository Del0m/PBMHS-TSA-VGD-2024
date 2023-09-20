using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    private static bool gamePause;
    public static bool IsPaused
    {
        get { return gamePause; }
        set { gamePause = !gamePause; } 
    }

}

