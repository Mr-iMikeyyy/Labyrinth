using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectPowerup : MonoBehaviour, ICollectible
{
    public int ItemID;

    public string ItemName;

    public void collect()
    {
        PlayerInventory.addPowerup(ItemID, ItemName);
        Destroy(gameObject);
    }

}
