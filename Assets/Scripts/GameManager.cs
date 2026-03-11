using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Prefabs")]
    public Pawn playerPawn;
    public Controller playerController;
    [Header("Important Lists")]
    public List<PlayerController> players;
    public List<Pawn> pawns;
    [Header("Important Game Objects")]
    public FollowCamera camera;

    // Awake runs before Start runs
    void Awake()
    {
        // If there is no other game manager
        if (instance == null) {
            // Set THIS game manager to the variable "instance"
            instance = this;
        } else {
            // Otherwise, there is already a game manager...
            // So destroy this new one (death to the usurper!)
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeGame()
    {
        //TODO: Do what happens at the start of a game
        //TODO: Generate a random map

        // Spawn the player(s)
        SpawnPlayer();

        //TODO: Spawn AIs and get them the data they need to run
        //TODO: Set the players score to zero


    }

    private void SetFollowCamera (Transform target)
    {
        // Set the target
        camera.target = target;
    }

    private void EndGame()
    {
        // TODO: Do what happens when the game ends
    }

    private void SpawnPlayer(Vector3 position, Quaternion rotation)
    {
        // Spawn the player
        Pawn newPlayerPawn = Instantiate<Pawn>(playerPawn, position, rotation) as Pawn;
        Controller newPlayerController = Instantiate<Controller>(playerController, Vector3.zero, Quaternion.identity);

        // Cause the player to possess the player pawn
        newPlayerController.Possess(newPlayerPawn);

        // Set follow camera to follow them
        SetFollowCamera(newPlayerPawn.transform);
    }

    private void SpawnPlayer() 
    { 
        SpawnPlayer(Vector3.zero, Quaternion.identity);
    }
}
