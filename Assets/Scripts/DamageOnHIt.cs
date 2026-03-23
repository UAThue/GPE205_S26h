using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class DamageOnHit : MonoBehaviour
{
    public float damageDone;
    public Pawn owner;
    private Collider col;

    public void Start ()
    {
        // Get the collider component
        col = GetComponent<Collider>();
        // Set it to a trigger (in case our designers forgot to)
        col.isTrigger = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        // Check to see if the other object has a health component!
        Health otherHealth = other.gameObject.GetComponent<Health>();
        if (otherHealth != null ) {
            // Cause damage
            otherHealth.TakeDamage(damageDone);
        }

        // Destroy this object
        Destroy(gameObject);
    }
}
