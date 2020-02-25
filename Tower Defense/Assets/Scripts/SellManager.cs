using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellManager : MonoBehaviour
{
    public static SellManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Have more than one in this Scene!");
            return;
        }
        instance = this;
    }
    void Start()
    {
    }

    public void SellTower(GameObject turret)
    {

        Debug.LogError("Sell Tower...");
    }
}
