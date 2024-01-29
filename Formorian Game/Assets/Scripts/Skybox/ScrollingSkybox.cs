using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingSkybox : MonoBehaviour
{
    Camera cam;
    public float beginningX; // where the skybox will be at its leftmost point
    public float endingX;

    public float imageResX;
    public float imageCount;

    public float endSkyBox;
    public float startSkyBox;
    private void Awake()
    {
        cam = FindObjectOfType<Camera>(); // find player camera in scene.
    }

    Vector3 SkyBoxLocation()
    {
        return new Vector3(cam.transform.position.x + TotalLevelDistance(), cam.transform.position.y, 0);
    }
    private void FixedUpdate()
    {
        transform.position = SkyBoxLocation();
    }
    float TotalLevelDistance()
    {
        float levelDistance = Mathf.Abs(beginningX) + Mathf.Abs(endingX);
        return cam.transform.localPosition.x  / levelDistance * endSkyBox;
    }
}
