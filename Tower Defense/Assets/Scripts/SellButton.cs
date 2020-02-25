using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellButton : MonoBehaviour
{
    public Button soldTower;
    void Start()
    {
        soldTower.onClick.AddListener(() => SellManager.instance.SellTower());
    }
    void Update()
    {
    }
}
