using UnityEngine;

public class AIController_Headstart : AIController
{
    public float scanTime = 3;
    public float chaseDistance = 10;
    public float attackDistance = 20;
    public float backToPostDistance = 100;
    public float leadingDistance = 5.0f;

    protected override void MakeDecisions()
    {
        switch (currentState) 
        {
            case AIStates.Guard:
                // Do Work
                DoIdle();

                // Check for transitions
                if (CanHear(targetToAttack)) 
                {
                    ChangeState(AIStates.Scan);
                }
                break;
            case AIStates.Scan:
                // Do Work
                DoScan();
                // Check for transitions
                if (CanSee(targetToAttack)) 
                {
                    ChangeState(AIStates.Chase);
                }
                if (HasTimePassed(scanTime)) {
                    ChangeState(AIStates.BackToSpawn);
                }
                break;
            case AIStates.Chase:
                // Do Work
                DoChase(targetToAttack);

                // Check for transitions
                if (IsDistanceLessThan(targetToAttack.transform.position, chaseDistance))
                {
                    ChangeState(AIStates.Attack);
                }
                if (!CanSee(targetToAttack)) {
                    ChangeState(AIStates.Scan);
                }
                if (IsDistanceGreaterThan(targetToAttack.transform.position, backToPostDistance))
                {
                    ChangeState(AIStates.BackToSpawn);
                }
                break;
            case AIStates.Attack:
                // Do Work
                DoChase(targetToAttack);
                DoShoot();
                // Check for transitions
                if (IsDistanceGreaterThan(targetToAttack.transform.position, attackDistance))
                {
                    ChangeState(AIStates.Chase);
                }
                if (IsDistanceGreaterThan(targetToAttack.transform.position, backToPostDistance))
                {
                    ChangeState(AIStates.BackToSpawn);
                }
                break;
            case AIStates.BackToSpawn:
                // Do Work
                DoBackToSpawn();
                // Check for transitions
                if (IsDistanceLessThan(spawnPoint, chaseDistance))
                {
                    ChangeState(AIStates.Guard);
                }
                break;
        }


    }

    protected override void DoChase(Pawn target)
    {
        if (target != null)
        {
            // Seek the target's position
            pawn.Seek(target.transform.position + (target.transform.forward * leadingDistance ));
        }
    }

}
