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
        jumpCount,
        //enemy stats
        aggroRange, // how close the player needs to be in order to follow
        minDistance, // minimum distance the enemy will keep from player

        // player stats
        stepHeight, // how high the player can utilize stepJump
        stepJump, // how high the player will be teleported to move up steps
        dashCoefficient, // mmultiplies user speed while dashing
        dashCooldown, // how long it takes to dash again
    }
}
