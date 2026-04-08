using UnityEngine;

public class TestMap : MonoBehaviour
{

    public MapGenerator mapGenerator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mapGenerator.GenerateMap();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
