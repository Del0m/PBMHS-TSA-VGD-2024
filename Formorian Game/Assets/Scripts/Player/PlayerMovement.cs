// armin delmo
// purpose: to manage movement of player using a Character Controller
// info: 9/14/23
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private EntityStatScript entity; // stat script where speed will be derived.

    private Rigidbody2D rb; // facilitate movement for character
    private Ground groundScript;

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
        if (Pause.IsPaused) { return; }
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
        rb.velocity = new Vector2(movement.x, Mathf.Clamp(rb.velocity.y, -10f, 10f)); // conduct movement for the player
    }
}
