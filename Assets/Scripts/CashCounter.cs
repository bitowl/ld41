using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashCounter : MonoBehaviour
{
    public FloatVariable cash;

    void Start()
    {
        cash.value = 0;
    }

    public void AddCash(float value)
    {
        cash.value += value;
    }
}
