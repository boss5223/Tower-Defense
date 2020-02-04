using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Have more than one in this Scene!");
            return;
        }
        instance = this;
    }
    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;
    public GameObject specialTurretPrefab;

    private GameObject turretstoBuild;
    private int paymentToBut;
    public GameObject GetTurrentsToBuild()
    {
        return turretstoBuild;
    }
    public int GetPaymentTurrets()
    {
        return paymentToBut;
    }

    public void  SetTurretsToBuild(GameObject turrets,int payment)
    {
        turretstoBuild = turrets;
        paymentToBut = payment;
    }
}
