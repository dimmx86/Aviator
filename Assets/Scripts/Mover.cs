using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField][Range(0.1f , 1.0f)] private float maxAngle;

    private Rigidbody2D rigidbody;
    private float normalSpeed;
    private bool isMove = false;

    public void Init(Rigidbody2D rigidbody)
    {
        normalSpeed = (maxSpeed + minSpeed) / 2;
        this.rigidbody = rigidbody;
        rigidbody.velocity = Vector3.zero;
    }

    public void StartMove()
    { 
        isMove = true;
        rigidbody.velocity = Vector3.right * normalSpeed;
    }

    public void StopMove()
    {
        isMove = false;
        rigidbody.velocity = Vector3.zero;
    }

    public void Move(float x, float y)
    {
        if (isMove)
        {
            if (y > maxAngle) y = maxAngle;
            else if (y < -maxAngle) y = -maxAngle;

            x = x * 0.5f + 1;

            rigidbody.velocity = new Vector3(x, y, 0) * normalSpeed;
        }
    }

}


