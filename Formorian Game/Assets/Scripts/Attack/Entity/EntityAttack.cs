//del0m
//purpose of script is to hold variables to initiate actions
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttack : MonoBehaviour
{
    public AttackObject attack;
    public Dictionary<AttackObject.Parameter, float> stat = new Dictionary<AttackObject.Parameter, float>();
    public virtual void Start()
    {
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

    public virtual void CommitAttack() // commit attack, to be done on specific entity scripts
    {

    }
}
