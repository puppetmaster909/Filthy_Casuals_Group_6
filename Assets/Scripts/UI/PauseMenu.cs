﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public EventSystem eventSystem;
    public Text confirmMessage;
    #region MonoBehavior

    public Button yesButton;


    #endregion

    #region Public Methods

    public void Back()
    {

        
            UIManager.main.UnPauseGame();
            UIManager.main.IsPaused = false;
        
            GameObject noButton = gameObject.transform.Find("ConfirmBackground").gameObject;
            noButton.SetActive(false);
    }
    private void RestartLevel()
    {
        UIManager.main.RestartLevel();
    }
    public void Settings()
    {
        UIManager.main.ShowScreen("Settings");
    }
    private void GetButtonName()
    {

    }
    public void confirmScreen()
    {
        UIManager.main.ShowScreen("ConfirmScreen");
        if(eventSystem.currentSelectedGameObject.name == "Restart")
        {
            confirmMessage.text = "Are you sure you want to restart?";

            yesButton.onClick.AddListener(delegate { RestartLevel(); });
            
        }
        else if(eventSystem.currentSelectedGameObject.name == "Leave")
        {
            confirmMessage.text = "Are you sure you want to exit?";
            yesButton.onClick.AddListener(delegate { UIManager.main.LoadLevel("LevelSelection_Scene");});
            
        } 
    }

    public void Quit()
    {
        UIManager.main.Quit();
    }

    #endregion
}
