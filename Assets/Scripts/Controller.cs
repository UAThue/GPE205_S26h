using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public Pawn pawn;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void Possess(Pawn pawnToPosses)
    {
        // Set the pawn for this controller
        pawn = pawnToPosses;
        // Set the controller for that pawn
        pawn.controller = this;
    }

    public virtual void UnPossess()
    {
        // Only unposess if we already have a pawn
        if (pawn != null) {
            // Remove the controller on the pawn
            pawn.controller = null;
            // Remove the pawn from this controller
            pawn = null;
        }
    }

}
