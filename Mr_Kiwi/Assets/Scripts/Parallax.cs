using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;
    // Start is called before the first frame update
    Vector2 startingPosition;

    private float startingZ;

    private float distanceFromTargetZ => transform.position.z - followTarget.transform.position.z;

    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

    float parallaxFactor => Mathf.Abs(distanceFromTargetZ) / clippingPlane;

    float clippingPlane => (cam.transform.position.z + (distanceFromTargetZ > 0 ? cam.farClipPlane : cam.nearClipPlane));
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;

        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}