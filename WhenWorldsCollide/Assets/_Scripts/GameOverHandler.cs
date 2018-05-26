using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour {
    public GameObject GameOverScreen;
    public GameObject[] playerScreen; 

    void Start() {
        GameController.instance.onVictory += HandleVictoryCanvas;

    }

    /// <summary>
    /// recieves the onVictory event to enable the final screens
    /// </summary>
    /// <param name="player"></param>
    public void HandleVictoryCanvas(int player) {
        GameOverScreen.gameObject.SetActive(true);
        playerScreen[player].SetActive(true);
    }

    public void replay() {
        SceneManager.LoadScene("Arena");
    }
    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
