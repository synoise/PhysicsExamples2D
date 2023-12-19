using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInput;
    [SerializeField] private Button startButton;
    [SerializeField] private HighscoreTable highscoreTable;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        highscoreTable = HighscoreTable.Instance;
    }

    private void StartGame()
    {
        string playerName = playerNameInput.text;
        highscoreTable.SetPlayerName(playerName);
        highscoreTable.StartGame();

    }


}
