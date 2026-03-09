using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public float turnSpeed = 180;
    public float moveSpeed = 10;

    [HideInInspector] public Controller controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    // Abstract functions for movement
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void TurnClockwise();
    public abstract void TurnCounterClockwise();
}
