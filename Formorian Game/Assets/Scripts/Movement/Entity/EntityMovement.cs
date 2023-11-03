using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EntityMovement : Movement
{
    public string followTag; // what the entity will try and follow

    public GameObject follow;
    public LayerDetection wall;
    public LayerDetection ground;
    public void CheckDirection() // see what direction enemy should face
    {
        if(CheckWall())
        {
            movement.x = 0;
            return;
        }
        try // prevent errors if target is unassigned
        {
            CheckEdge(); // check to see if they can walk in that direction
            var direction = transform.position.x - follow.transform.position.x;
            var distance = Vector2.Distance(transform.position, follow.transform.position);

            if(distance <= entity.stats[StatBlock.Stats.minDistance])
            {
                movement.x = 0;
                return; 
            }

            if (direction > 0)
            {
                movement.x = 1;
            }
            else
            {
                movement.x = -1;

            }
        }
        catch
        {
            // do nothing for now
        }
        
    }
    public void CheckEdge()
    {
        if(!ground)
        {
            CheckHeight(follow.transform);
            movement.x = 0;
        }
    }
    public bool CheckWall()
    {
        Debug.Log("Wall found");

        if (wall.detected)
        {
            CheckHeight(follow.transform);
            return true;
        }
        return false;
    }
    public void CheckHeight(Transform subject)
    {
        var distance = subject.position.y - transform.position.y;

        if(distance > 0)
        {
            Jump();
        }
    }
    public virtual void Move() // moves entity towards follow gameobject
    {
        CheckDirection();
        rb.velocity = new Vector2(-movement.x * entity.stats[StatBlock.Stats.speed], rb.velocity.y + (rb.gravityScale * Time.deltaTime));

    }
    public void Jump()
    {
        rb.velocity = new Vector2(movement.x, entity.stats[StatBlock.Stats.jumpPower]);
    }
}
