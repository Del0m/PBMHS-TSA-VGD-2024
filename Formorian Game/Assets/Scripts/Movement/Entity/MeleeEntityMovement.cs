using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEntityMovement : EntityMovement
{
    public override void Move() // follow player
    {
        base.Move();

        rb.velocity = new Vector2(movement.x * 2f, rb.velocity.y);
    }
    private void Start()
    {
        // grabbing objects off object
        entity = gameObject.GetComponent<EntityStatScript>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundScript = gameObject.GetComponentInChildren<Ground>();
    }
    private void FixedUpdate()
    {
        CheckRadius();
        if(CheckDistance())
        {
            Move();
        }
    }
}
