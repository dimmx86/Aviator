using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField][Min(1)] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

   public void OnFire()
    {

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position, Vector2.right, maxDistance, layerMask);
        if (hit)
        {
            print(hit.collider.name);
        }
    }

    public void DrawFireLine()
    {

    }
}
