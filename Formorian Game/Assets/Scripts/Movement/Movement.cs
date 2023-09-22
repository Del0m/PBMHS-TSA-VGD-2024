// del0m; basic object to facilitate all movement scripts
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public Ground groundScript;

    public EntityStatScript entity;

    [HideInInspector]
    public Vector2 movement;
}
