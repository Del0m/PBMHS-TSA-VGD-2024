using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private void Start() // see if variables exist
    {
        if (!PlayerPrefs.HasKey(Option.textScroll.ToString()))
        {
            PlayerPrefs.SetFloat(Option.textScroll.ToString(), .05f);
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
    public void VolumeSetting(float value)
    {
        PlayerPrefs.SetFloat("volume", value);

        // update all audio objects with new sound
        FindObjectOfType<Audio>().AudioUpdate();
    }
    public void TextScrollSetting(float value)
    {
        PlayerPrefs.SetFloat("textScroll",( .025f + (value / 4)));
    }
}
