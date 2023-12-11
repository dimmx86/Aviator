using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuelTank : MonoBehaviour
{
    [SerializeField][Min(0f)] private int startFuel = 200;
    [SerializeField][Min(0f)] private float fuelConsumptionInMin = 80;

    private int curentFuel;
    private WaitForSeconds secInOneFuel;
    private bool isConsumption = false;

    public UnityEvent OnEmptyTank;
    public UnityEvent<int> OnChangedFuel;

    public void StartConsumption()
    {
        curentFuel = startFuel;
        secInOneFuel = new WaitForSeconds( 60 / fuelConsumptionInMin);
        isConsumption = true;
        StartCoroutine(Consumption());
    }

    IEnumerator Consumption()
    {
        while (isConsumption)
        {
            yield return secInOneFuel;

            if (curentFuel < 1)
            {
                isConsumption = false;
                OnEmptyTank?.Invoke();
                print("fuel ower");
            }
            else
            {
                curentFuel--;
                OnChangedFuel?.Invoke(curentFuel);
                print("fuel:" + curentFuel);
            }
        }
        yield return secInOneFuel;
    }
}
