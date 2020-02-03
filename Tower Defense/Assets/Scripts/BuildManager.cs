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
    void Start()
    {
        turretstoBuild = standardTurretPrefab;
    }

    private GameObject turretstoBuild;
    public GameObject GetTurrentsToBuild()
    {
        return turretstoBuild;
    }
}
