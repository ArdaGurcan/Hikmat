using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    Transform player;
    public float smoothTime = 1F;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        Vector3 targetPosition = player.TransformPoint(new Vector3(0, 7, -20));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
