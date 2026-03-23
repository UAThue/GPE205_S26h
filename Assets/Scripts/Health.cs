using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public bool isMaxHealthOnStart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isMaxHealthOnStart) 
        {
            currentHealth = maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Heal ( float amount )
    {
        currentHealth += amount; 
        if (currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }
    }

    public virtual void TakeDamage( float amount )
    {
        currentHealth = currentHealth - amount;
        CheckForDeath();
    }

    public virtual void CheckForDeath()
    {
        if ( currentHealth <= 0 ) 
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
