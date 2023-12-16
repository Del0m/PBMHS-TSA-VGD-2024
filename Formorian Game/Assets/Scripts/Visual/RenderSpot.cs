using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderSpot : MonoBehaviour // for use in player
{
    public bool seen;
    CameraTracking track;
    RenderMaster master;

    private void Awake()
    {
        track = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraTracking>();
        master = GetComponentInParent<RenderMaster>();
    }

    private void OnBecameInvisible()
    {
        seen = false;
        master.CheckGates();
    }
    private void OnBecameVisible()
    {
        seen = true;
        master.CheckGates();
    }
}
