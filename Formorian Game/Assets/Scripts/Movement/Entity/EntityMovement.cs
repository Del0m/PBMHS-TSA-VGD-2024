using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : Movement
{
    public string followTag; // what the entity will try and follow

    [HideInInspector]
    public GameObject follow;

    public bool CheckDistance(Vector2 obj)
    {
        if(Vector2.Distance(this.transform.position, obj) > entity.stats[StatBlock.Stats.aggroRange])
        {
            Debug.Log(CheckRotation(follow.transform.position));
            Quaternion.Euler(0, CheckRotation(follow.transform.position), 0);
            return false;
        }
        return true;
    }
    float CheckRotation(Vector2 obj)
    {
        if(obj.x - this.transform.position.x < 0)
        {
            return -1f;
        }
        return 1;
    }
    public virtual void Move()
    {
        movement = Vector2.MoveTowards(this.transform.position, follow.transform.position, 1f).normalized;
        if(CheckRotation(follow.transform.position) < 0 && movement.x > 0)
        {
            movement.x *= -1;
        }
        else if (CheckRotation(follow.transform.position) > 0)
        {
            movement.x = Mathf.Abs(movement.x);
        }
    }
}
