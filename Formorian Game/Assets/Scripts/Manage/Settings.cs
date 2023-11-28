using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private void Awake() // see if variables exist
    {
        if (!PlayerPrefs.HasKey(Option.textScroll.ToString()))
        {
            PlayerPrefs.SetFloat(Option.textScroll.ToString(), .15f);
        }
        if (!PlayerPrefs.HasKey(Option.volume.ToString()))
        {
            PlayerPrefs.SetFloat(Option.volume.ToString(), 1f);
        }
    }
    public enum Option
    {
        volume,
        textScroll,

    }

    public static float PullSetting(Option option) // pull setting from dict
    {
        return PlayerPrefs.GetFloat(option.ToString());
    }
}
