using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellTower : MonoBehaviour
{
    public virtual void OnMouseDown()
    {
        Destroy(Turrets.sellState);
    }
}
