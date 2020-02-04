﻿using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color colorHover;
    public Vector3 positionOffset;

    private Renderer rend;
    private Color startColor;
    private GameObject turrets;
    private int price;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    void Update()
    {
        price = BuildManager.instance.GetPaymentTurrets();
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (turrets != null)
        {
            Debug.Log("Can't Build in this Place");
        }
        GameObject turretsToBuild = BuildManager.instance.GetTurrentsToBuild();
        if(GameManager.currency < price)
        {
            Debug.LogError("Not Enough Money!!");
        }
        else
        {
            turrets = Instantiate(turretsToBuild, transform.position + positionOffset, transform.rotation);
            GetPayment();
        }
    }
    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(BuildManager.instance.GetTurrentsToBuild() == null)
        {
            return;
        }
        rend.material.color = colorHover;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    void GetPayment()
    {
        GameManager.currency -= price;
        if(GameManager.currency < 0)
        {
            GameManager.currency = 0;
        }
    }
}
