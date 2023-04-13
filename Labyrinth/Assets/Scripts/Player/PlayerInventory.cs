using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is called upon other classes to store data
public static class PlayerInventory 
{
    private static List<string> Keys = new List<string>();

    private static List<powerup> PowerupItem = new List<powerup>();

    public static int currentPowerup = 0;

    //this initializes the list
    public static void initPowerups()
    {
        if (PowerupItem.Count == 0)
        {
            PowerupItem.Add(new powerup());
        }
    }

    //adds the powerup to the list
    public static void addPowerup(int ID, string power)
    {
        PowerupItem.Add(new powerup(ID, power));
    }

    //checks the name of the previous powerup
    public static string checkPrevious()
    {
        if (currentPowerup - 1 < 0)
        {
            return PowerupItem[PowerupItem.Count - 1].getName();
        }
        return PowerupItem[currentPowerup - 1].getName();
    }

    //checks the name of the current powerup
    public static string checkCurrentPower()
    {
        return PowerupItem[currentPowerup].getName();
    }


    //checks the name of the next powerup
    public static string checkNext()
    {
        if (currentPowerup + 1 >= PowerupItem.Count)
        {
            return PowerupItem[0].getName();
        }
        return PowerupItem[currentPowerup + 1].getName();
    }

    public static int getPrevID()
    {
        if (currentPowerup - 1 < 0)
        {
            return PowerupItem[PowerupItem.Count - 1].getID();
        }
        return PowerupItem[currentPowerup - 1].getID();
    }
    //checks the ID of the current Powerup
    public static int getCurrentID()
    {
        return PowerupItem[currentPowerup].getID();
    }

    public static int getNextID()
    {
        if (currentPowerup + 1 >= PowerupItem.Count)
        {
            return PowerupItem[0].getID();
        }
        return PowerupItem[currentPowerup + 1].getID();
    }
    //remove the current powerup in the list
    public static void removePowerup()
    {
        PowerupItem.Remove(PowerupItem[currentPowerup]);
        currentPowerup -= 1;
    }

    //rotates to the previous numvber
    public static void leftRotatePower()
    {
        currentPowerup -= 1;
        if (currentPowerup < 0) //rotates to the last number
        {
            currentPowerup = PowerupItem.Count - 1;
        }
    }
    //rotates to the next number
    public static void rightRotatePower()
    {
        currentPowerup += 1;
        if (currentPowerup >= PowerupItem.Count) //roatates to the first number
        {
            currentPowerup = 0;
        }
    }



    //removes ALL keys from the list
    public static void resetKeys()
    {
        Keys = new List<string>();
    }
    //adds 1 key to the list
    public static void addKey(string keytype)
    {
        Keys.Add(keytype);
    }
    //Removes 1 key from the list
    public static void removeKey (string keytype)
    {
        Keys.Remove(keytype);
    }
    //checks if key exists
    public static bool checkKeys (string keytype)
    {
        return Keys.Contains(keytype);
    }

}
