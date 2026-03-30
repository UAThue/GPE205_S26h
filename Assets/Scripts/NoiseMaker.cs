using UnityEngine;

public class NoiseMaker : MonoBehaviour
{
    public float noiseVolume;
    public float noiseDecayPerSecond = 2.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Decay our noise volume
        DecayNoise();
    }

    public void MakeNoise (float volumeLevel)
    {
        if (volumeLevel >= noiseVolume)
        {
            noiseVolume = volumeLevel;
        } 
    }

    public void DecayNoise ()
    {
        noiseVolume -= noiseDecayPerSecond * Time.deltaTime;
        if (noiseVolume < 0) { noiseVolume = 0; }
    }

}
