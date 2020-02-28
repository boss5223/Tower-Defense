using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : Turrets
{
    public GameObject HitParticle;
    public GameObject closeEffect;
    public AudioClip sound;
    AudioSource source;
    void Start()
    {
        GetTurretsData();
        storage = GameObject.FindGameObjectWithTag("Storage");
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            source.PlayOneShot(sound);
            GameObject hitEffect = Instantiate(HitParticle, transform.position, transform.rotation);
            hitEffect.transform.SetParent(storage.transform);
            GameObject hitEnemy = other.gameObject;
            EnemyAttribute stat = hitEnemy.GetComponent<EnemyAttribute>();
            stat.GetHit(damage,penetration);
            closeEffect.SetActive(false);
            Destroy(hitEffect, 2f);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        Debug.Log("Exited");
    }
}
