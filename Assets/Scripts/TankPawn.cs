using UnityEngine;

[RequireComponent(typeof(Mover))]
public class TankPawn : Pawn
{
    [HideInInspector] public Mover mover;
    [HideInInspector] public Shooter shooter;
    [HideInInspector] public Health health;
    [HideInInspector] public NoiseMaker noiseMaker;
    [Header("Shooting Data")]
    public Projectile projectile;
    public float fireForce;
    public float damageDone;
    public float bulletLifespan;
    public float shotsPerSecond;
    public float shotVolume = 10.0f;
    private float nextShotTime;
    [Header("Movement Data")]
    public float moveVolume = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        // This is where we put anything that only the TankPawn does
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();
        health = GetComponent<Health>();
        noiseMaker = GetComponent<NoiseMaker>();
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
        if (mover != null)
        {
            mover.Move(transform.forward, moveSpeed);
        }
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
