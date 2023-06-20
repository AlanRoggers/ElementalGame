using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private Transform _target;

    public float smoothSpeed = 0.125f;
    public float fixedPos;

    private Vector3 offset;


    void Start()
    {
        offset = transform.position - _target.position;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = new(_target.position.x + offset.x + fixedPos, transform.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
