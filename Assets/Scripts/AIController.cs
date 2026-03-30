using UnityEngine;

public abstract class AIController : Controller
{
    public enum AIStates { Guard, Scan, Chase, Attack, BackToSpawn };
    protected AIStates currentState;
    protected float stateStartTime;
    protected Vector3 spawnPoint;
    protected Pawn targetToAttack;
    [Header("Sense Data")]
    public float hearingSensitivity = 1.0f; // 1 is normal, 2 is "twice normal", 0.5 is "half hearing"
    public float FOVAngle = 60.0f;
    public float sightDistance = 10.0f;
    public float eyeHeight = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        // Start in the guard state
        ChangeState(AIStates.Guard);

        // Save our spawn point
        spawnPoint = transform.position;

        // If our controller is ON a pawn, possess that pawn
        Pawn tempPawn = GetComponent<Pawn>();
        if (tempPawn != null) 
        {
            Possess(tempPawn);
        }

        // Call Controller start
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // TODO: Add player targeting to AI State Machine to target nearest player
        if (targetToAttack == null) {
            targetToAttack = GameManager.instance.players[0].pawn;
        }

        MakeDecisions();

        // Do what all controllers do
        base.Update();
    }

    protected abstract void MakeDecisions(); 

    public void ChangeState( AIStates newState )
    {
        // Change our state
        currentState = newState;
        // Save our state start time
        stateStartTime = Time.time;
    }

    protected virtual void DoIdle()
    {
        // Do Nothing! Later, we might add animations and sounds and other polish.
    }

    protected virtual void DoBackToSpawn()
    {
        pawn.Seek(spawnPoint);
    }

    protected virtual void DoScan()
    {
        // Turn the pawn clockwise
        pawn.TurnClockwise();

        // Target the first player you see
        foreach (Controller player in GameManager.instance.players)
        {
            if (player != null)
            {
                if (player.pawn != null)
                {
                    if (CanSee(player.pawn))
                    {
                        targetToAttack = player.pawn;
                        break;
                    }
                }
            }
        }

        //  Later, we might add animations, sound effects (radar ping) or other feedback
    }

    protected virtual void DoChase ( )
    {
        if (targetToAttack != null) {
            // Seek the target's position
            pawn.Seek(targetToAttack.transform.position);
        }
    }
    protected virtual void DoChase( Pawn target)
    {
        if (target != null) {
            // Seek the target's position
            pawn.Seek(target.transform.position);
        }
    }



    protected virtual void DoShoot()
    {
        // Shoot
        pawn.Shoot();
    }
 
    protected virtual bool CanSee ( Pawn target )
    {
        // Check for field of view
        // Find the vector to the target
        Vector3 vectorFromPawnToTarget = target.transform.position - pawn.transform.position;
        // Find the angle between our forward vector and our vector to target
        float AngleToTarget = Vector3.Angle(vectorFromPawnToTarget, pawn.transform.forward);
        // If that angle > our FOV, we can't see the object, it out of our FOV
        if (AngleToTarget > FOVAngle)
        {
            return false;
        }

        // Check for Line of Sight (and distance)
        RaycastHit hitData;
        Vector3 eyePosition = pawn.transform.position + (Vector3.up * eyeHeight);

        if (Physics.Raycast(eyePosition, vectorFromPawnToTarget, out hitData, sightDistance))
        {
            if ( hitData.collider.gameObject == target.gameObject)
            {
                return true;
            }
        }

        /** Check for Distance
         * NOTE: WE don't need to do this explicitly, it's part of our LOS
        if ( Vector3.Distance ( pawn.transform.position, target.transform.position) > sightDistance)
        {
            return false;
        }
        **/

        return false;
    }

    protected virtual bool CanHear (Pawn target)
    {
        // Check if the target is making noise
        NoiseMaker targetNoisemaker = target.GetComponent<NoiseMaker>();
        if (targetNoisemaker != null)
        {
            // Is it making noise (volume >0) ?
            if (targetNoisemaker.noiseVolume > 0)
            {
                // Are we close enough to hear the noise?
                float totalDistance = targetNoisemaker.noiseVolume + hearingSensitivity;
                if (Vector3.Distance(target.transform.position, pawn.transform.position) <= totalDistance)
                {
                    return true;
                }
            }
        }
        return false;
    }

    protected virtual bool HasTimePassed ( float time )
    {
        if ( Time.time > (stateStartTime + time) ) {
            return true;
        }
        return false;
    }

    public virtual bool IsDistanceGreaterThan(Vector3 position, float distance)
    {
        if (Vector3.Distance(pawn.transform.position, position) > distance) {
            return true;
        }
        else {
            return false;
        }
    }


    public virtual bool IsDistanceLessThan ( Vector3 position, float distance )
    {
        if (Vector3.Distance(pawn.transform.position, position) < distance) {
            return true;
        }
        else {
            return false;
        }
    }

}
