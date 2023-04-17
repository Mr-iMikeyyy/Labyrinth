using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    

public class TimerClock : MonoBehaviour
{

    public TMP_Text time;
    
    void Start()
    {
        time.text = "00:00:00";
    }

    void Update()
    {
        Debug.Log(PlayerStats.timer.GetTime());
        // Display time in hh:mm:ss format; round to the nearest 2 decimal places.
        time.text = string.Format(
            "{0:00}:{1:00}:{2:00}",
            PlayerStats.getTimer().GetTime() / 3600,
            PlayerStats.getTimer().GetTime() / 60,
            PlayerStats.getTimer().GetTime() % 60
        );
    }
}
