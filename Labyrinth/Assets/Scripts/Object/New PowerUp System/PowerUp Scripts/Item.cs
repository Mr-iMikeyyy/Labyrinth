using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : BasePowerup
{
    protected int ItemID = 0; //used for sprite array.
    protected string ItemName = "Empty"; //Name of Item
    protected string ItemDescription = "There was nothing, There is nothing."; //Lore or Item Description
    protected char rarity = 'C'; //(C)ommon (U)ncommon (R)are (S)pecial (E)pic
    public override void activateItem()
    {
        
    }

    public override int getItemID()
    {
        return ItemID;
    }

    public override string getItemName()
    {
        return ItemName;
    }

    public override string getItemDescription()
    {
        return ItemDescription;
    }

    public override bool MultiUse()
    {
        return false;
    }

    public override char getRarity()
    {
        return rarity;
    }
}
