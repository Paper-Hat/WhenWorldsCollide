using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSkinSelectionController : MonoBehaviour{

    public PlayerAssignment PlayerAssign;

    [Serializable]
    public struct PlayerSkinChoices{
        public Player assignedPlayer;
        public int skinIndex;
        public bool ready;
        public Sprite[] sprites;
        public Image skinSelect;
        public Animator animationController;
        public Image face;
        public Image ReadyButton;
    }

    public PlayerSkinChoices[] Players;
    private int _playerCount = 2; //always two minimum
    private int _readyCount;

    [SerializeField] private Sprite happyFace;
    [SerializeField] private Sprite neutralFace;

    private void Start() {
        foreach (var p in Players){
            p.skinSelect.sprite = p.sprites[0];
            p.animationController.SetInteger("SkinID", p.skinIndex);
        }
    }


    /// <summary>
    /// cycles a skin for "player" up the array
    /// </summary>
    /// <param name="player"></param>
    public void CycleSkinUp(int player){
        Players[player].skinIndex++;
        if (Players[player].skinIndex > Players[player].sprites.Length - 1){
            Players[player].skinIndex = 0;
        }
        Players[player].skinSelect.sprite = Players[player].sprites[Players[player].skinIndex];
        Players[player].animationController.SetInteger("SkinID", Players[player].skinIndex);
        //modify assigned player skinID here too

        /**
        if (player == 1){
            p1Index += increment;
            if (p1Index > p1Sprites.Length){
                p1Index = 0;
            }
            if (p1Index < 0){
                p1Index = p1Sprites.Length;
            }
            player1SkinSelction.sprite = p1Sprites[p1Index];
        }

        if (player == 2) {
            p2Index += increment;
            if (p2Index > p2Sprites.Length) {
                p2Index = 0;
            }
            if (p1Index < 0) {
                p2Index = p2Sprites.Length;
            }
            player2SkinSelction.sprite = p2Sprites[p1Index];
        }

        if (player == 3) {
            p1Index += increment;
            if (p3Index > p3Sprites.Length) {
                p3Index = 0;
            }
            if (p1Index < 0) {
                p1Index = p1Sprites.Length;
            }
            player1SkinSelction.sprite = p1Sprites[p1Index];
        }

        if (player == 4) {
            p1Index += increment;
            if (p1Index > p1Sprites.Length) {
                p1Index = 0;
            }
            if (p1Index < 0) {
                p1Index = p1Sprites.Length;
            }
            player1SkinSelction.sprite = p1Sprites[p1Index];
        }**/
    }

    /// <summary>
    /// cycles a skin for the player down the array
    /// </summary>
    /// <param name="player"></param>
    public void CycleSkinDown(int player){
        Players[player].skinIndex--;
        if (Players[player].skinIndex < 0) {
            Players[player].skinIndex = Players[player].sprites.Length - 1;
        }
        Players[player].skinSelect.sprite = Players[player].sprites[Players[player].skinIndex];
        Players[player].animationController.SetInteger("SkinID", Players[player].skinIndex);
    }

    public void ToggleReady(int player){
        Players[player].ready = !Players[player].ready;
        Players[player].ReadyButton.color = Players[player].ready ? Color.green : Color.white;
        Players[player].face.sprite = Players[player].ready ? happyFace : neutralFace;

        _readyCount = 0;
        foreach (var p in Players){
            if (p.ready){
                _readyCount++;
            }
        }
    }

    private void Update() {
        if (_readyCount == _playerCount) {
            SceneManager.LoadScene("Arena");
        }
    }
}
