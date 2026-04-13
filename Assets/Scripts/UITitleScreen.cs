using UnityEngine;
using UnityEngine.InputSystem;

public class UITitleScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Go to Main Menu when any key is pressed!
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            GameManager.instance.ActivateMainMenuScreen();
        }
    }
}
