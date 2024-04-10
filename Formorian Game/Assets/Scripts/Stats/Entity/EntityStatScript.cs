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
            HealthCheck(value, currentHP);
            currentHP = value;
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

    public virtual void HealthCheck(float val, float prevHealth)
    {
        if(val <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    public override void Awake()
    {
        base.Awake();
        CurrentHP = stats[StatBlock.Stats.health];
    }
}
