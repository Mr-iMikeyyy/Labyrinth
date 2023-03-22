using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is called upon other classes to store data
public static class PlayerInventory 
{
    public static List<string> Keys = new List<string>();

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
