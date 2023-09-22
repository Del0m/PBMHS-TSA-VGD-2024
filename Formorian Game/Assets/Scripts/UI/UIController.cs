using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public static void UpdateUI(GameObject ui, bool enable) // shows ui or hides ui
    {
        ui.SetActive(enable);
    }
}
