using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawObject : MonoBehaviour
{
    [SerializeField][Min(0.1f)] private float radius = 2.0f;

    public float Radius { get { return radius; } set { } }
}
