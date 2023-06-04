using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is called upon other classes to store data
public static class PlayerInventory 
{
    private static List<string> Keys = new List<string>();

    private static List<powerup> PowerupItem = new List<powerup>();

    public static int currentPowerup = 0;

    private static List<BasePowerup> NewSystem = new List<BasePowerup>();

    //this initializes the list
    public static void initPowerups()
    {
        //if (NewSystem.Count == 0)
        //{
        //    NewSystem.Add(new EmptyHand());
        //}
        if (NewSystem.Count == 0)
        {
            NewSystem.Add(ScriptableObject.CreateInstance<EmptyHand>());
        }
    }
    
    public static void ActivatePowerup()
    {
        if (currentPowerup != 0)
        {
            NewSystem[currentPowerup].activateItem();
        }
        if (!NewSystem[currentPowerup].MultiUse())
        {
            removePowerup();
        }
    }

    //adds the powerup to the list
    public static void addPowerup(int ID, string power)
    {
        PowerupItem.Add(new powerup(ID, power));
    }

    public static void addPowerup(BasePowerup ad)
    {
        NewSystem.Add(ad);
    }

    //checks the name of the previous powerup
    public static string checkPrevious()
    {
        if (currentPowerup - 1 < 0)
        {
            //return PowerupItem[PowerupItem.Count - 1].getName();
            return NewSystem[NewSystem.Count - 1].getItemName();
        }
        return NewSystem[NewSystem.Count - 1].getItemName();
    }

    //checks the name of the current powerup
    public static string checkCurrentPower()
    {
        //return PowerupItem[currentPowerup].getName();
        return NewSystem[currentPowerup].getItemName();
    }


    //checks the name of the next powerup
    public static string checkNext()
    {
        //if (currentPowerup + 1 >= PowerupItem.Count)
        if (currentPowerup + 1 >= NewSystem.Count)
        {
            //return PowerupItem[0].getName();
            return NewSystem[0].getItemName();
        }
        //return PowerupItem[currentPowerup + 1].getName(); 
        return NewSystem[currentPowerup + 1].getItemName();
    }

    public static int getPrevID()
    {
        if (currentPowerup - 1 < 0)
        {
            //return PowerupItem[PowerupItem.Count - 1].getID();
            return NewSystem[NewSystem.Count - 1].getItemID();
        }
        //return PowerupItem[currentPowerup - 1].getID();
        return NewSystem[currentPowerup - 1].getItemID();
    }

    //checks the ID of the current Powerup
    public static int getCurrentID()
    {
        //return PowerupItem[currentPowerup].getID();
        return NewSystem[currentPowerup].getItemID();
    }

    public static int getNextID()
    {
        //if (currentPowerup + 1 >= PowerupItem.Count)
        if (currentPowerup + 1 >= NewSystem.Count)
        {
            //return PowerupItem[0].getID();
            return NewSystem[0].getItemID();
        }
        //return PowerupItem[currentPowerup + 1].getID();
        return NewSystem[currentPowerup + 1].getItemID();
    }

    //remove the current powerup in the list
    public static void removePowerup()
    {
        //PowerupItem.Remove(PowerupItem[currentPowerup]);
        NewSystem.Remove(NewSystem[currentPowerup]);
        currentPowerup -= 1;
    }

    //rotates to the previous numvber
    public static void leftRotatePower()
    {
        currentPowerup -= 1;
        if (currentPowerup < 0) //rotates to the last number
        {
            //currentPowerup = PowerupItem.Count - 1;
            currentPowerup = NewSystem.Count - 1;
        }
    }
    //rotates to the next number
    public static void rightRotatePower()
    {
        currentPowerup += 1;
        //if (currentPowerup >= PowerupItem.Count) //rotates to the first number
        if (currentPowerup >= NewSystem.Count)
        {
            currentPowerup = 0;
        }
    }

    //Key system.
    //----------------------------------------------------------------------------------------------------------------------
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
