using System;
using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour {
    public GameObject GameOverScreen;
    public GameObject[] playerScreen;
    [SerializeField]
    private float dZoom;

    [SerializeField]
    private float dZoomDuration;
    private Coroutine gameOverCoroutine;
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
        gameOverCoroutine = StartCoroutine(GameOverDelay());
    }

    public IEnumerator GameOverDelay() {
        yield return new WaitForSeconds(0.85f);
        gameOverCoroutine = null;
        ZoomInOnWinner();
    }

    public void ZoomInOnWinner() {
        ProCamera2D.Instance.Zoom(dZoom, dZoomDuration, EaseType.EaseIn);
    }

    public void replay() {
        SceneManager.LoadScene("Arena");
    }
    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
