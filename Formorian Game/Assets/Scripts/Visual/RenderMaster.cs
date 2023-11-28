using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderMaster : MonoBehaviour // AND gate for player to ensure all bounds are properly rendered
{
    public List<RenderSpot> renderSpots;
    public List<bool> gate;

    CameraTracking track;

    private void Awake()
    {
        track = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraTracking>();
    }
    public void CheckGates() 
    {
        int see = 0;
        for(int i = 0; i < renderSpots.Count; i++) // check if all gates are
        {
            if (renderSpots[i].seen)
            {
                gate[i] = true;
                see++;
            }
            else
            {
                gate[i] = false;
            }
        }
        if(see == renderSpots.Count)
        {
            track.OnScreen = true;
        }
        else
        {
            track.OnScreen = false;
        }    

    }
    private void FixedUpdate()
    {
        CheckGates();
    }
}
