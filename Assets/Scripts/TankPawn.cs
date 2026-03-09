using UnityEngine;

[RequireComponent(typeof(Mover))]
public class TankPawn : Pawn
{
    [HideInInspector] public Mover mover;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        // TODO: This is where we put anything that only the TankPawn does
        mover = GetComponent<Mover>();

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





}
