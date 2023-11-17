//del0m
// scriptable object that holds onto basic parameters for attacks.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseAttack", menuName = "ScriptableObject/Attack")]
public class AttackObject : ScriptableObject
{

    // lists for attack object to hold onto
    public List<Parameter> key;
    public List<float> value;
    public enum Parameter
    { 
        damage, // damage multipler for attack
        speed, // how fast attack moves (projectile)
        length, // how long attack will last for (seconds)
    }
    [Header("Attack Object")]
    public GameObject attack; //  object to hurt other entity

    public string target;
}
