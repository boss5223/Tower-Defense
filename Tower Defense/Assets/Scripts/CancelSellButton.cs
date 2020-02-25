using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelSellButton : MonoBehaviour
{
    public virtual void OnMouseDown()
    {
        //RaycastHit hit;
        //if(Physics.Raycast(transform.position, -Vector3.up,out hit)){
        //    if(hit.collider ==null || hit.collider != null)
        //    {
        //        Destroy(Turrets.sellState);
        //    }
        //}
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null )
                    Destroy(Turrets.sellState);
            
            }
                
        }
    }
}
