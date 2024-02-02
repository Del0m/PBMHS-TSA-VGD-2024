using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : AttackZone
{
    [HideInInspector]
    public Vector2 direction;
    [HideInInspector]
    public float speed;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;

        // flip depending on direction
        transform.localScale = new Vector3(1 * direction.normalized.x, 1, 1);
    }
}
