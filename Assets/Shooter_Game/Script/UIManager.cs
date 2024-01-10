using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    // End Panel
    [SerializeField] GameObject endPanel;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Button retryBtn;
    [SerializeField] Button menuBtn;
    [SerializeField] InputField nameInputField;

    private void Awake()
    {
        retryBtn.onClick.AddListener(RetryGame);
        menuBtn.onClick.AddListener(BackToMainMenu);
    }

    private void OnEnable()
    {
        EventsManager.OnPlayerDiedE += OpenEndPanel;
    }

    private void OnDisable()
    {
        EventsManager.OnPlayerDiedE -= OpenEndPanel;
    }

    public void OpenEndPanel()
    {
        endPanel.SetActive(true);
        scoreText.text = ScoreManager.Instance.GetScore().ToString("000");
    }

    public void RetryGame()
    {
        if (!SaveScoreData())
            return;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenu()
    {
        if (!SaveScoreData())
            return;

        SceneManager.LoadScene(0);
    }

    private bool SaveScoreData()
    {
        if (nameInputField.text == "")
        {
            // Name can't be empty
            return false;
        }

        ScoreManager.Instance.AddHighscoreEntry(nameInputField.text);
        return true;
    }
}