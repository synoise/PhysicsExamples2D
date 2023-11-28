using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    void Update()
    {
        {
            if (Time.timeScale == 0f && Input.GetKeyDown(KeyCode.Escape))
            {
                Resume();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    // private bool menuIsVisibled;


    // void Start()
    // {
    //     var root = GetComponent<UIDocument>().rootVisualElement;

    //     root.RegisterCallback<KeyDownEvent>(OnKeyDown, TrickleDown.TrickleDown);
    //     root.RegisterCallback<KeyUpEvent>(OnKeyUp, TrickleDown.TrickleDown);
    // }

    // void OnKeyDown(KeyDownEvent ev)
    // {
    //     Debug.Log("KeyDown:" + ev.keyCode);
    //     Debug.Log("KeyDown:" + ev.character);
    //     Debug.Log("KeyDown:" + ev.modifiers);
    // }

    // void OnKeyUp(KeyUpEvent ev)
    // {
    //     Debug.Log("KeyUp:" + ev.keyCode);
    //     Debug.Log("KeyUp:" + ev.character);
    //     Debug.Log("KeyUp:" + ev.modifiers);
    // }


    // public void OnGUI()
    // {    // triiger event on trigger key

    //     print("test trigger btn");


    // }

    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Escape))
    //         switchInGameMenu();

    // }

    // private void switchInGameMenu()
    // {
    //     Debug.Log(">>" + menuIsVisibled);
    //     if (menuIsVisibled)
    //     {
    //         Pause();
    //     }

    //     else
    //     {
    //         Resume();
    //     }
    //     menuIsVisibled = !menuIsVisibled;

    // }
}


