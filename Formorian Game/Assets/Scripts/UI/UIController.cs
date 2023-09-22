using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public static void ShowUI(Image ui)
    {
        ui.enabled = (true);
    }
    public static void HideUI(Image ui)
    {
        ui.enabled = (false);
    }
}
