using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeath : MonoBehaviour
{
    // on death, spawn something
    public GameObject obj;
    private void OnDisable()
    {
        Instantiate(obj, this.transform.position, this.transform.rotation);
    }
}
