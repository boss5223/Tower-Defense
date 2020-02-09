using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : Turrets
{
    public GameObject HitParticle;
    
    void Start()
    {
        GetTurretsData();
        storage = GameObject.FindGameObjectWithTag("Storage");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject hitEffect = Instantiate(HitParticle, transform.position, transform.rotation);
            hitEffect.transform.SetParent(storage.transform);
            GameObject hitEnemy = other.gameObject;
            EnemyAttribute stat = hitEnemy.GetComponent<EnemyAttribute>();
            stat.GetHit(damage,penetration);
            Destroy(gameObject);
            Destroy(hitEffect, 2f);
        }
    }
    void GetTurretsData()
    {
        var turretsData = TurretsDataContainer.Instance.GetTurretsData();
        Debug.Log(turretsData);
        for (int i = 0; i < turretsData.Count; i++)
        {
            if (turretsData[i].turretID == turretsID)
            {
                range = turretsData[i].turretDistance;
                firerate = turretsData[i].turretFirerate;
                damage = turretsData[i].turretDamage;
                penetration = turretsData[i].penetration;
            }
        }
    }
}
