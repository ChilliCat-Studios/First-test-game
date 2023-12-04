using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levl1Manager : MonoBehaviour
{
    public static Levl1Manager main;

    //hold multiple paths transform[][]
    public Transform[] path;
    public Transform startPoint;

    public int currency;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        currency = 100;
    }


    public void IncreaseCurrency(int amount)
    {
        Debug.Log("In increase currency with + " + amount);
        currency += amount;
        Debug.Log(currency);
    }

    public bool SpendCurrency(int amount)
    {

        if (amount <= currency)
        {
            //buy

            currency -= amount;
            return true;
        }
        else
        {
            //show not enough currency
            Debug.Log("need more money");
            return false;
        }

    }

}

