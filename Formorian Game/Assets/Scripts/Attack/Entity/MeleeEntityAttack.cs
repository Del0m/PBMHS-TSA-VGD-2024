using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEntityAttack : EntityAttack
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }
    public override void CommitAttack() // spawn attack zone on center of entity, damage things in radius
    {
        var attackInstance = Instantiate(attack.attack);
        Destroy(attackInstance, stat[AttackObject.Parameter.length]); // delete object after certain length of time.
        // this will delete the object if it doesn't make contact with another entity (deleting after making contact is dealt with through0
    }
}
