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
    private static long find;
    private static long Seedheld;

    public static int ConvertToNum(string seed)
    {
        Seed = seed;
        Seedheld = -1000000000;

        for (int x = 0; Seed.Length > x; x++)
        {
            if (lowercase.Contains(Seed[x]))
            {
                Seedheld += base36.IndexOf(Char.ToUpper(seed[x])) * (int)MathF.Pow(36 , Seed.Length - x - 1);
            }
            else if (base36.Contains(seed[x])) {
                Seedheld += base36.IndexOf(seed[x]) * (int)Math.Pow(36, (Seed.Length - x - 1));
            }
            else
            {
                Seedheld += 0;
            }
        }

        SeedNum = Convert.ToInt32(Seedheld);
        return SeedNum;
    }


    public static string ConvertToSeed(int num)
    {
        Seed = "";
        Seedheld = SeedNum + 1000000000;

        while (Seedheld != 0) {
            find = Seedheld % 36L;
            Seedheld = Seedheld / 36;
            Seed = base36[Convert.ToInt32(find)].ToString() + Seed;
        }

        return Seed;
    }

    public static string getSeed(){
        return Seed;
    }
}

