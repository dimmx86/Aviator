using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireButton : MonoBehaviour
{
    public UnityEvent OnFire;

    public void Fire()
    {
        OnFire?.Invoke();
    }
}
