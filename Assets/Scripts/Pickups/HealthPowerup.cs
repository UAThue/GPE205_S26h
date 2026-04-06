using UnityEngine;

[System.Serializable]
public class HealthPowerup : Powerup
{
    public float amountToHeal;

    public override void Apply(PowerupManager target)
    {        
        // Get the Health component of the target
        Health targetHealth = target.GetComponent<Health>();
        // If they have one
        if (targetHealth != null)
        {
            // Tell it to heal!
            targetHealth.Heal(amountToHeal);
        }
    }

    public override void Remove(PowerupManager target)
    {
        // Get the health component
        Health otherHealth = target.GetComponent<Health>();

        // If they have one
        if (otherHealth != null)
        {
            // Take Damage equal to the amount to heal
            otherHealth.TakeDamage(amountToHeal);
        }
    }
}
