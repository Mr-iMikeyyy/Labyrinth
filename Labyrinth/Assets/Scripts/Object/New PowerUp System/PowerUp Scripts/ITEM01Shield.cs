using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ITEM01Shield : BasePowerup
{
    protected int ItemID = 1; //used for sprite array.
    protected string ItemName = "Medusa's Shield"; //Name of Item
    protected string ItemDescription = "(Temp) Adds 1 health"; //Lore or Item Description
    protected char rarity = 'C'; //(C)ommon (U)ncommon (R)are (S)pecial (E)pic
    public override void activateItem()
    {
        PlayerStats.increaseHP(1);
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
