using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TMP_Text text;


    public void UpdateText(int newCurentFuel)
    {
        text.text = newCurentFuel.ToString();
    }
}
