using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : AttackZone
{
    public Vector2 direction;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        // set movement of projectile in said direction
        direction = Vector2.MoveTowards(this.gameObject.transform.position, GameObject.FindGameObjectWithTag(objTag).transform.position, 1f);
    }
    public void Update()
    {
        
    }

}
