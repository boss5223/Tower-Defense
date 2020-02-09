using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            GameManager.towerPoint -= 1;
            GameObject hitCheck = this.gameObject;
            EnemyAttribute hit = hitCheck.GetComponent<EnemyAttribute>();
            hit.GetCheckPoint();
        }
    }
}
