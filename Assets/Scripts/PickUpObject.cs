using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [SerializeField] private PickUpTipe type;
    [SerializeField] private int value;

    public PickUpTipe Type => type;
    public int Value => value;
}


public enum PickUpTipe
{
    Fuel,
    Money
}