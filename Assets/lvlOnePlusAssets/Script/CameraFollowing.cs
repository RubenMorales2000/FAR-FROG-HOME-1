using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public GameObject trackingTarget;
    private float zOffset;
    void Start()
    {
        zOffset = Mathf.Abs(this.transform.position.z) - Mathf.Abs(trackingTarget.transform.position.z);
    }

    void Update()
    {
        Vector3 newPos = this.transform.position;
        newPos.z = trackingTarget.transform.position.z - zOffset;
        this.transform.position = newPos;
    }
}
