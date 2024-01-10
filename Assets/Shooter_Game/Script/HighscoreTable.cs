using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Newtonsoft.Json;

public class HighscoreTable : MonoBehaviour
{
    [SerializeField] private Transform entryContainer;
    [SerializeField] private Transform entryTemplate;
    private List<Transform> highscoreEntryTranformList;
    private string currentPlayerName;

    public static string DATA_PATH;

    public static HighscoreTable Instance { get; private set; }
    private void Awake()
    {
        DATA_PATH = Application.persistentDataPath + "/save.json";

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        entryTemplate.gameObject.SetActive(false);

        string jsonString = FetchFileData();
        //highscore = JsonUtility.FromJson<Highscore>(jsonString);
        Highscore highscore = JsonConvert.DeserializeObject<Highscore>(jsonString);

        highscoreEntryTranformList = new List<Transform>();  // Initialize the list here

        for (int i = 0; i < highscore.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscore.highscoreEntryList.Count; j++)
            {
                if (highscore.highscoreEntryList[j].score > highscore.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscore.highscoreEntryList[i];
                    highscore.highscoreEntryList[i] = highscore.highscoreEntryList[j];
                    highscore.highscoreEntryList[j] = tmp;
                }
            }
        }

        foreach (HighscoreEntry highscoreEntry in highscore.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTranformList);
        }
    }

    public void StartGame()
    {

    }

    private string FetchFileData()
    {
        while (true)
        {
            try
            {
                if (!File.Exists(DATA_PATH))
                {
                    File.WriteAllText(DATA_PATH, "");
                    return "";
                }
                else
                {
                    return File.ReadAllText(DATA_PATH);
                }
            }
            catch (IOException)
            {

            }
        }
    }

    public void SetPlayerName(string playerName)
    {
        currentPlayerName = playerName;
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 60f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        /*RectTransform entryRectTranform = entryTransform.GetComponent<RectTransform>();
        entryRectTranform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);*/

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("RankT").GetComponent<TMP_Text>().text = rankString;

        int score = highscoreEntry.score;

        entryTransform.Find("ScoreT").GetComponent<TMP_Text>().text = score.ToString();
        entryTransform.Find("NameT").GetComponent<TMP_Text>().text = highscoreEntry.name;

        transformList.Add(entryTransform);
    }

    public void AddHighscoreEntry(int score, string name)
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
}

public class Highscore
{
    public List<HighscoreEntry> highscoreEntryList = new();
}

[Serializable]
public class HighscoreEntry
{
    public int score;
    public string name;
}
