﻿using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public string spawnerid;
    public float Timer;
    public float timeCountdown;
    public GameObject enemy;
    public string EnemyName;
    public int spawnMonsterSize;
    public float repeat;
    public GameObject storage;

    [HideInInspector]public static int monsterInField = 0;
    GameObject LastEnemy;
    void Start()
    {
        timeCountdown = 15f;
        this.gameObject.name = EnemyName + "spawn point";
        //PoolManager.instance.CreatePool(enemy, spawnMonsterSize);
        InvokeRepeating("SpawnEnemy", Timer, repeat);
    }
    void Update()
    {
        DifficultWave();
    }

    void SpawnEnemy()
    {
            //PoolManager.instance.ReusePool(enemy,transform.position, Quaternion.identity);
            GameObject superEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            LastEnemy = GameObject.Find(enemy.name + "(Clone)");
            superEnemy.transform.SetParent(storage.transform);
            Debug.Log("เวลาเพิ่มความถี่" + timeCountdown);
    }
    void DifficultWave()
    {
        timeCountdown -= Time.deltaTime;
        if (timeCountdown <= 0)
        {
            repeat -= 1;
            timeCountdown = 15f;
            if(repeat < 1)
            {
                repeat = 1;
            }
        }
    }
    public void SetParent(Transform parent)
    {
        transform.parent = parent;
    }
  
}