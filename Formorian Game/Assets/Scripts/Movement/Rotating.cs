using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float rotationSpeed; // speed of object rotation

    public void LateUpdate()
    {
        var obj = gameObject.transform.rotation;
        gameObject.transform.Rotate(obj.x, obj.y, (rotationSpeed * Time.fixedDeltaTime));

    }
}
