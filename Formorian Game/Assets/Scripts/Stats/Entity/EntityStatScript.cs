//armin delmo; 9/17/23
// holds stats for entities, relies on StatScript, manages health for entity
// FOR use in entities
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class EntityStatScript : StatScript
{
    private float currentHP; // current hp of entity

    public virtual float CurrentHP
    {
        get { return currentHP;  }
        set 
        { 
            currentHP = value;
            if (currentHP < 0) // check if entity has died.
            {
                gameObject.SetActive(false); // remove entity.
                HealthCheck();
            }
        }
    }
    public virtual void HealthCheck()
    {

    }
}
