using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : AttackZone
{
    [HideInInspector]
    public Vector2 direction;
    [HideInInspector]
    public float speed;
    public bool projectileFacesTarget;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;

        // flip depending on direction
        transform.localScale = new Vector3(1 * direction.normalized.x, 1, 1);
        
        // make projectile face target if approved
        if(projectileFacesTarget) // broken, keeping it anyways. 
        {
            var targetTurn = Vector2.Angle(this.gameObject.transform.position, GameObject.FindGameObjectWithTag(damageScript.target).transform.position);
            transform.Rotate(0, 0, targetTurn);
        }
    }
}
