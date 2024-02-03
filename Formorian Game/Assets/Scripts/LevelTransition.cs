using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class LevelTransition : MonoBehaviour
{
    public TimelineAsset cutscene;
    public PlayableDirector director;
    public string newScene;

    bool playing;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !playing)
        {
            director.Play(cutscene);
            playing = true;
            StartCoroutine(WaitTillTransition());
        }
    }
    IEnumerator WaitTillTransition()
    {
        yield return new WaitForSeconds((float)cutscene.duration);
        UnityEngine.SceneManagement.SceneManager.LoadScene(newScene);
    }
}
