using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int currency = 200;
    public static float timeUp;
    public static float timeIngame;
    public static float prepairingTime;
    void Start()
    {
        prepairingTime = 5f;
        timeIngame = 65f;
    }

    void Update()
    {
        CountPreTime();
        if (prepairingTime <= 0)
        {
            CountTimeup();
            CountTimeGame();
        }
        if(timeIngame <= 0)
        {
            timeIngame = 0;
            //EndGame;
        }
        if(timeUp >= 1)
        {
            currency += 5;
            timeUp = 0;
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
}
