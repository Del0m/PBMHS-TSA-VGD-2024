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
    [Header("Drag / Drop")]
    public CharacterController player; // facilitate movement for character
    
    // input system for player
    private Controls control;
    private Vector2 movement;
    private void Start() // initalizing controls
    {
        control = new Controls();
        control.Enable();
    }
    public void FixedUpdate() // updates player position
    {
        player.Move(movement);
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            movement = control.Movement.Walk.ReadValue<Vector2>();
        }
    }
}
