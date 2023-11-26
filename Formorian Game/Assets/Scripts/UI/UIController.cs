//Del0m
// purpose of program is to publically call static functions to modify UI on screen.
using System.Collections;
using TMPro;
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

    // text scrolling
    public static IEnumerator TextScroll(TextMeshProUGUI text, float time)
    {
        var dialogue = text.text;
        text.text = string.Empty;

        // loop to add dialogue onto the screen
        for(int i = 0; i < dialogue.Length; i++)
        {
            text.text += dialogue[i];
            yield return new WaitForSeconds(time);
        }
    }
    public static IEnumerator TextScroll(string text, float time)
    {
        var dialogue = text;
        text = string.Empty;

        var dialogueBox = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<TextMeshProUGUI>();
        // loop to add dialogue onto the screen
        for (int i = 0; i < dialogue.Length; i++)
        {
            text += dialogue[i];

            dialogueBox.text = text;
            yield return new WaitForSeconds(time);
        }
        yield return new WaitForSeconds(2f);
        ClearDialogue();
    }
    public static void ClearDialogue() // clear dialogue box
    {
        var dialogueBox = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<TextMeshProUGUI>();
        dialogueBox.text = string.Empty;

    }
}
