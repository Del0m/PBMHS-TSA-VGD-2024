using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableSign : Interactable
{
    public string text;
    public GameObject info;

    public override void OnInteract() // read dialogue to player
    {
        StartCoroutine(UIController.TextScroll(text, Settings.PullSetting(Settings.Option.textScroll)));

        hasInteracted = true;
    }
    public override void CanInteract(bool can) // what sign does when it is interactable with player
    {
        info.SetActive(can);
    }
}
