using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed;
    public ParticleSystem particleBullet;
    public void FindTarget(Transform myTarget)
    {
        target = myTarget;
    }
 
    void Awake()
    {
        particleBullet.Play();
    }
 
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 direction = target.transform.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.LookRotation(direction);
        float distanceThisFrame = speed * Time.deltaTime;

        if(direction.magnitude <= distanceThisFrame)
        {
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }
}
