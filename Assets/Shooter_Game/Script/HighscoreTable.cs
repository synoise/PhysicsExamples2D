using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HighscoreTable : MonoBehaviour
{
    [SerializeField] private Transform entryContainer;
    [SerializeField] private Transform entryTemplate;
    private List<Transform> highscoreEntryTranformList;
    private string currentPlayerName;

    public static HighscoreTable Instance { get; private set; }
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

        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscore highscore = JsonUtility.FromJson<Highscore>(jsonString);

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

    public void SetPlayerName(string playerName)
    {
        currentPlayerName = playerName;
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 60f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTranform = entryTransform.GetComponent<RectTransform>();
        entryRectTranform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

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
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = currentPlayerName };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscore highscore = JsonUtility.FromJson<Highscore>(jsonString);

        highscore.highscoreEntryList.Add(highscoreEntry);

        // Sort the highscores
        highscore.highscoreEntryList.Sort((a, b) => b.score.CompareTo(a.score));

        // Keep only the top entries (adjust as needed)
        highscore.highscoreEntryList = highscore.highscoreEntryList.Take(10).ToList();

        // Save the updated highscore table
        string json = JsonUtility.ToJson(highscore);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscore
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
