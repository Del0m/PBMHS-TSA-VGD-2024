// purpose of script is to replace the former "CameraTracking.cs" script
// camera should move like the old mario games.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CameraMovement : MonoBehaviour
{
    [Header("Camera Bounds")]
    public float cameraBottom;
    public float cameraTop;

    Camera cam; // camera in question

    public float followSpeed; // how fast the camera is going to move
    public Transform followedObject; // followed object in question

    public bool move;
    private void Awake()
    {
        // grab components off of the object.
        cam  = this.GetComponent<Camera>();

    }
    private void FixedUpdate()
    {
        Follow(); // follow player

    }
    float Distance() // calculates distance from player
    {
        var distCorrect = new Vector3(-10, 0, 0);

        var xDistance = (followedObject.transform.position.x - gameObject.transform.position.x);
        if(xDistance < 0)
        {
            // corrected position
            var distance = Vector2.Distance(followedObject.transform.position, gameObject.transform.position + distCorrect);

            return distance;
        }
        else
        {
            var distance = Vector2.Distance(followedObject.transform.position, gameObject.transform.position);

            return distance;
        }
    }
    void Follow() // follow the player using the camera
    {
        try
        {
            var correction = followedObject.position + new Vector3(0, 2.5f, 0);
            var moveTowards = Vector2.MoveTowards(gameObject.transform.position, correction, followSpeed * Time.fixedDeltaTime);

            if (cam.WorldToViewportPoint(followedObject.transform.position).x > .25f && cam.WorldToViewportPoint(followedObject.transform.position).x < .5f) // check if the player isn't too far left.
            {
                moveTowards.x = transform.position.x;
            }

            if (cam.WorldToViewportPoint(followedObject.transform.position).y > cameraBottom && cam.WorldToViewportPoint(followedObject.transform.position).y < cameraTop) // check if the player isn't too far left.
            {
                moveTowards.y = transform.position.y;
            }

            var camPos = new Vector3(moveTowards.x, moveTowards.y, -10f);
            transform.position = camPos;

        }
        catch (System.NullReferenceException)
        {
            Debug.LogError("Cannot find followed object, defaulting to player");
            followedObject = GameObject.FindGameObjectWithTag("Player").transform;
            throw;
        }
        catch (System.Exception)
        {
            Debug.LogError("Unknown error has occured!");
            throw;
        }
        
    }
}
