using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnChange : MonoBehaviour
{
    // functionality is for signs only for now
    public GameObject obj;

    Interactable interactScript;
    private void Start()
    {
        interactScript= obj.GetComponent<Interactable>();   
    }
    // Update is called once per frame
    void Update()
    {
        if(interactScript.hasInteracted)
        {
            Destroy(gameObject); 
        }
    }
}
