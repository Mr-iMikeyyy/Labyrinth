using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    //The Slider
    public Slider Bar;

    public CanvasGroup can;
    

    //takes info from player stats and tranlate them into a bar
    void Start()
    {
        Bar.maxValue = PlayerStats.getMaxSprint();
        Bar.value = PlayerStats.getSprint();
        can.alpha = 0;
        InvokeRepeating(nameof(Hide), .1f , .1f);
    }

    // Updates the above info every frame.
    void Update()
    {
        Bar.maxValue = PlayerStats.getMaxSprint();
        Bar.value = PlayerStats.getSprint() + 1;

        show();
    }

    public void Hide()
    {
        if (Bar.maxValue <= Bar.value && can.alpha > 0)
        {
            can.alpha -= 0.05f;
        }
    }

    void show()
    {
        if (Bar.maxValue > Bar.value)
        {
            can.alpha = 1;
        }
    }

}
