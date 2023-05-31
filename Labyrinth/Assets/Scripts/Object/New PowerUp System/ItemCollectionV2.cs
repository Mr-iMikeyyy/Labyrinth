using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectionV2 : MonoBehaviour, ICollectible
{
    public BasePowerup power;
    public virtual void collect()
    {
        PlayerInventory.addPowerup(power);
        Destroy(gameObject);
    }

}
