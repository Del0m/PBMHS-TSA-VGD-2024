using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCycle : MonoBehaviour
{
    public List<Sprite> sprite;
    public float time;

    private void Start()
    {
        StartCoroutine(Cycle());
    }
    IEnumerator Cycle()
    {
        for(int i = 0; i < sprite.Count; i++)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite[i];
            yield return new WaitForSeconds(time);
        }
        StartCoroutine(Cycle());
    }
}
