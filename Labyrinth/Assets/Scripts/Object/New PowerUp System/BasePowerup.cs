using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class BasePowerup : ScriptableObject{
    /// <summary>
    /// activation of the effect of the item
    /// </summary>
    public virtual void activateItem()
    {
        //activate item
    }
    public virtual int getItemID()
    {
        return 1;
    }

    public virtual string getItemName()
    {
        return "";
    }

    public virtual string getItemDescription()
    {
        return "";
    }

    public virtual bool MultiUse()
    {
        return true;
    }

    public virtual char getRarity()
    {
        return 'c';
    }
}
