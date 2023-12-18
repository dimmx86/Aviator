using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private FuelView fuelView;
    [SerializeField] private MoneyView moneyView;


    private void Start()
    {
        player.FuelTank.OnChangedFuel.AddListener(fuelView.UpdateText);
        player.Money.OnChengetValue.AddListener(moneyView.UpdateText);
        player.StartGame();

    }

    private void OnDestroy()
    {
        player.FuelTank.OnChangedFuel.RemoveListener(fuelView.UpdateText);
        player.Money.OnChengetValue.RemoveListener(moneyView.UpdateText);
    }
}
