using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrollTest : MonoBehaviour
{
    public GameObject quadGameObject;
    private SpriteRenderer quadRenderer;

    public float scrollSpeed = .5f;

    Rigidbody2D playerRB;
    Camera cam;

    void Start()
    {
        quadRenderer = quadGameObject.GetComponent<SpriteRenderer>();
        playerRB = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();
    }

    void Update()
    {
        Vector2 textureOffset = new Vector2(Time.deltaTime * scrollSpeed, 0) * playerRB.velocity.normalized;;
        quadRenderer.material.mainTextureOffset += textureOffset;
        quadGameObject.transform.position = cam.transform.position + new Vector3(0,0,10);
    }
}
