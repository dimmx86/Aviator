using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 1f;

    private Vector3 offset;
    private Vector3 targetPosition;
    private bool isFollow = false;

    private void Start()
    {
        offset = transform.position - target.position;
        isFollow = true;
    }

    void FixedUpdate()
    {
        if (isFollow)
        {
            targetPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed);
        }
    }
}
