using UnityEngine;
using TMPro;

public class UISettings : MonoBehaviour
{
    public TMP_Text numPlayersTextbox;
    public TMP_Text gameTypeTextbox;
    public TMP_InputField seedInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowNumberOfPlayers();
        ShowMapType();
    }

    void OnEnable()
    {
        ShowNumberOfPlayers();
        ShowMapType();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSeedChange()
    {
        GameManager.instance.mapGenerator.seed = int.Parse(seedInput.text);
    }

    public void OnNumPlayersClick()
    {
        // Change our number of players
        switch (GameManager.instance.numberOfPlayers)
        {
            case 1:
                GameManager.instance.numberOfPlayers = 2;
                break;
            case 2:
                GameManager.instance.numberOfPlayers = 4;
                break;
            case 4:
                GameManager.instance.numberOfPlayers = 1;
                break;
            default:
                GameManager.instance.numberOfPlayers = 1;
                break;
        }
        // Show the new number on our button
        ShowNumberOfPlayers();
    }

    public void OnBackButtonClick()
    {
        GameManager.instance.ActivateMainMenuScreen();
    }

    public void ShowMapType()
    {
        switch (GameManager.instance.mapGenerator.mapType)
        {
            case MapGenerator.MapType.Random:
                gameTypeTextbox.text = "Random";
                seedInput.gameObject.SetActive(false);
                break;
            case MapGenerator.MapType.MapOfTheDay:
                gameTypeTextbox.text = "Map of the Day";
                seedInput.gameObject.SetActive(false);
                break;
            case MapGenerator.MapType.Seeded:
                gameTypeTextbox.text = "Seeded";
                seedInput.gameObject.SetActive(true);
                break;
            default:
                numPlayersTextbox.text = "ERROR!";
                break;
        }
    }

    public void OnMapTypeClick()
    {
        switch (GameManager.instance.mapGenerator.mapType)
        {
            case MapGenerator.MapType.Random:
                GameManager.instance.mapGenerator.mapType = MapGenerator.MapType.MapOfTheDay;
                break;
            case MapGenerator.MapType.MapOfTheDay:
                GameManager.instance.mapGenerator.mapType = MapGenerator.MapType.Seeded;
                break;
            case MapGenerator.MapType.Seeded:
                GameManager.instance.mapGenerator.mapType = MapGenerator.MapType.Random;
                break;
            default:
                GameManager.instance.mapGenerator.mapType = MapGenerator.MapType.Random;
                break;
        }

        ShowMapType();
    }

    public void ShowNumberOfPlayers()
    {
        switch (GameManager.instance.numberOfPlayers)
        {
            case 1:
                numPlayersTextbox.text = "1 Player";
                break;
            case 2:
                numPlayersTextbox.text = "2 Player";
                break;
            case 4:
                numPlayersTextbox.text = "4 Player";
                break;
            default:
                numPlayersTextbox.text = "ERROR!";
                break;
        }
    }

}
