// armin delmo
// purpose: to manage movement of player using a Character Controller
// info: 9/14/23
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControls : Movement
{
    [HideInInspector]
    public bool interact;
    // attack script for player
    RangedEntityAttack attack;
    // input system for player
    private Controls control;

    public override void Start() // initalizing controls
    {
        base.Start();
        // getting attack script for player
        attack = GetComponent<RangedEntityAttack>();

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
        if (ctx.performed && groundScript.detected)
        {
            movement.y = entity.stats[StatBlock.Stats.jumpPower];
            rb.velocity = new Vector2(rb.velocity.x, movement.y);
        }
    }
    void Movement()
    {
        rb.velocity = new Vector2(movement.x, rb.velocity.y + rb.gravityScale * Time.fixedDeltaTime); // move player
        
        // check player's direction
        if(rb.velocity.x < 0) // face left
        {
            this.gameObject.transform.localScale = new Vector3(-1,1,1);
        }
        else if (rb.velocity.x > 0) // face right
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);

        }
    }
    void PauseCheck() // check if the game is "paused"
    {
        if (Pause.IsPaused)
        {
            return;
        }
    }
    bool cooldown;
    public void Fire(InputAction.CallbackContext ctx) //allows for firing through control system.
    {
        if (ctx.performed && !cooldown)
        {
            StartCoroutine(Attack());

        }
    }
    public void Interact(InputAction.CallbackContext ctx)
    {
        if(ctx.action.triggered)
        {
            interact = true;
        }
        if (ctx.canceled)
        {
            interact = false;
        }
    }
    IEnumerator Attack() // runs attack and cooldown
    {
        cooldown = true;
        attack.CommitAttack();
        yield return new WaitForSeconds(attack.stat[AttackObject.Parameter.cooldown]);
        cooldown = false;

    }

}
