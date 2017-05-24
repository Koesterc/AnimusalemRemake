using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DybbukShop : MonoBehaviour {

    [SerializeField]
    Text money;
    [SerializeField]
    Text proceeds;

    // Use this for initialization
    void OnEnable()
    {
        money.text = "Cash: $"+PlayerStats.money.ToString("n0");
        proceeds.text = "Proceeds: +$" + PlayerStats.money.ToString("n0");
    }

}
