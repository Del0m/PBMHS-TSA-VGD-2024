//armin delmo; 9/17/23
// holds all stats for anything in the game
// ScriptedObjects will take stats from enum for use.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Stat Block", menuName = "ScriptableObject/Stats")]
public class StatBlock : ScriptableObject
{
    public List<Stats> stat;
    public List<float> values;

    public enum Stats
    {
        health,
        damage,
        speed,
        jumpPower,
        aggroRange,
        minDistance

    }
}
