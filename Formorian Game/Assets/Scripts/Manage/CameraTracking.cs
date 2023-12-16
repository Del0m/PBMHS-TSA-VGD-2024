using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public Transform track; // what object to track
    Vector2 trackPosition;
    public float followCoefficient;

    private bool onScreen;

    public bool OnScreen // check to see if character is onscreen or not.
    {
        get { return onScreen; }
        set { onScreen = value; }
    }
    void FollowX() // follows player on X coordinate
    {
        trackPosition = new Vector2(track.position.x, track.position.y);

        Vector2 camPos = Vector2.MoveTowards(gameObject.transform.position, trackPosition, Distance() * Time.deltaTime * followCoefficient); // calculating vector to go towards
        transform.position = new Vector3(camPos.x, transform.position.y, gameObject.transform.position.z); // moving cam X

        if(!onScreen)
        {
            FollowY(camPos);
        }
    }
    void FollowY(Vector2 camPos)
    {
        transform.position = new Vector3(transform.position.x, camPos.y, gameObject.transform.position.z); // moving cam y
    }
    float Distance() // calculates distance from player
    {
        
        return Vector2.Distance(track.transform.position, gameObject.transform.position);
    }
    public void TrackObject()
    {
        if (Pause.IsPaused) return; // prevents movement in the game if is paused.

        try
        {
            // get track position to hover above
        }
        catch (System.Exception)
        {
            track = GameObject.FindGameObjectWithTag("Player").transform;
            throw new System.Exception("Error: Player not found. Looking for player.");
        }

    }

    private void FixedUpdate()
    {
        FollowX();
    }
}
