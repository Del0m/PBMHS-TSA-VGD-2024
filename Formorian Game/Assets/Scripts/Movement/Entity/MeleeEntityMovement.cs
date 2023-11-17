using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEntityMovement : EntityMovement
{
    public override void Start()
    {
        base.Start();

        follow = GameObject.FindGameObjectWithTag(followTag);

    }
    private void FixedUpdate()
    {
        Move();
        Debug.Log(Destination);
    }
}
