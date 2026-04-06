using UnityEngine;

[System.Serializable]
public abstract class Powerup 
{
    [Tooltip("Use 0 or less for infinite duration!")] public float duration; 
    public abstract void Apply(PowerupManager target);
    public abstract void Remove(PowerupManager target);
}
