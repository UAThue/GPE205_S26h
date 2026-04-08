using UnityEngine;
using System.Collections.Generic;

public class TankSpawnPoint : MonoBehaviour
{
    public static List<TankSpawnPoint> tankSpawnPoints;

    void Awake()
    {
        // If we haven't made a list in the static location, make the list
        if (tankSpawnPoints == null)
        {
            tankSpawnPoints = new List<TankSpawnPoint>();
        }
        // Add THIS spawnpoint to the list
        tankSpawnPoints.Add(this);
        
    }
}
