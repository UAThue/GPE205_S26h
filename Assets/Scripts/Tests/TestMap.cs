using UnityEngine;
using UnityEngine.InputSystem;

public class TestMap : MonoBehaviour
{

    void Start()
    {
        GameManager.instance.ActivateTitleScreen();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            GameManager.instance.ActivateTitleScreen();
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            GameManager.instance.ActivateMainMenuScreen();
        }
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            GameManager.instance.ActivateSettingsScreen();
        }
        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            GameManager.instance.ActivateCreditsScreen();
        }
        if (Keyboard.current.digit5Key.wasPressedThisFrame)
        {
            GameManager.instance.ActivateGameplayScreen();
        }
        if (Keyboard.current.digit6Key.wasPressedThisFrame)
        {
            GameManager.instance.ActivateGameOverScreen();
        }



    }
}
