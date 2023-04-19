using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UsePowerup
{
    private static bool hermesSandals;

    public static void activate()
    {
        if (PlayerInventory.getCurrentID() != 0)
        {

            switch (PlayerInventory.getCurrentID())
            {
                case 1: //This item is...
                case 2: //This item is Hermes Sandals
                    changeSandalBool();
                    break;
                case 3: //This item is...
                case 4: //This item is...
                case 5: //This item is...
                case 6: //This item is...
                default: //This item is...
                    break;
            }
            PlayerInventory.removePowerup();
        }
    }

    public static void changeSandalBool()
    {
        if (hermesSandals == true)
        {
            hermesSandals = false;
        }
        else 
        {
            hermesSandals = true;
        }
    }
    public static bool sandalsActive()
    {
        return hermesSandals;
    }
}
