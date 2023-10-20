using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEntityMovement : EntityMovement
{
    public override void Move() // follow player
    {
        if(!CheckDistance(follow.transform.position))
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            return; 
        }
        base.Move();

        rb.velocity = new Vector2(movement.x * 2f, rb.velocity.y);
    }
    private void Start()
    {
        // grabbing objects off object
        entity = gameObject.GetComponent<EntityStatScript>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundScript = gameObject.GetComponentInChildren<Ground>();

        follow = GameObject.FindWithTag(followTag);
    }
    private void FixedUpdate()
    {
        Move();
    }
}
