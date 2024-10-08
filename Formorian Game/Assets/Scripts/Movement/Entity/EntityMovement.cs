using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EntityMovement : Movement
{
    public string followTag; // what the entity will try and follow

    public GameObject follow;
    public LayerDetection wall;
    public LayerDetection ground;

    private bool destination;
    public bool Destination
    {
        get { return destination; }
        set { destination = value; }
    }
    public override void Start()
    {
        base.Start();
        follow = GameObject.FindGameObjectWithTag(followTag);
        rb = this.GetComponent<Rigidbody2D>();
    }
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
            var direction = transform.position.x - follow.transform.position.x; // what direction to move in
            var distance = Mathf.Abs(direction); // distance from player

            if (distance >= entity.stats[StatBlock.Stats.aggroRange]) // see if it is too close / too far
            {
                movement.x = 0;
                Destination = false;
                return; 
            }

            switch(direction > 0) // check what direction it should move in
            {
                case true: // player is in the right direction
                    // change direction of entity
                    transform.localScale = new Vector3(-1, 1, 1);
                    if (distance < entity.stats[StatBlock.Stats.minDistance] / 2) {; movement.x = -1; return; } // player is too close

                    // goldilocks zone, dont move entity
                    else if (distance > entity.stats[StatBlock.Stats.minDistance] / 2 && distance < entity.stats[StatBlock.Stats.minDistance]) 
                    { 
                        movement.x = 0f; 
                        Destination = true; 
                        return; 
                    }
                    Destination = false; 

                    movement.x = 1f;
                    return;
                case false: // player is in the left direction
                    
                    // change direction of entity
                    transform.localScale = new Vector3(1, 1, 1);

                    // player is too close
                    if (distance < entity.stats[StatBlock.Stats.minDistance] / 2) { Debug.Log("Too Close!");  movement.x = 1; return; }
                    // goldilocks zone, dont move entity
                    else if (distance > entity.stats[StatBlock.Stats.minDistance] / 2 && distance < entity.stats[StatBlock.Stats.minDistance]) 
                    { 
                        movement.x = 0f; 
                        Destination = true; 
                        return; 
                    }

                    Destination = false; // not near enemy, disabling

                    movement.x = -1f;
                    return;
            }
        }
        catch
        {
            // new System.Exception("Target not found.")
            throw;
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
        if (wall.detected)
        {
            CheckHeight(follow.transform);
            return true;
        }
        return false;
    }
    public void CheckHeight(Transform subject)
    {
        var distance = subject.position.y - (transform.position.y - 1);

        if(distance > 0)
        {
            Jump();
        }
    }
    public void Move() // moves entity towards follow gameobject
    {
        CheckDirection();
        rb.velocity = new Vector2(-movement.x * entity.stats[StatBlock.Stats.speed], rb.velocity.y + (rb.gravityScale * Time.deltaTime));

        // add animation
        _animator._animator.SetInteger("speed", (int)movement.x);
    }
    public void Jump()
    {
        if(ground.detected)
        {
            rb.velocity = new Vector2(movement.x, entity.stats[StatBlock.Stats.jumpPower]);
        }
    }

    // fixed update
    private void FixedUpdate()
    {
        Move();

    }
}
