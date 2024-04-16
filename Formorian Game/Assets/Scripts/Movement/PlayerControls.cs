// armin delmo
// purpose: to manage movement of player using a Character Controller
// info: 9/14/23
using JetBrains.Annotations;
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
            movement.x = control.Movement.Walk.ReadValue<Vector2>().x; // grabbing movement, increasing by speed multiplier
        }
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && entity.JumpsLeft > 0 && !jumpCooldown)
        {
            StartCoroutine(Jump());
        }
    }
    void Movement()
    {
        movement.x = control.Movement.Walk.ReadValue<Vector2>().x * entity.stats[StatBlock.Stats.speed]; // grabbing movement, increasing by speed multiplier

        rb.velocity = new Vector2(movement.x , rb.velocity.y - rb.gravityScale * Time.fixedDeltaTime); // move player
        // check player's direction
        _animator._animator.SetInteger("speed", ((int)(movement.x)));
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
    public void Dash(InputAction.CallbackContext ctx)
    {

        if (ctx.performed)
        {
            StartCoroutine(DashRoutine());
        }
    }
    IEnumerator Attack() // runs attack and cooldown
    {
        cooldown = true;
        attack.CommitAttack();
        yield return new WaitForSeconds(attack.stat[AttackObject.Parameter.cooldown]);
        cooldown = false;

    }
    bool jumpCooldown;
    IEnumerator Jump()
    {
        jumpCooldown = true;
        // remove one jump
        entity.JumpsLeft--;

        movement.y = entity.stats[StatBlock.Stats.jumpPower];
        rb.velocity = new Vector2(rb.velocity.x, movement.y);
        yield return new WaitForSeconds(.25f);
        jumpCooldown = false;

    }
    bool dashCooldown;
    IEnumerator DashRoutine() // coroutine to increase movement speed temporarily
    {
        // prevent dashing multiple times
        if(dashCooldown) { yield return null; }
        Debug.Log("Dashing!");

        //enable cooldown
        dashCooldown = true;

        // increase speed stat for .5 seconds
        StartCoroutine(entity.BuffStat(
            StatBlock.Stats.speed, // stat to modify
            entity.stats[StatBlock.Stats.dashCoefficient], // how much stat is being multiplied
            .5f // how long the dash will last
            ));
        yield return new WaitForSeconds(entity.stats[StatBlock.Stats.dashCooldown]);

        // allow dashing
        dashCooldown = false;
    }
}
