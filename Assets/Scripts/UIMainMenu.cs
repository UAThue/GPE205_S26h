using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSettingsButtonClicked ()
    {
        GameManager.instance.ActivateSettingsScreen();
    }

    public void OnCreditsButtonClicked()
    {
        GameManager.instance.ActivateCreditsScreen();
    }
    public void OnQuitGameButtonClicked()
    {
        Application.Quit();
    }
    public void OnStartGameButtonClicked()
    {
        GameManager.instance.ActivateGameplayScreen();
    }



}
