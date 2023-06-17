using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats {
    
    public static string Name { get; set; }
    public static Timer timer { get; set; }
    private static int MaxHP = 3;
    private static int HP = 3;
    private static float MaxSprint;
    private static float Sprint;
    private static GameObject timerObject;
    private static int currentLevel = 1;
    private static int maxLevel = 2;
    public static float totalTime;
    private static bool invincibility = false;
    private static float invincibilityTimeLimit = 3f;
    
    static PlayerStats()
    {
        timerObject = new GameObject("Timer");
        timer = timerObject.AddComponent<Timer>();
        totalTime = 0f;
    }

    /// <summary>
    /// Implement a reset for everything bundled into 1 command
    /// </summary>
    public static void resetEverything()
    {
        currentLevel = 1;
        totalTime = 0f;
        invincibility = false;
        HP = 3;
        MaxHP = 3;
    }

    public static void resetCurrentLevel() {
        currentLevel = 1;
    }
    public static void incrementCurrentLevel()
    {
        currentLevel += 1;
    }

    public static void setSprint(float x)
    {
        Sprint = x;
    }
    public static void setMaxSprint(float x)
    {
        MaxSprint = x;
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
    public static Timer getTimer()
    {
        return timer;
    }
    public static GameObject getTimerObject()
    {
        return timerObject;
    }

    public static void resetTotalTime()
    {
        totalTime = 0;
    }

    public static int getHP()
    {
        return HP;
    }

    public static int getMaxHP()
    {
        return MaxHP;
    }

    public static void reduceHP(int reduction) {
        if (invincibility == false)
        {
            HP -= reduction;
            if (HP < 0)
            {
                HP = 0;
            }
            invincibility = true;
        }
    }

    public static void increaseHP(int increment)
    {
        HP += increment;
        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
    }
    public static void DecreaseMaxHP(int reduction)
    {
        MaxHP -= reduction;
        if (MaxHP < 1)
        {
            MaxHP = 1;
        }

    }
    public static void IncreaseMaxHP(int increment)
    {
        MaxHP += increment;
        if (MaxHP > 12)
        {
            MaxHP = 12;
        }
        increaseHP(increment);
    }

    public static void SetHP(int change)
    {
        HP = change;
    }

    public static void SetMaxHP(int change)
    {
        MaxHP = change;
    }

    public static bool getInvincibilityState()
    {
        return invincibility;
    }

    public static void setInvincibilty(bool invinci)
    {
        invincibility = invinci;
    }

    public static float getInvincibilityTimeLimit()
    {
        return invincibilityTimeLimit;
    }


}
