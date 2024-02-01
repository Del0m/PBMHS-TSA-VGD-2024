// del0m; basic object to facilitate all movement scripts
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public AnimationManager _animator;
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public LayerDetection groundScript;

    public EntityStatScript entity;

    [HideInInspector]
    public Vector2 movement;

    public virtual void Start()
    {
        entity = gameObject.GetComponent<EntityStatScript>();
        groundScript = GetComponentInChildren<LayerDetection>();

        rb = gameObject.GetComponent<Rigidbody2D>();

        _animator = GetComponent<AnimationManager>();
    }

}
