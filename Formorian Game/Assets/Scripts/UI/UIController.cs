//Del0m
// purpose of program is to publically call static functions to modify UI on screen.
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
    public static void XScaleUI(GameObject ui, float scale)
    {
        var uiObject = ui.GetComponent<Image>();
        uiObject.rectTransform.sizeDelta = new Vector2(scale, uiObject.rectTransform.sizeDelta.y);
    }
}
