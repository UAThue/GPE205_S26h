using UnityEngine;

public class TankShooter : Shooter
{
    public Transform shootPosition;
    public Pawn owner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        owner = GetComponent<Pawn>();
    }

    // Update is called once per frame
    public override void Update()
    {
    }

    public override void Shoot(Projectile projectile, float fireForce, float damageDone, float lifespan)
    {
        // Create the projectile
        Projectile newProjectile = Instantiate<Projectile>(projectile, 
                                                           shootPosition.position, 
                                                           shootPosition.rotation) as Projectile;
        // Set the damage done of the projectile
        DamageOnHit newDOH = newProjectile.GetComponent<DamageOnHit>();        
        if (newDOH != null) 
        {
            newDOH.damageDone = damageDone;
            newDOH.owner = owner;
        }
        
        // Add Force
        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
        if (rb != null) 
        {
            rb.AddForce(shootPosition.forward * fireForce); 
        }

        Destroy(newProjectile.gameObject, lifespan);
    }

}
