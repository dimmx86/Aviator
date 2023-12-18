using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private InputController inputController;
    [SerializeField] private Mover mover;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private FuelTank fuelTank;
    [SerializeField] private PlayerColision colision;
    [SerializeField] private Money money;
    [SerializeField] private Gun gun;

    public FuelTank FuelTank => fuelTank;
    public Money Money => money;

    public UnityEvent<int> OnFuelCheng;
    public UnityEvent OnFuelOwer;


    public void StartGame()
    {
        
        mover.Init(rigidbody);
        mover.StartMove();
        inputController.OnInput.AddListener(mover.Move);
        fuelTank.StartConsumption();
        colision.OnPickUp.AddListener(PickUp);
        inputController.OnFire.AddListener(gun.OnFire);
    }


    private void PickUp(PickUpObject pickUpObject)
    {
        switch (pickUpObject.Type)
        {
            case PickUpTipe.Money:
                money.AddMoney(pickUpObject.Value);
                break;

            case PickUpTipe.Fuel:
                fuelTank.AddFuel(pickUpObject.Value);
                break;
        }
        Destroy(pickUpObject.gameObject);
    }

    private void OnDestroy()
    {
        inputController.OnInput.RemoveListener(mover.Move);

        colision.OnPickUp.RemoveListener(PickUp);
        inputController.OnFire.RemoveListener(gun.OnFire);

    }
}
