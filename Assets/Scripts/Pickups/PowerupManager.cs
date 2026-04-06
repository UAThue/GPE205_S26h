using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public List<Powerup> powerups;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        // Create our list of powerups
        powerups = new List<Powerup>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for expired powerups
        CheckForExpiredPowerups();
    }

    public void CheckForExpiredPowerups()
    {
        List<Powerup> expiredPowerups = new List<Powerup>();

        // Look at each powerup in the list one at a time
        foreach (Powerup powerup in powerups)
        {
            // Decrease it's remaining duration
            powerup.duration -= Time.deltaTime;

            if (powerup.duration <= 0)
            { 
                // If it's duration has expired (is <= 0), then add to the "remove me" list
               expiredPowerups.Add(powerup);
            }
        }

        // Remove everything from the expired powerups list from the primary list
        foreach (Powerup powerup in expiredPowerups)
        {
            RemovePowerup(powerup);
        }
    }


    public void AddPowerup (Powerup powerupToAdd) 
    {
        // If it has a duration to worry about:
        if (powerupToAdd.duration > 0)
        {
            // Add to our list of powerups
            powerups.Add(powerupToAdd);
        }

        // Apply the powerup
        powerupToAdd.Apply(this);
    }
    public void RemovePowerup (Powerup powerupToRemove) 
    { 
        // Remove this from our list of powerups
        powerups.Remove(powerupToRemove);

        // "Undo" the powerup
        powerupToRemove.Remove(this);
    }
}
