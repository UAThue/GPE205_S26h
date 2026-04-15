using UnityEngine;
using UnityEngine.UI;

public class UIHealthCircle : MonoBehaviour
{
    public Health healthComponent;
    public Image healthCircleSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // NOTE: This is heavy on the processor -- we normally don't want to do a change EVERY draw. 
        //       Normally, we want to ONLY change the UI when the health changes. See: The observer pattern.
        // TODO: Switch this to use the observer pattern (when we learn it  in other classes)
        if (healthComponent != null)
        {
            UpdateHealthUI();
        } else
        {
            healthCircleSprite.fillAmount = 0;
        }
    }

    void UpdateHealthUI()
    {
        float percentHealth = healthComponent.currentHealth / healthComponent.maxHealth;
        healthCircleSprite.fillAmount = percentHealth;

        // Change color based on percentage of health
        if (percentHealth > 0.7f)
        {
            healthCircleSprite.color = Color.green;
        } 
        else if (percentHealth > 0.2f)
        {
            healthCircleSprite.color = Color.yellow;
        }
        else
        {
            healthCircleSprite.color = Color.red;
        }
    }

}
