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
        /*
        //Both player are not ready when the players first go to the skin selection screen
        p1Ready = false;
        p2Ready = false;
        p1Index = PlayerPrefs.GetInt("P1SkinID", 0);
        p2Index = PlayerPrefs.GetInt("P2SkinID", 0);
        player1SkinSelction.sprite = p1Sprites[p1Index];
        player2SkinSelction.sprite = p2Sprites[p2Index];
        p1AnimationController.SetInteger("SkinID", p1Index);
        p2AnimationController.SetInteger("SkinID", p2Index);
        */
    }


    /// <summary>
    /// cycles a skin for "player" in the direction of "increment" in the array
    /// </summary>
    /// <param name="player"></param>
    /// <param name="increment"></param>
    public void CycleSkin(int player, int increment){
        Players[player].skinIndex += increment;
        if (Players[player].skinIndex > Players[player].sprites.Length){
            Players[player].skinIndex = 0;
        }
        if (Players[player].skinIndex < 0){
            Players[player].skinIndex = Players[player].sprites.Length;
        }
        Players[player].skinSelect.sprite = Players[player].sprites[Players[player].skinIndex];
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


    public void ToggleReady(int player, Image buttonImage){
        Players[player].ready = !Players[player].ready;
    }

    private void Update() {
        if (_readyCount == _playerCount) {
            SceneManager.LoadScene("Arena");
        }
    }
    
    public void player1ReadyButton(Image buttonImage) {
        p1Ready = !p1Ready;
        buttonImage.color = (p1Ready) ? Color.green : Color.white;
        p1PrevButton.interactable = !p1Ready;
        p1NextButton.interactable = !p1Ready;
        p1Face.sprite = (p1Ready) ? happyFace : neutralFace;
    }
    public void player2ReadyButton(Image buttonImage) {
        p2Ready = !p2Ready;
        buttonImage.color = (p2Ready) ? Color.green : Color.white;
        p2PrevButton.interactable = !p2Ready;
        p2NextButton.interactable = !p2Ready;
        p2Face.sprite = (p2Ready) ? happyFace : neutralFace;
    }
}
