using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int currency = 200;
    private float timeUp;
    void Start()
    {
        timeUp = 0;
    }

    void Update()
    {
        CountTimeup();
        if(timeUp >= 1)
        {
            currency += 5;
            timeUp = 0;
        }
    }
    void CountTimeup()
    {
        timeUp += Time.deltaTime;
    }
}
