//armin delmo; 9/17/23
// holds stats for entities, relies on StatScript, manages health for entity
// FOR use in entities
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStatScript : StatScript
{
    private float currentHP; // current hp of entity
    private float jumpsLeft; // see how many jumps the entity has left
    public virtual float CurrentHP
    {
        get { return currentHP;  }
        set 
        { 
            currentHP = value;
            HealthCheck();

            if (currentHP <= 0) // check if entity has died.
            {
                gameObject.SetActive(false); // remove entity.
            }
        }
    }
    public virtual float JumpsLeft
    {
        get 
        {
            try
            {
                return jumpsLeft;

            }
            catch (System.Exception)
            {
                Debug.LogError("No JumpsLeft found in Statblock.");
                return 1f;
            }
        }
        set
        {
            jumpsLeft = value;
        }
    }

    public virtual void HealthCheck()
    {

    }
    public override void Start()
    {
        base.Start();
        CurrentHP = stats[StatBlock.Stats.health];
    }
}
