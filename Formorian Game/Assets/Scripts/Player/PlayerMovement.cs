// armin delmo
// purpose: to manage movement of player using a Character Controller
// info: 9/14/23
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private EntityStatScript entity; // stat script where speed will be derived.

    private CharacterController player; // facilitate movement for character
    private Gravity gravityScript;

    // input system for player
    private Controls control;
    private Vector2 movement;
    private void Start() // initalizing controls
    {
        // grabbing objects off player
        entity = gameObject.GetComponent<EntityStatScript>();
        player = gameObject.GetComponent<CharacterController>();
        gravityScript = gameObject.GetComponentInChildren<Gravity>();

        control = new Controls(); // set controls so conflicting controls won't mess with movement
        control.Enable(); // turn on action inputs
    }
    public void FixedUpdate() // updates player position
    {
        Movement(); // conduct movement
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            movement.x = control.Movement.Walk.ReadValue<Vector2>().x;
            movement *= Time.deltaTime * entity.stats[StatBlock.Stats.speed]; // multiplying by DeltaTime and entity speed

        }
    }
    float falling;
    void Gravity()
    {
        if (!gravityScript.grounded)
        {
            falling += Physics2D.gravity.y * Time.deltaTime;
        }
        else
        {
            falling = 0f;
        }
    }
    void Movement()
    {
        Gravity();
        movement.y = falling;
        movement.y = Mathf.Clamp(movement.y, -10f, 10f) * Time.deltaTime;
        player.Move(movement); // moves player "movement" increments every update.

    }
}
