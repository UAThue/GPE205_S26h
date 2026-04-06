using UnityEngine;

[RequireComponent (typeof(Collider))]
public class HealthPickup : Pickup
{
    public HealthPowerup healthPowerup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        // Even if our designers forget to set the collider to a trigger, we will still make it a trigger
        Collider collider = GetComponent<Collider>();
        collider.isTrigger = true;

        // Do what the parent class does
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // Do what the parent class does
        base.Update();
    }

    public void OnTriggerEnter(Collider other)
    {
        // Check of the other objects has a powerup manager
        PowerupManager otherPowerupManager = other.GetComponent<PowerupManager>();

        // If yes,
        if (otherPowerupManager != null)
        {
            // Apply our powerup to their powerup manager
            otherPowerupManager.AddPowerup(healthPowerup);

            // Destroy this object ( so it looks like we picked it up. ) 
            Destroy(gameObject);
        }
    }
}
