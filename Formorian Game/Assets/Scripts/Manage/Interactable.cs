using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool hasInteracted;

    public abstract void OnInteract();
    public abstract void CanInteract(bool can);

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) // see if it is a player
        {
            try
            {
                CanInteract(true); // enable info
                if (collision.gameObject.GetComponent<PlayerControls>().interact)
                {
                    OnInteract();
                    return;
                }
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("Cannot find PlayerControls");
                //throw;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CanInteract(false); // disable info
    }
}
