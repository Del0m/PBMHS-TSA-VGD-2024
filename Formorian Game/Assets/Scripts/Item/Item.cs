using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Item : MonoBehaviour
{
    [Header("Base Item Attributes")]
    public bool visible; // visible to player
    public StatBlock block;
    private Dictionary<StatBlock.Stats, float> stat = new Dictionary<StatBlock.Stats, float>();

    [Header("Base Item Parameters")]
    public bool interactable; // if "E" needs to be pressed to grab it.

    private bool interacted;
    private void Start()
    {
        InitializeStat();
    }

    private void InitializeStat()
    {
        for(int i = 0; i < block.stat.Count; i++)
        {
            stat.Add(block.stat[i], block.values[i]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // look for player, buff player
    {
        if(collision.CompareTag("Player"))
        {
            var statCount = stat.Count;

            for (int i = 0; i < statCount; i++)
            {
                try
                {
                    if(interactable) //// make them have to press "Interact" to grab item.
                    {
                        if(interacted)
                        {
                            OnGrab(collision.gameObject, i); // add stats to item
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        OnGrab(collision.gameObject, i); // add stats to item
                    }
                }
                catch (System.Exception)
                {
                    Debug.LogError("Buff not found. Check player stats and item buff.");
                    throw;
                }
            }
            Destroy(this.gameObject);
        }
    }
    public virtual void OnGrab(GameObject grabber, int i) // to be overridden on SpecialItem to allow for other items to spawn
    {
        grabber.GetComponent<PlayerStatScript>().AddStat(block.stat[i], stat[block.stat[i]]); // buff player's stats accordingly

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerControls>().interact)
            {
                interacted = true;
                OnTriggerEnter2D(collision);

                Destroy(this.gameObject);

            }
        }

    }
}
