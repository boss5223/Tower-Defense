using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public GameObject HitParticle;
    public GameObject storage;
    void Start()
    {
        storage = GameObject.FindGameObjectWithTag("PS");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject hitEffect = Instantiate(HitParticle, transform.position, transform.rotation);
            hitEffect.transform.SetParent(storage.transform);
            GameObject hitEnemy = other.gameObject;
            EnemyAttribute stat = hitEnemy.GetComponent<EnemyAttribute>();
            stat.GetHit();
            Debug.Log("Hit Enemy" + other.name);
            Destroy(this.gameObject);
            Destroy(hitEffect, 2f);
        }
    }
    public void SetParent(Transform parent)
    {
        transform.parent = parent;
    }
}
