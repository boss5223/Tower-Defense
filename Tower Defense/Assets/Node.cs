using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color colorHover;

    private Renderer rend;
    private Color startColor;
    private GameObject turrets;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if(turrets != null)
        {
            Debug.Log("Can't Build in this Place");
        }
        GameObject turretsToBuild = BuildManager.instance.GetTurrentsToBuild();
        turrets = Instantiate(turretsToBuild, transform.position, transform.rotation);
    }
    void OnMouseEnter()
    {
        rend.material.color = colorHover;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
