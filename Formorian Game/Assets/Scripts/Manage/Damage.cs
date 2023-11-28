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

        if (collision.gameObject.CompareTag(target) || collision.gameObject.CompareTag("Ground"))
        {
            try // target
            {
                collision.gameObject.GetComponent<EntityStatScript>().CurrentHP -= damage;
                Destroy(this.gameObject);
            }
            catch (System.Exception) // ground
            {
                Destroy(this.gameObject);
            }

        }
    }
    public void SetDamage(float dmg, string trgt) // who to damage, how much damage
    {
        TargetDamage = dmg;
        TargetTag = trgt;
    }
}
