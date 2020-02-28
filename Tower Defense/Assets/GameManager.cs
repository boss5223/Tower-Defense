using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int currency = 350;
    public static float timeUp;
    public static float timeIngame;
    public static float prepairingTime;
    public static int towerPoint;
    public GameObject SpawnPoint;
    public static int monsterInField=0 ;
    GameObject[] countEnemy;
    GameObject[] countTurrets;
    public static GameObject turretRemaining;
    void Start()
    {
        Application.targetFrameRate = 60;
        prepairingTime = 5f;
        timeIngame = 90f;
        towerPoint = 20;
        Invoke("CountMonster", 94.9f);
    }

    void Update()
    {
        CountPreTime();
        if (prepairingTime <= 0)
        {
            CountTimeup();
            CountTimeGame();
        }
        SetTowerPoint();
        CountTurrets();
        TimeControl();
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
    void CountPreTime()
    {
        prepairingTime -= Time.deltaTime;
    }
    void CountTimeup()
    {
        timeUp += Time.deltaTime;
    }
    void CountTimeGame()
    {
        timeIngame -= Time.deltaTime;

    }
    void TimeControl()
    {
        if(timeIngame <= 10)
        {
            Destroy(SpawnPoint);

        }
        if (timeIngame <= 0)
        {
            timeIngame = 0;
            //EndGame;
        }
        if (timeUp >= 1)
        {
            currency += 5;
            timeUp = 0;
        }
    }
    void SetTowerPoint()
    {
        if (towerPoint < 0)
        {
            towerPoint = 0;
        }
    }
    void CountMonster()
    {
        countEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        for (monsterInField = 0; monsterInField < countEnemy.Length; monsterInField++)
        {
            monsterInField += 1;
        }
        Debug.Log("จำนวนมอนสเตอร์" + monsterInField);
    }
    void CountTurrets()
    {
        countTurrets = GameObject.FindGameObjectsWithTag("Turrets");
        for (int amountTurret = 0; amountTurret < countTurrets.Length; amountTurret++)
        {
            turretRemaining = countTurrets[amountTurret];
        }
    }
}
