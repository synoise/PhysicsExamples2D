using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    // End Panel
    [SerializeField] GameObject endPanel;
    [SerializeField] TMP_Text scoreText;

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
}
