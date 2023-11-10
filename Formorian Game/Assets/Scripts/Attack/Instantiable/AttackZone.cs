using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public string objTag;

    [HideInInspector]
    public float damage;
    private void OnTriggerEnter2D(Collider2D collision) // damage / kis
    {
        if(collision.gameObject.CompareTag(objTag))
        {
            GetComponent<EntityStatScript>().CurrentHP -= damage; // damage entity
            Destroy(this.gameObject); // destroy itself
        }
    }
}
