using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //    string formula = SeedFormulas.createSeed();
        //    Debug.Log(formula);
        //    Debug.Log(SeedFormulas.ConvertToNum(formula));
        //    Debug.Log(SeedFormulas.ConvertToSeed(SeedFormulas.ConvertToNum(formula)));

        SeedFormulas.setSeed("AXW8P9");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
