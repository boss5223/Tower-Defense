using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Turrets : CancelSellButton
{
   
    [Header("Attribute")]
    public int turretsID;
    public float range;
    public Transform partToRotate;
    public float rotateSpeed = 10f;
    public float damage;
    public float penetration;
    [Header("Prefab")]
    public GameObject bulletPrefab;
    public GameObject[] firePoint;
    public GameObject storage;
    public GameObject Sell;
    public static GameObject sellState;
    public static GameObject turretsell;
    [HideInInspector]public Button SellButton;
    private Transform target;
    public float firerate;
    private float firerateCount =0;
    private GameObject bullet;
    private List<TurretsBuild> turretsBuilds;
    [HideInInspector]public bool enemyDead = false;
    [HideInInspector]public GameObject nearestEnemy;

    void Start()
    {
        storage = GameObject.FindGameObjectWithTag("Storage");
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        GetTurretsData();
    }

    void Update()
    {
        SellButtonPosition();
        if (target == null)
        {
            return;
        }
        FirerateCount();
        TargetOnLock();
        sellState = GameObject.Find("DestroyTurrets"+"(Clone)");
        CreateSellButton();
    }
    public void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        nearestEnemy = null;
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
        //if(nearestEnemy.GetComponent<EnemyAttribute>().hp <= 0)
        //{
        //    enemyDead = true;
        //}
    }
    void FirerateCount()
    {
        if (firerateCount <= 0)
        {
            Shoot();
            firerateCount = 1f / firerate;
        }
        firerateCount -= Time.deltaTime;
    }
    
    void SellButtonPosition()
    {
        if (SellButton != null)
        {
         Vector3 unitposition = new Vector3(transform.position.x-5, transform.position.y + 7f, transform.position.z);
         SellButton.transform.position = Camera.main.WorldToScreenPoint(unitposition);
        }
       
    }
    public void FinishSellTurrets()
    {
        Debug.Log("Sell Turret");
        
    }

    void Shoot()
    {
            for (int i = 0; i < firePoint.Length; i++)
            {
                bullet = Instantiate(bulletPrefab, firePoint[i].transform.position, transform.rotation);
            }
            bullet.transform.SetParent(storage.transform);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bullet != null)
            {
                bulletScript.FindTarget(target);
                return;
            }
        

    }
    
    void TargetOnLock()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookDirection = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookDirection, Time.deltaTime * rotateSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    public override void OnMouseDown()
    {
        //if (sellState != null)
        //{
        //    Debug.LogError("sellState is exist");
        //}
        //else
        //{
        //    SellButton = Instantiate(Sell, FindObjectOfType<Canvas>().transform).GetComponent<Button>();
        //}
    }
    void CreateSellButton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) 
            {
                if (hit.collider.tag == "SB")
                    {
                   
                }
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
   public void GetTurretsData()
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
