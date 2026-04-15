using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Prefabs")]
    public Pawn playerPawnPrefab;
    public PlayerController playerControllerPrefab;
    public UIPlayerUI playerUIprefab;
    [Header("Important Lists")]
    public List<PlayerController> players;
    public List<Pawn> pawns;
    [Header("Important Game Objects")]
    public FollowCamera followCamera;
    public MapGenerator mapGenerator;
    [Header("Game State Objects")]
    public GameObject titleScreen;
    public GameObject mainMenuScreen;
    public GameObject creditsScreen;
    public GameObject settingsScreen;
    public GameObject gameplayScreen;
    public GameObject gameOverScreen;
    [Header("GameData")]
    public int livesAtStart;
    public int numberOfPlayers;
    public int maxPlayers;

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
        ActivateTitleScreen();

        // Initialize our player list to the max number of players
        // Step 1: Create the list
        players = new List<PlayerController>(maxPlayers);
        // Step 2: Add "nothing" to the list enough times to make the list the right size
        for (int i = 0; i < maxPlayers; i++)
        {
            players.Add(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateAllGameScreens()
    {
        titleScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
        creditsScreen.SetActive(false);
        settingsScreen.SetActive(false);
        gameplayScreen.SetActive(false);
        gameOverScreen.SetActive(false);
}

    public void ActivateTitleScreen()
    {
        DeactivateAllGameScreens();
        titleScreen.SetActive(true);
    }
    public void ActivateMainMenuScreen()
    {
        DeactivateAllGameScreens();
        mainMenuScreen.SetActive(true);
    }
    public void ActivateCreditsScreen()
    {
        DeactivateAllGameScreens();
        creditsScreen.SetActive(true);
    }
    public void ActivateSettingsScreen()
    {
        DeactivateAllGameScreens();
        settingsScreen.SetActive(true);
    }
    public void ActivateGameOverScreen()
    {
        DeactivateAllGameScreens();
        gameOverScreen.SetActive(true);
    }
    public void ActivateGameplayScreen()
    {
        DeactivateAllGameScreens();
        gameplayScreen.SetActive(true);

        InitializeGame();
    }

    private void InitializeGame()
    {
        //TODO: Do what happens at the start of a game

        //Generate a random map
        mapGenerator.GenerateMap();

        // Spawn the player(s)
        SpawnPlayer(0);
        SpawnPlayer(1);
        SpawnPlayer(2);

        //TODO: Spawn AIs and get them the data they need to run
        //TODO: Set the players score to zero


    }

    private void SetFollowCamera (Transform target)
    {
        // Set the target
        followCamera.target = target;
    }

    private void EndGame()
    {
        // TODO: Do what happens when the game ends
    }




    private void SpawnPlayer(Vector3 position, Quaternion rotation, int playerNumber)
    {
        // Spawn the player
        Pawn newPlayerPawn = Instantiate<Pawn>(playerPawnPrefab, position, rotation) as Pawn;
        PlayerController newPlayerController = Instantiate<PlayerController>(playerControllerPrefab, Vector3.zero, Quaternion.identity);

        // Cause the player to possess the player pawn
        newPlayerController.Possess(newPlayerPawn);

        // TODO: When we get to multiplayer, spawn a follow camera for them, then set this camera to follow them
        // Set follow camera to follow them
        SetFollowCamera(newPlayerPawn.transform);

        // Spawn their Canvas UI
        UIPlayerUI tempPlayerUI = Instantiate<UIPlayerUI>(playerUIprefab);

        // TODO: Attach it to the camera -- when we get to multiplayer, this needs to be the spawned camera, NOT the main camera
        Canvas tempCanvas = tempPlayerUI.GetComponent<Canvas>();
        tempCanvas.worldCamera = Camera.main;

        // Set the player number abd okater controller
        tempPlayerUI.UpdatePlayerNumber(playerNumber);
        tempPlayerUI.playerController = newPlayerController;

        // Put us in the list of players
        players[playerNumber] = newPlayerController;

    }

    private void SpawnPlayer(int playerNumber) 
    {
        if (TankSpawnPoint.tankSpawnPoints != null && TankSpawnPoint.tankSpawnPoints.Count > 0)
        {
            TankSpawnPoint spawnPoint = TankSpawnPoint.tankSpawnPoints[Random.Range(0, TankSpawnPoint.tankSpawnPoints.Count)];
            SpawnPlayer(spawnPoint.transform.position, spawnPoint.transform.rotation, playerNumber);            
        }
        else
        {
            SpawnPlayer(Vector3.zero, Quaternion.identity, playerNumber);
        }
    }

    private void SpawnPlayer ()
    {
        SpawnPlayer(0);
    }
}
