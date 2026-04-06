using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject objectToSpawn;
    public float timeToSpawn = 3.0f;
    public bool isSpawnedAtStart = true;
    private GameObject spawnedObject;
    private float timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Reset the timer
        timer = timeToSpawn;

        // If we spawn at start, then spawn
        if ( isSpawnedAtStart )
        {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If there is no object spawned 
        if (spawnedObject == null)
        {
            // Countdown the timer
            timer -= Time.deltaTime;
            // If the timer hits 0, spawn the object
            if (timer <= 0)
            {
                Spawn();
            }
        } 
        else
        {
            // Reset our timer
            timer = timeToSpawn;
        }
    }

    void Spawn ()
    {
        // Spawn the object at the spawn point
        spawnedObject = Instantiate<GameObject>(objectToSpawn, transform.position, transform.rotation) as GameObject;

        // Reset the timer
        timer = timeToSpawn;
    }
}
