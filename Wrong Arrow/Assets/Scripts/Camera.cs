using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float trailDistance = 5f;
    public float heighOffset = 3f;
    public float cameraDelay = 0.02f;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 followPos=target.position-target.forward*trailDistance;

        followPos.y += heighOffset;
        transform.position = Vector3.SmoothDamp(transform.position, followPos, ref velocity, cameraDelay);
        //transform.position += (followPos-transform.position)*cameraDelay;

        transform.LookAt(target.position + Vector3.up * heighOffset);
    }
}
