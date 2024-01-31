//Del0m
// purpose of program is to publically call static functions to modify UI on screen.
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    static bool dialogueRunning; // check to see if dialogue is running
    public static void UpdateUI(GameObject ui, bool enable) // shows ui or hides ui
    {
        ui.SetActive(enable);
    }
    public static void XScaleUI(GameObject ui, float scale)
    {
        var uiObject = ui.GetComponent<Image>();
        uiObject.rectTransform.sizeDelta = new Vector2(scale, uiObject.rectTransform.sizeDelta.y);
    }
    public static void UIPopUp(GameObject ui, bool enable) // purpose is to pop up UI using scales to hide them.
    {
        if(enable) // show ui
        {
            ui.transform.localScale = new Vector3(1, 1, 1);
            return;
        }
        ui.transform.localScale = new Vector3(0, 1, 1); // prevent it from being seen by setting scale to 0.

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
        // check to see if dialogue is running
        if(dialogueRunning)
        {
            yield break;
        }
        // run dialogue
        dialogueRunning = true;

        var dialogue = text;
        text = string.Empty;

        var dialogueBox = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<TextMeshProUGUI>();
        dialogueBox.text = text;

        dialogueBox.GetComponentInParent<Image>().enabled = true;

        // loop to add dialogue onto the screen
        for (int i = 0; i < dialogue.Length; i++)
        {
            text += dialogue[i];

            dialogueBox.text = text;
            yield return new WaitForSeconds(time);
        }
        yield return new WaitForSeconds(2f);
        ClearDialogue();

        dialogueRunning = false;

    }
    public static void ClearDialogue() // clear dialogue box
    {
        var dialogueBox = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<TextMeshProUGUI>();
        dialogueBox.text = string.Empty;

        dialogueBox.GetComponentInParent<Image>().enabled = false;
    }
}
