using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RangedEntityAttack : EntityAttack
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        StartCoroutine(AttackRoutine());
    }
    public override void CommitAttack() // spawn attack zone on center of entity, damage things in radius
    {
        var attackInstance = Instantiate(attack.attack, this.transform.position, Quaternion.identity); // spawn attackzone on melee combatant
        var attackScript = attackInstance.GetComponent<Projectile>(); // grab damage script on attackzone

        // setting speed
        attackScript.speed = stat[AttackObject.Parameter.speed];

        // adding the damage and target of attack
        attackScript.damageScript.SetDamage(stat[AttackObject.Parameter.damage], attack.target);

        // adding direction of projectile
        if(attack.isHoming)
        {
            attackScript.direction = Difference(movement.follow.transform.position) * stat[AttackObject.Parameter.speed];
        }
        else // shoot in direction they're facing
        {
            attackScript.direction = new Vector2(1 * this.gameObject.transform.localScale.x, 0);
        }
        // adding length of time before destruction
        Destroy(attackScript.gameObject, stat[AttackObject.Parameter.length]);
    }
    Vector2 Difference(Vector2 pointB)
    {
        var xDiff = gameObject.transform.position.x - pointB.x;
        var yDiff = gameObject.transform.position.y - pointB.y;


        var diff = new Vector2(xDiff, yDiff).normalized;
        return -diff;
    }
}
