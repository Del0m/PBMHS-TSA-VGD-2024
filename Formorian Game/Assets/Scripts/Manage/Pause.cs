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
        set { gamePause = value; }
    }
    public delegate void PauseCallback(bool pause);
    public static event PauseCallback GamePause;
}

