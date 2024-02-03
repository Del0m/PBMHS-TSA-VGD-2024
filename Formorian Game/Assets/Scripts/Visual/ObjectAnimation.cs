using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimation : MonoBehaviour
{
    // object to follow
    public Transform follow;
    public float speed; // how fast script will follow

    private void FixedUpdate()
    {
        FollowObject();
        FlipObject();
    }

    void FollowObject() // make a moveTowards vector towards the back of the "follow" to follow
    {
        // make it behind palyer
        transform.position = follow.position + new Vector3(-1, 1);
    }
    void FlipObject() // change the direction of the object depending on the "follow" direction
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x * follow.localScale.x / Mathf.Abs(follow.localScale.x), 1, 1);
    }
}
