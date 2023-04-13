using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a class to hold ID and Name of Powerup
public class powerup 
{
    private int powerUpID;
    private string powerUpName;

    public powerup()
    {
        powerUpID = 0;
        powerUpName = "Empty";
    }
    public powerup(int ID, string name)
    {
        powerUpID = ID;
        powerUpName = name;
    }

    public string getName()
    {
        return powerUpName;
    }

    public int getID()
    {
        return powerUpID;
    }
}
