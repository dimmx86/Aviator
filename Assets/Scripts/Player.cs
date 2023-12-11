using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputController inputController;
    [SerializeField] private Mover mover;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private FuelTank fuelTank;

    private void Start()
    {
        mover.Init(rigidbody);
        mover.StartMove();
        inputController.OnInput.AddListener(mover.Move);
        fuelTank.StartConsumption();
    }
}
