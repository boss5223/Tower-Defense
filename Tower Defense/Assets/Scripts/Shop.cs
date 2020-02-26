using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;

    void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }
    public void PurchaseStandardTurrets()
    {
        Debug.Log("PurchaseStandardTurrets Success");
        BuildManager.instance.SetTurretsToBuild(BuildManager.instance.standardTurretPrefab,200); 
    }
    public void PurchaseAnotherTurrets()
    {
        Debug.Log("PurchaseAnotherTurrets Success");
        BuildManager.instance.SetTurretsToBuild(BuildManager.instance.anotherTurretPrefab,300);
    }
    public void PurchaseSpecialTurrets()
    {
        Debug.Log("PurchaseSpecialTurrets Success");
        BuildManager.instance.SetTurretsToBuild(BuildManager.instance.specialTurretPrefab,650);
    }
  
}
