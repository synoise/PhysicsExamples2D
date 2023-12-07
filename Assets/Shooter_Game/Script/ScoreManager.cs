using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;

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

    private void AddScore()
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
}
