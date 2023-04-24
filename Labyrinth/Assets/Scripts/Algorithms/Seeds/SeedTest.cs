using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("27p3xg");
        Debug.Log(SeedFormulas.ConvertToNum("27p3xg"));
        Debug.Log(SeedFormulas.ConvertToSeed(SeedFormulas.ConvertToNum("27p3xg")));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
