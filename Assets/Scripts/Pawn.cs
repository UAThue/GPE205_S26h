using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public float turnSpeed = 180;
    public float moveSpeed = 10;

    [HideInInspector] public Controller controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        // If we have a game manager, and we have a list of pawns in that game manager,
        //       add this to the list of pawns
        if (GameManager.instance != null && GameManager.instance.pawns != null) {
            GameManager.instance.pawns.Add(this);
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void OnDestroy()
    {
        // If we have a game manager, and we have a list of pawns in that game manager,
        //       REMOVE this from the list of pawns
        if (GameManager.instance != null && GameManager.instance.pawns != null) {
            GameManager.instance.pawns.Remove(this);
        }
    }

    // Abstract functions for movement
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void TurnClockwise();
    public abstract void TurnCounterClockwise();
}
