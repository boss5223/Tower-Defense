using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    public int turretsID;
    public float range = 16;
    public Transform partToRotate;
    public float rotateSpeed = 10f;

    private Transform target;
    private float firerate;
    private int damage;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        if(target == null)
        {
            return;
        }

        TargetOnLock();
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }
    
    void TargetOnLock()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookDirection = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookDirection, Time.deltaTime * rotateSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
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
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
