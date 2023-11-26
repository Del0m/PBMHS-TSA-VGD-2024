using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public Transform track; // what object to track
    Vector2 trackPosition;
    public float followCoefficient;
    void FixedUpdate() // moves camera to player
    {
        if (Pause.IsPaused) return; // prevents movement in the game if is paused.

        try
        {
            // get track position to hover above
            trackPosition = new Vector2(track.position.x, track.position.y + 3);
            Vector2 camPos = Vector2.MoveTowards(gameObject.transform.position, trackPosition, Distance() * Time.deltaTime * followCoefficient); // calculating vector to go towards
            transform.position = new Vector3(camPos.x, camPos.y, gameObject.transform.position.z); // moving cam
        }
        catch (System.Exception)
        {
            throw new System.Exception("Error: Player not found.");
            
        }

    }
    float Distance() // calculates distance from player
    {
        
        return Vector2.Distance(track.transform.position, gameObject.transform.position);
    }
}
