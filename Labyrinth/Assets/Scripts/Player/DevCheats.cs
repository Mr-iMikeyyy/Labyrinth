using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevCheats : MonoBehaviour
{
    public GameObject player;
    public void TeleportToCenter()
    {
        player.transform.position = new Vector3(0f, .5f, 0f);
    }

    public void WarnedYou()
    {
        PlayerStats.reduceHP(12);
    }

    public void IncreaseMaxHP()
    {
        PlayerStats.IncreaseMaxHP(1);
    }

    public void DecreaseMaxHP()
    {
        PlayerStats.DecreaseMaxHP(1);
    }

    public void FullHeal()
    {
        PlayerStats.increaseHP(12);
    }
}
