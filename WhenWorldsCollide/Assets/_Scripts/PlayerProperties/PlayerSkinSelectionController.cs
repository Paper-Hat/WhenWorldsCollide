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
        public Image PressStart;
        public Image NoController;
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
        PlayerAssignment.playerObjs[player].SkinID = Players[player].skinIndex;
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
        PlayerAssignment.playerObjs[player].SkinID = Players[player].skinIndex;
    }

    /// <summary>
    /// toggles the ready state for the player
    /// </summary>
    /// <param name="player"></param>
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

        if (_readyCount >= 2 && _readyCount == PlayerAssign.GetJoinedCount()) {
            SceneManager.LoadScene("Arena");
        }
    }
}
