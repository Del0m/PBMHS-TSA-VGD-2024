using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCommands : MonoBehaviour
{
    public string scene;
    public void TransitionScene()
    {
        SceneManager.LoadScene(scene);
    }
}
