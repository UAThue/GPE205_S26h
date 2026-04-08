using UnityEngine;
using System.Collections.Generic;
using System;

public class MapGenerator : MonoBehaviour
{
    public enum MapType { Seeded, Random, MapOfTheDay }
    public MapType mapType;
    public int seed;
    public int rows;
    public int cols;
    public float width = 25;
    public float height = 25;
    public List<Tile> tilePrefabs;
    public Tile[,] grid;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SeedRandom()
    {
        if (mapType == MapType.Seeded)
        {
            UnityEngine.Random.InitState(seed);
        } else if (mapType == MapType.MapOfTheDay)
        {
            // Seed the RNG with today (but at the first moment of today)
            UnityEngine.Random.InitState( (int)DateTime.Now.Date.Ticks ) ; 
        } else
        {
            // mapType == mapType.Random -- Unity Seeds the RNG with the time you start the program, 
            //                              So, we don't really have to do anything to be "random"

        }

    }

    public void GenerateMap ()
    {
        // Seed the Random Number Generator
        SeedRandom();

        // Create our grid array, so that we can use it
        grid = new Tile[cols, rows];

        // For each ROW in our map...
        for (int currentRow = 0; currentRow < rows; currentRow++)
        {
            // For each COL in that row!
            for (int currentCol = 0; currentCol < cols; currentCol++)
            {
                // Copy a random tile and store in newTile
                Tile newTile = Instantiate<Tile>(GetRandomTile()) as Tile;

                // Move tile to correct position
                newTile.transform.position = new Vector3(currentCol * width,
                                                          0.0f,
                                                          currentRow * height);

                // Give my tile a meaningful name, so we can see it in the heirarchy
                newTile.gameObject.name = "Tile ( " +currentCol+" , " +currentRow+" )";

                // Parent their transform to THIS gameObject to organize them in the hierarchy
                newTile.transform.parent = this.transform;

                // TODO: Open the doors
                if ( currentCol != 0 )
                {
                    newTile.westDoor.SetActive(false);
                }

                if ( currentCol != cols-1 )
                {
                    newTile.eastDoor.SetActive(false);
                }

                if ( currentRow != 0 )
                {
                    newTile.southDoor.SetActive(false);
                }

                if ( currentRow != rows-1 )
                {
                    newTile.northDoor.SetActive(false);
                }


                // Save the tile to the grid
                grid[currentCol, currentRow] = newTile;
            }
        }

    }

    public Tile GetRandomTile ()
    {
        return tilePrefabs[UnityEngine.Random.Range(0, tilePrefabs.Count)];
    }

}
