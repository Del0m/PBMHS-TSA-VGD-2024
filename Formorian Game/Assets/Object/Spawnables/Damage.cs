// Del0m
// purpose is to damage entities with damage.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage = 10;
    public string target = "Player";

    public float TargetDamage
    {
        get { return damage; }
        set { damage = value; }
    }
    public string TargetTag
    {
        get { return target; }
        set { target = value; }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag(target))
        {
            Debug.Log("hit!");
            collision.gameObject.GetComponent<EntityStatScript>().CurrentHP -= damage;
        }
    }
}
