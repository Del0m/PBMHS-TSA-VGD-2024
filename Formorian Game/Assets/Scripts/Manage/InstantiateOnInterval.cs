using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// the premise of the program is to instantinate from a list of objects in an interval with a Coroutine
public class InstantiateOnInterval : MonoBehaviour
{
    public List<GameObject> objects;

    public int timeBetweenSpawnRangeLow;
    public int timeBetweenSpawnRangeHigh;

    public int timeToDestroy;
    private void Start()
    {
        StartCoroutine(InstantOnInterval());
    }
    IEnumerator InstantOnInterval()
    {
        yield return new WaitForSeconds(Random.Range(timeBetweenSpawnRangeLow, timeBetweenSpawnRangeHigh));
        var newObject = Instantiate(objects[Random.Range(0, objects.Count)]);
        Destroy(newObject.gameObject, timeToDestroy);
        StartCoroutine(InstantOnInterval());
    }

}
