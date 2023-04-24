using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SeedFormulas
{
    private static string base36 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static string lowercase = "abcdefghijklmnopqrstuvwxyz";
    private static int SeedNum;
    private static string Seed;
    //private static long find;
    private static long Seedheld;
    private static UnityEngine.Random.State state;

    //converts the seed to a usable int number
    public static int ConvertToNum(string seed)
    {
        //needs to be done to not bypass the the int limit
        Seedheld = -1000000000;

        //for loop to calculate seed
        for (int x = 0; seed.Length > x; x++)
        {
            //if lowercase letter change to uppercase then do maths
            if (lowercase.Contains(seed[x]))
            {
                Seedheld += base36.IndexOf(Char.ToUpper(seed[x])) * (int)MathF.Pow(36 , Seed.Length - x - 1);
            }
            //if uppercase letter or number do maths
            else if (base36.Contains(seed[x])) {
                Seedheld += base36.IndexOf(seed[x]) * (int)Math.Pow(36, (Seed.Length - x - 1));
            }
            //ignores the char
            else
            {
                Seedheld += 0;
            }
        }

        //if seed is invalid
        if (Seedheld == -1000000000)
        {
            seed = createSeed();
            for (int x = 0; seed.Length > x; x++)
            {
                //if lowercase letter change to uppercase then do maths
                if (lowercase.Contains(seed[x]))
                {
                    Seedheld += base36.IndexOf(Char.ToUpper(seed[x])) * (int)MathF.Pow(36, Seed.Length - x - 1);
                }
                //if uppercase letter or number do maths
                else if (base36.Contains(seed[x]))
                {
                    Seedheld += base36.IndexOf(seed[x]) * (int)Math.Pow(36, (Seed.Length - x - 1));
                }
                //ignores the char
                else
                {
                    Seedheld += 0;
                }
            }
        }

        //converts it back into a 32bit int
        SeedNum = Convert.ToInt32(Seedheld);
        return SeedNum;
    }


    //Unneeded Method for mostly testing maths
    /*public static string ConvertToSeed(int num)
    {
        Seed = "";
        Seedheld = SeedNum + 1000000000;

        while (Seedheld != 0) {
            find = Seedheld % 36L;
            Seedheld = Seedheld / 36;
            Seed = base36[Convert.ToInt32(find)].ToString() + Seed;
        }

        return Seed;
    }*/

    //creates a seed
    public static string createSeed()
    {
        string createdSeed = "";
        for (int x = 0; x < 6; x++)
        {
            createdSeed += base36[UnityEngine.Random.Range(0, 36)];
        }
        return createdSeed;
    }

    //gets the current seed
    public static string getSeed()
    {
        return Seed;
    }

    //sets the current seed
    public static void setSeed(string s)
    {
        Seed = s;
        UnityEngine.Random.InitState(ConvertToNum(Seed));
    }
    
    //saves the state of RNG
    public static void saveState()
    {
        state = UnityEngine.Random.state;
    }

    //loads the state of RNG
    public static void loadState()
    {
        UnityEngine.Random.state = state;
    }
}

