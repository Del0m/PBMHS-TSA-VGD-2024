using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerDetection : MonoBehaviour
{
    public bool detected; // tells if tag is detected

    public string subject; // tag in question

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(subject))
        {
            detected = true;
            // check if parent has an entity script, if so, give them extra jumps again
            try
            {
                var entity = GetComponentInParent<EntityStatScript>();
                entity.JumpsLeft = entity.stats[StatBlock.Stats.jumpCount];
            }
            catch (System.Exception)
            {
                // do nothing
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(subject))
        {
            detected = false;
        }
    }
}
