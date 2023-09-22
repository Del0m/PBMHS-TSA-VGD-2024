// armin delmo
// purpose: to manage movement of player using a Character Controller
// info: 9/14/23
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : Movement
{

    // input system for player
    private Controls control;
    private Vector2 movement;
    private void Start() // initalizing controls
    {
        // grabbing objects off player
        entity = gameObject.GetComponent<EntityStatScript>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundScript = gameObject.GetComponentInChildren<Ground>();

        control = new Controls(); // set controls so conflicting controls won't mess with movement
        control.Enable(); // turn on action inputs
    }
    public void FixedUpdate() // updates player position
    {
        PauseCheck(); // check if the game is paused

        Movement(); // conduct movement
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            movement.x = control.Movement.Walk.ReadValue<Vector2>().x * entity.stats[StatBlock.Stats.speed]; // grabbing movement, increasing by speed multiplier
        }
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && groundScript.grounded)
        {
            movement.y = entity.stats[StatBlock.Stats.jumpPower];
            rb.velocity = new Vector2(rb.velocity.x, movement.y);
        }
    }
    void Movement()
    {
        rb.velocity = new Vector2(movement.x, Mathf.Clamp(rb.velocity.y, -10f * rb.gravityScale, 10f * rb.gravityScale)); // move player
    }
    void PauseCheck() // check if the game is "paused"
    {
        if (Pause.IsPaused)
        {
            return;
        }
    }
}
