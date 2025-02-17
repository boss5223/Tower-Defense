﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int currency = 200;
    public static float timeUp;
    public static float timeIngame;
    public static float prepairingTime;
    public static int towerPoint;
    void Start()
    {
        Application.targetFrameRate = 60;
        prepairingTime = 5f;
        timeIngame = 90f;
        towerPoint = 20;
    }

    void Update()
    {
        CountPreTime();
        if (prepairingTime <= 0)
        {
            CountTimeup();
            CountTimeGame();
        }
        TimeControl();
        SetTowerPoint();
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
}
