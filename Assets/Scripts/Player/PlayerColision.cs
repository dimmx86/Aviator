using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerColision : MonoBehaviour
{
    public UnityEvent<PickUpObject> OnPickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<PickUpObject>(out PickUpObject pickUpObject))
            OnPickUp?.Invoke(pickUpObject);
    }
}
