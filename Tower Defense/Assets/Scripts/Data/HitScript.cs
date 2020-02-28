using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : Turrets
{
    public GameObject HitParticle;
    private AudioSource source;
    void Start()
    {
        GetTurretsData();
        storage = GameObject.FindGameObjectWithTag("Storage");
        source = GetComponent<AudioSource>();
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
            source.Play();
        }
    }
}
