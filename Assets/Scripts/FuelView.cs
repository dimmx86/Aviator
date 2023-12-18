using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FuelView : MonoBehaviour
{
    [SerializeField] private TMP_Text text;


    public void UpdateText(int newCurentFuel)
    {
        text.text = newCurentFuel.ToString();
    }
}
