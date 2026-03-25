using UnityEngine;

[RequireComponent(typeof(Mover))]
public class TankPawn : Pawn
{
    [HideInInspector] public Mover mover;
    [HideInInspector] public Shooter shooter;
    [HideInInspector] public Health health;
    [Header("Shooting Data")]
    public Projectile projectile;
    public float fireForce;
    public float damageDone;
    public float bulletLifespan;
    public float shotsPerSecond;
    private float nextShotTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        // This is where we put anything that only the TankPawn does
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();
        health = GetComponent<Health>();
        nextShotTime = Time.time;

        // Do what all Pawns do
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {

        // Do what all pawns do on Update
        base.Update();
    }

    public override void MoveForward()
    {
        mover.Move(transform.forward, moveSpeed);
    }

    public override void MoveBackward()
    {
        mover.Move(-transform.forward, moveSpeed);
    }

    public override void TurnClockwise()
    {
        mover.Turn(1, turnSpeed);
    }

    public override void TurnCounterClockwise()
    {
        mover.Turn(-1, turnSpeed);
    }

    public override void Shoot()
    {
        // If it is time to shoot
        if (Time.time >= nextShotTime) {
            // Shoot
            shooter.Shoot(projectile, fireForce, damageDone, bulletLifespan);
            // Set our next shot time
            nextShotTime = Time.time + (1 / shotsPerSecond);
        }
    }

    public override void Seek(Vector3 target)
    {
        mover.Seek(target, moveSpeed, turnSpeed);
    }


}
