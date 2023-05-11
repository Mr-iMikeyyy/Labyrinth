using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    [SerializeField] private Sprite[] heartstates;
    [SerializeField] private GameObject[] hearts;
    private float invincibilityFrames = 0f;
    private int currentHP;
    private int currentMaxHP;
    private bool alreadyadjusting = false;

    void Start()
    {
        currentMaxHP = PlayerStats.getMaxHP();
        currentHP = PlayerStats.getHP();

        //for loop initializes the HUD and current HP stats
        for (int x = 0; x < currentMaxHP; x++)
        {
            //turns on the active hearts
            hearts[x].SetActive(true);

            //checks if hearts are broken and sets them
            if (x < currentHP)
            {
                hearts[x].GetComponent<SpriteRenderer>().sprite = heartstates[0];
            }
            else
            {
                hearts[x].GetComponent<SpriteRenderer>().sprite = heartstates[1];
            }
        }

        //player not invincible when starting level
        PlayerStats.setInvincibilty(false);
    }

    // Update is called once per frame
    void Update()
    {
        updateHP();
        invincibilityHandler();
    }


    private void invincibilityHandler()
    {
        if (PlayerStats.getInvincibilityState())
        {
            invincibilityFrames += Time.deltaTime;
            if (invincibilityFrames > PlayerStats.getInvincibilityTimeLimit())
            {
                invincibilityFrames = 0;
                PlayerStats.setInvincibilty(false);
            }
        }
    }
    /// <summary>
    /// Updates the HP Value on HUD
    /// </summary>
    private void updateHP()
    {
        //checks if its already adjusting
        if (!alreadyadjusting)
        {
            if (currentMaxHP != PlayerStats.getMaxHP())
            {
                alreadyadjusting = true;
                adjustMaxHP();
            }
            else if (currentHP != PlayerStats.getHP())
            {
                alreadyadjusting = true;
                AdjustCurrentHP();
            }
            alreadyadjusting = false;
        }
    }
    /// <summary>
    /// Adjusts the number of hearts that show up on the screen
    /// </summary>
    private void adjustMaxHP()
    {
        //checks to increment or decrement
        if (PlayerStats.getMaxHP() > currentMaxHP)
        {
            IncrementMaxHP();
        }
        else
        {
            DecrementMaxHP();
        }

        currentMaxHP = PlayerStats.getMaxHP();
    }

    /// <summary>
    /// increments the number of hearts on the screen
    /// </summary>
    private void IncrementMaxHP()
    {
        for (int x = currentMaxHP; x < PlayerStats.getMaxHP(); x++)
        {
            hearts[x].SetActive(true);
        }
        AdjustCurrentHP();
    }

    /// <summary>
    /// decrements the number of hearts on the screen
    /// </summary>
    private void DecrementMaxHP()
    {
        for (int x = currentMaxHP; x > PlayerStats.getMaxHP(); x--)
        {
            hearts[x-1].SetActive(false); ;
        }
        AdjustCurrentHP();
    }

    /// <summary>
    /// changes the hearts that shows up on the screen to be broken or not.
    /// </summary>
    private void AdjustCurrentHP()
    {
        currentHP = PlayerStats.getHP();
        for (int x = 0; x < currentMaxHP; x++)
        {
            if (x < PlayerStats.getHP())
            {
                hearts[x].GetComponent<SpriteRenderer>().sprite = heartstates[0];
            }
            else
            {
                hearts[x].GetComponent<SpriteRenderer>().sprite = heartstates[1];
            }
        }
    }
}
