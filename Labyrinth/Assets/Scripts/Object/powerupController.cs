using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupController : MonoBehaviour
{
    private bool alreadyActiveMap;
    public GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        alreadyActiveMap = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!alreadyActiveMap && UsePowerup.getMap())
        {
            alreadyActiveMap = true;
            map.SetActive(true);
            UsePowerup.deactivateMap();
        }
    }
}
