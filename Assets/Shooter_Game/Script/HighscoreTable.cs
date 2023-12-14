using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    [SerializeField] private Transform entryContainer;
    [SerializeField] private Transform entryTemplate;
    private List<Transform> highscoreEntryTranformList;

    private void Awake()
    {
        // entryContainer = transform.Find("HighScoreContainer");
        // entryTemplate = entryContainer.Find("HighScoreTemplate");

        entryTemplate.gameObject.SetActive(false);

        // AddHighscoreEntry(777, "friz");  

        // List<HighscoreEntry> highscoreEntryList = new List<HighscoreEntry>(){
        //     new HighscoreEntry{ score = 5184, name = "AAA"},
        //     new HighscoreEntry{ score = 3142, name = "ArA"},
        //     new HighscoreEntry{ score = 2454, name = "123"},
        //     new HighscoreEntry{ score = 7000, name = "AAb"},
        //     new HighscoreEntry{ score = 9090, name = "AsA"},
        // };

        // Highscore highscore = new Highscore { highscoreEntryList = highscoreEntryList };
        // string json = JsonUtility.ToJson(highscoreEntryList);
        // PlayerPrefs.SetString("highscoreTable", json);
        // PlayerPrefs.Save();
        // Debug.Log(PlayerPrefs.GetString("highscoreTable"));

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscore highscore = JsonUtility.FromJson<Highscore>(jsonString);

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

        highscoreEntryTranformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscore.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTranformList);
        }

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
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Debug.Log(highscoreEntry.score + highscoreEntry.name);
        Highscore highscore = JsonUtility.FromJson<Highscore>(jsonString);

        highscore.highscoreEntryList.Add(highscoreEntry);

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
