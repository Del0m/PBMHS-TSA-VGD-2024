using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerDetection : MonoBehaviour
{
    public bool detected; // tells if tag is detected

    public string subject; // tag in question

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(subject))
        {
            detected = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(subject))
        {
            detected = true;
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
