using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEntityAttack : EntityAttack
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        StartCoroutine(AttackRoutine());
    }
    public override void CommitAttack() // spawn attack zone on center of entity, damage things in radius
    {
        Debug.Log("Attack!");
        var attackInstance = Instantiate(attack.attack, this.transform.position, Quaternion.identity); // spawn attackzone on melee combatant
        var attackScript = attackInstance.GetComponent<Damage>(); // grab damage script on attackzone

        attackScript.SetAttack(stat[AttackObject.Parameter.damage], stat[AttackObject.Parameter.length], movement.followTag); // change attack variables
    }
}
