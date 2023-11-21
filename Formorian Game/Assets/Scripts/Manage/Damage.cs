// Del0m
// purpose is to damage entities with damage.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private float damage;
    private string target;

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
            collision.gameObject.GetComponent<EntityStatScript>().CurrentHP -= damage;
        }
    }

    public void SetAttack(float dmg, float time, string aim) // time is how long the attack will stay onscreen, aim is who it is towards
    {
        TargetTag = aim;
        TargetDamage = dmg;
        Destroy(this.gameObject, time);


    }
}
