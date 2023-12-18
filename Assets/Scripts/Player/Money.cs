using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Money : MonoBehaviour
{
    private int value;
    
    public int Value { get { return value; } }

    public UnityEvent<int> OnChengetValue;

    private void Awake()
    {
        value = 0;   
    }

    public void AddMoney(int money)
    {

        value += money;
        OnChengetValue?.Invoke(value);
    }
}
