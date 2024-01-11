using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] TMP_Text scoreText;

    int score;

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        ResetScore();

        EventsManager.OnEnemyDiedE += AddScore;
    }

    private void OnDisable()
    {
        EventsManager.OnEnemyDiedE -= AddScore;
    }

    private void UpdateUI()
    {
        scoreText.text = score.ToString("000");
    }

    public void AddScore()
    {
        score++;
        UpdateUI();
    }

    private void ResetScore()
    {
        score = 0;
        UpdateUI();
    }

    public int GetScore()
    {
        return score;
    }

    public void AddHighscoreEntry(string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
        Highscore highscore = new();

        string jsonString = FetchFileData();

        if (!string.IsNullOrEmpty(jsonString))
        {
            highscore = JsonConvert.DeserializeObject<Highscore>(jsonString);
        }
        else
        {
            Debug.Log("json empty");
            // If the JSON string is empty or invalid, create a new Highscore object
            highscore = new Highscore();
        }

        highscore.highscoreEntryList.Add(highscoreEntry);

        // Sort the highscores
        highscore.highscoreEntryList.Sort((a, b) => b.score.CompareTo(a.score));

        // Keep only the top entries (adjust as needed)
        highscore.highscoreEntryList = highscore.highscoreEntryList.Take(10).ToList();

        // Save the updated highscore table
        string json = JsonConvert.SerializeObject(highscore);
        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
    }
    private string FetchFileData()
    {
        while (true)
        {
            try
            {
                if (!File.Exists(HighscoreTable.DATA_PATH))
                {
                    File.WriteAllText(HighscoreTable.DATA_PATH, "");
                    return "";
                }
                else
                {
                    return File.ReadAllText(HighscoreTable.DATA_PATH);
                }
            }
            catch (IOException)
            {

            }
        }
    }
}
