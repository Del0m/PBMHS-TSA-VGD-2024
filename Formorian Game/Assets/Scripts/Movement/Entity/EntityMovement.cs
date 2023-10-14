using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : Movement
{
    public string followTag; // what the entity will try and follow
    public Collider2D[] obj = new Collider2D[10];


    GameObject follow;
    public void CheckRadius() // check around enemy, see if target is around
    {
        if(follow) { return; } // don't run if an object is found

        Physics2D.OverlapCircleNonAlloc(transform.position, entity.stats[StatBlock.Stats.aggroRange], obj);

        foreach (var item in obj)
        {
            if(item != null)
            {
                if (item.CompareTag("Player"))
                {
                    follow = item.gameObject;
                    Debug.Log(item.tag);
                }
            }

        }
    }
    public bool CheckDistance() // remove follow object if distance is too great
    {
        if(!follow) { return false; } // no object? don't follow

        var objDistance = Vector2.Distance(this.transform.position, follow.transform.position);
        // check distance, too far, remove follow
        if ((2 * entity.stats[StatBlock.Stats.aggroRange]) < objDistance && objDistance > entity.stats[StatBlock.Stats.minDistance]) 
        {
            follow = null; // remove object
            Debug.Log(follow);
            return false;
        }
        return true;
    }
    public virtual void Move()
    {
        if(!CheckDistance()) { movement = new Vector2(0,0); }
        movement = Vector2.MoveTowards(this.transform.position, follow.transform.position, 10f).normalized;
    }
}
