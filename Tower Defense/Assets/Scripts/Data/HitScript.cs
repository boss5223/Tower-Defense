using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public GameObject HitParticle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject hitEffect = Instantiate(HitParticle, transform.position, transform.rotation);
            GameObject hit_monster = other.gameObject;
            EnemyAttribute stat = hit_monster.GetComponent<EnemyAttribute>();
            stat.GetHit();
            Debug.Log("Hit Enemy" + other.name);
            Destroy(gameObject);
            Destroy(hitEffect, 2f);
        }
    }
  
}
