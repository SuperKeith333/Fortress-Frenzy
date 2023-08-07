using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayloadScript : MonoBehaviour
{
    public float StartTime = 900;
    public string ActualTime = "15:00";

    void Update()
    {
        if (StartTime > 0)
        {
            StartTime -= Time.deltaTime;
            int minuteamount = TimeSpan.FromSeconds(StartTime).Minutes;
            int secondamount = TimeSpan.FromSeconds(StartTime).Seconds;
            ActualTime = minuteamount.ToString() + ":" + secondamount.ToString();
        }
    }
}
