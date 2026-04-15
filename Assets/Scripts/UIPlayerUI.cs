using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPlayerUI : MonoBehaviour
{
    public TMP_Text scoreAndLivesTextbox;
    public TMP_Text playerNumberTextBox;
    public PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: This should be observer pattern when we learn it later.
        if (playerController != null)
        {
            UpdateScoreAndLives();
        }
    }

    public void UpdateScoreAndLives()
    {
        if (scoreAndLivesTextbox != null)
        {
            scoreAndLivesTextbox.text = "Score: " + playerController.score + "\n" + "Lives: " + playerController.lives;
        }
    }

    public void UpdatePlayerNumber (int playerNumber)
    {
        if (playerNumberTextBox != null)
        {
            playerNumberTextBox.text = "Player " + playerNumber;
        }
    }
}
