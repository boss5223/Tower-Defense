using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    public static Turrets instance;

    [Header("Attribute")]
    public int turretsID;
    public float range;
    public Transform partToRotate;
    public float rotateSpeed = 10f;
    public int damage;
    public int penetration;
    [Header("Prefab")]
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public GameObject storage;

    private Transform target;
    private float firerate;
    private float firerateCount =0;
    

    void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }
    void Start()
    {
        storage = GameObject.FindGameObjectWithTag("Storage");
        GetTurretsData();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        if(target == null)
        {
            return;
        }
        UpdateTarget();
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
        else
        {
            return;
        }
        if(firerateCount <=0)
        {
            Shoot();
            firerateCount = 1f / firerate;
        }
        firerateCount -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
        bullet.transform.SetParent(storage.transform);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if(bullet != null)
        {
            bulletScript.FindTarget(target);
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
                penetration = turretsData[i].penetration;
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    public void SetParent(Transform parent)
    {
        transform.parent = parent;
    }
}
