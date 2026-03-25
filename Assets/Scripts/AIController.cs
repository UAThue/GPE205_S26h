using UnityEngine;

public abstract class AIController : Controller
{
    public enum AIStates { Guard, Scan, Chase, Attack, BackToSpawn };
    protected AIStates currentState;
    protected float stateStartTime;
    protected Vector3 spawnPoint;
    protected Pawn targetToAttack;

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
        // TODO: Add vision code
        return true;
    }

    protected virtual bool CanHear (Pawn target)
    {
        // TODO: Add hearing code
        return true;
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
