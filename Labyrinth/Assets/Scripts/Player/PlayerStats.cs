using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats {
    private static float MaxHP;
    private static float HP;
    private static float MaxSprint;
    private static float Sprint;
    private static GameObject timerObject;
    public static Timer timer;
    private static int currentLevel = 1;
    private static int maxLevel = 2;

    
    static PlayerStats()
    {
        timerObject = new GameObject("Timer");
        timer = timerObject.AddComponent<Timer>();
    }

    public static void setMaxHP(float x)
    {
        MaxHP = x;
    }
    public static void resetCurrentLevel() {
        currentLevel = 1;
    }
    public static void incrementCurrentLevel()
    {
        currentLevel += 1;
    }
    public static void setHP(float x)
    {
        HP = x;
    }
    public static void setSprint(float x)
    {
        Sprint = x;
    }
    public static void setMaxSprint(float x)
    {
        MaxSprint = x;
    }
    public static float getMaxHP()
    {
        return MaxHP;
    }
    public static float getHP()
    {
        return HP;
    }
    public static float getSprint()
    {
        return Sprint;
    }
    public static float getMaxSprint()
    {
        return MaxSprint;
    }
    public static int getCurrentLevel()
    {
        return currentLevel;
    }
    public static int getMaxLevel()
    {
        return maxLevel;
    }
}
