using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject hit_monster = other.gameObject;
            EnemyAttribute stat = hit_monster.GetComponent<EnemyAttribute>();
            stat.GetHit();
            Destroy(gameObject);
        }
    }
  
}
