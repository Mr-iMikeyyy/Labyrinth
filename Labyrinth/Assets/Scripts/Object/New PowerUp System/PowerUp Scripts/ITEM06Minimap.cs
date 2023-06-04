using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITEM06Minimap : BasePowerup
{
    protected int ItemID = 6; //used for sprite array.
    protected string ItemName = "Map"; //Name of Item
    protected string ItemDescription = "A piece of parchment you can keep track of your location with."; //Lore or Item Description
    protected char rarity = 'C'; //(C)ommon (U)ncommon (R)are (S)pecial (E)pic

    public override void activateItem()
    {
        UsePowerup.activateMap();
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
