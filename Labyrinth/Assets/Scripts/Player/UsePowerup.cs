using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UsePowerup
{
    public static void activate()
    {
        if (PlayerInventory.getCurrentID() != 0)
        {
            switch (PlayerInventory.getCurrentID())
            {
                case 1: //This item is...
                case 2: //This item is...
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
}
