// purpose of script is to replace the former "CameraTracking.cs" script
// camera should move like the old mario games.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Collider2D area; // area camera won't follow player
    Camera cam; // camera in question

    public float followSpeed; // how fast the camera is going to move
    public Transform followedObject; // followed object in question

    public bool move;
    private void Awake()
    {
        // grab components off of the object.
        area = this.GetComponent<Collider2D>();
        cam = this.GetComponent<Camera>();
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
        var moveTowards = Vector2.MoveTowards(this.gameObject.transform.position, followedObject.position, followSpeed * Time.fixedDeltaTime);
        Debug.Log(cam.WorldToViewportPoint(followedObject.transform.position));
        if (cam.WorldToViewportPoint(followedObject.transform.position).x > .25f && cam.WorldToViewportPoint(followedObject.transform.position).x < .5f) // check if the player isn't too far left.
        {
            moveTowards.x = transform.position.x;
        }

        if (cam.WorldToViewportPoint(followedObject.transform.position).y > .25f && cam.WorldToViewportPoint(followedObject.transform.position).y < .5f) // check if the player isn't too far left.
        {
            moveTowards.y = transform.position.y;
        }

        var camPos = new Vector3(moveTowards.x, moveTowards.y, -10f);
        transform.position = camPos;

    }
    private void OnTriggerExit2D(Collider2D collision) // turn on case
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            move = true;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision) // turn off case
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            move = false;

        }
    }
}
