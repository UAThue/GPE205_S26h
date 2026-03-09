using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPlayer()
    {
        // Spawn the player

        // Cause the player to possess the player pawn
    }
}
