using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : Controller
{
    private InputAction moveAction;
    private InputAction shootAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        // If we have a game manager, and we have a list of players in that game manager,
        //       add this to the list of players
        if (GameManager.instance != null && GameManager.instance.players != null) 
        {
            GameManager.instance.players.Add(this);
        }

        // Load from the global actions
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Attack");

        // Do everything that the parent class does!
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // Because we are a player controller, we need to process inputs from the player
        ProcessInputs();

        // Do everything that the parent class does!
        base.Update();
    }

    public override void OnDestroy()
    {
        // If we have a game manager, and we have a list of players in that game manager,
        //       REMOVE this from the list of players
        if (GameManager.instance != null && GameManager.instance.players != null) {
            GameManager.instance.players.Remove(this);
        }

        // Do what the parent class does
        base.OnDestroy();
    }

    private void ProcessInputs()
    {

        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        if ( moveAction.IsPressed() ) {

            // Move Forward/Backward
            if (moveValue.y >= 0.5f) {
                pawn.MoveForward();
            }
            else if (moveValue.y <= -0.5f) {
                pawn.MoveBackward();
            }

            // Handle turns
            if (moveValue.x >= 0.5f) {
                pawn.TurnClockwise();
            } else if (moveValue.x <= -0.5f) {
                pawn.TurnCounterClockwise();
            }
        }




        // Shoot
        if ( shootAction.IsPressed() ) {
            // Shoot
        }

    }


}
