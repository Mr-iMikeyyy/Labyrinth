using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UsePowerup
{
    private static bool hermesSandals;
    private static bool map;

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

    public static void activateMap()
    {
        map = true;
    }

    public static void deactivateMap()
    {
        map = false;
    }

    public static bool getMap()
    {
        return map;
    }

    public static void turnoffallpowerups()
    {
        map = false;
        hermesSandals = false;
    }
}
