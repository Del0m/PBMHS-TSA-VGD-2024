using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// same as item, but instantiate something before it is removed from the scene.
public class SpecialItem : Item
{
    [Header("Special Item Attributes")]
    // add item for player to follow
    public GameObject specialFollow;

    public override void OnGrab(GameObject grabber, int i)
    {
        Debug.Log("Instantiating!");
        var specialFollowInstance = Instantiate(specialFollow);

        // set transform and speed on object
        var sfScript = specialFollowInstance.GetComponent<ObjectAnimation>();
        sfScript.follow = grabber.transform;
        sfScript.speed = 3;

        base.OnGrab(grabber, i);
    }
}
