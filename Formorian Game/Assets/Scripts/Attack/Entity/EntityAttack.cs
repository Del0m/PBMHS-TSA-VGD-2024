//del0m
//purpose of script is to hold variables to initiate actions
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityAttack : MonoBehaviour
{
    // from entity itself
    [HideInInspector]
    public EntityMovement movement;

    public AttackObject attack;
    public Dictionary<AttackObject.Parameter, float> stat = new Dictionary<AttackObject.Parameter, float>();
    public virtual void Start()
    {
        movement = GetComponent<EntityMovement>();  
        InitalizeDictionary(stat); 
    }

    public void InitalizeDictionary(Dictionary<AttackObject.Parameter, float> targetDict)
    {
        try
        {
            targetDict.Clear();
            for (int i = 0; i < attack.key.Count; i++)
            {
                targetDict.Add(attack.key[i], attack.value[i]); // add entry into dictionary
            }
        }
        catch (System.Exception)
        {
            //Debug.LogError("Keys: " + targetDict.Keys);
            // Debug.LogError("Values: " + targetDict.Values);

            throw;
        }

    } // initalizes dictionary to allow ease of use for instantiation

    public abstract void CommitAttack(); // commit attack, to be done on specific entity scripts
    public virtual IEnumerator AttackRoutine() // dependent on entity attack script, responsible for managing how it'll attack
    {
        // check if it is an enemy, as enemies only need this.
        if(this.gameObject.CompareTag("Enemy"))
        {
            if (movement.Destination)
            {
                CommitAttack();
                yield return new WaitForSeconds(stat[AttackObject.Parameter.cooldown]);
                yield return AttackRoutine();
            }
            else
            {
                yield return new WaitForSeconds(1f);
                yield return AttackRoutine();
            }
        }

    }
}
