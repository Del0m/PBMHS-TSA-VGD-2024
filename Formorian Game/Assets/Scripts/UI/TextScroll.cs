using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextScroll : MonoBehaviour
{
    public TextMeshProUGUI text;
    void StartText()
    {
        StartCoroutine(UIController.TextScroll(text, .05f));
    }
    public void Start()
    {
        StartText();
    }
}
