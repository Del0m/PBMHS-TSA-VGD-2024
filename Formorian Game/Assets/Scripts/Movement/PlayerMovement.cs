// armin delmo
// purpose: to manage movement of player using a Character Controller
// info: 9/14/23
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Ground))]
public class PlayerMovement : Movement
{

    // input system for player
    private Controls control;
    public float speed = 3f;
    public float jumpPower = 3f;
    float yVelocity;

    private void Start() // initalizing controls
    {
        // grabbing objects off player
        entity = gameObject.GetComponent<EntityStatScript>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundScript = gameObject.GetComponent<Ground>();
        control = new Controls(); // set controls so conflicting controls won't mess with movement
        control.Enable(); // turn on action inputs
    }
    public void FixedUpdate() // updates player position
    {

        Movement(); // conduct movement
    }
    public void OnMove(InputAction.CallbackContext ctx)
    {

        rb.velocity = ctx.ReadValue<Vector2>() * speed;

    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (groundScript.grounded)
        rb.AddForce(Vector2.up * jumpPower,ForceMode2D.Impulse);


    }
    void Movement()
    {
        //gameObject.transform.Translate(new Vector3(0, yVelocity, 0) * Time.deltaTime);
    }
    bool PauseCheck() // check if the game is "paused"
    {
        return Pause.IsPaused;
    }
}
