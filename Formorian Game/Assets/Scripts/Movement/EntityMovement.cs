using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : Movement
{
    public string followTag; // what the entity will try and follow
    private Collider2D[] obj;


    GameObject follow;
    public void CheckRadius() // check around enemy, see if target is around
    {
        if(follow) { return; } // don't run if an object is found

        Physics2D.OverlapCircleNonAlloc(transform.position, entity.stats[StatBlock.Stats.aggroRange], obj);

        foreach (var item in obj)
        {
            if(item.CompareTag(tag))
            {
                follow = item.gameObject;
            }
        }
    }
    public void CheckDistance() // remove follow object if distance is too great
    {
        if(!follow) { return; } // no object? don't follow

        // check distance, too far, remove follow
        if ((2 * entity.stats[StatBlock.Stats.aggroRange]) < Vector2.Distance(this.transform.position, follow.transform.position)) 
        {
            follow = null; // remove object
        }
    }
}
