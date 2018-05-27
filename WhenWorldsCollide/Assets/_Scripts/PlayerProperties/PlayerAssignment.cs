using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerAssignment : MonoBehaviour {

    //public Dictionary<Player, bool> players = new Dictionary<Player, bool>();

    [SerializeField]
    private GameObject[] PlayerUI, DisconnectedUI, PressStartUI;
    public Player[] playerObjs;
    public bool finishedSelection;
    private string di;
    [SerializeField]
    private int joinedPlayers;
    //private int PCtr = 0;
    private void Awake(){DontDestroyOnLoad(gameObject);}
    void Start(){
        joinedPlayers = 0;
        /*players.Add(playerObjs[0], false);
        players.Add(playerObjs[1], false);
        players.Add(playerObjs[2], false);
        players.Add(playerObjs[3], false);*/
    }
    private void Update(){
        if (!finishedSelection)
        {
            PlayerInputCheck();
            AssignPlayerInput();
            CheckForPlayers();
        }
    }

    int playersJoined = 0;
    /// <summary>
    /// get the amount of joined players
    /// </summary>
    /// <returns></returns>
    public int GetJoinedCount(){
        return joinedPlayers;
    }
    private void PlayerInputCheck()
    {
        if (Input.GetButtonDown("0Ks"))
            di = "0K";
        else if (Input.GetButtonDown("0Js"))
            di = "0J";
        else if (Input.GetButtonDown("1Ks"))
            di = "1K";
        else if (Input.GetButtonDown("1Js"))
            di = "1J";
        else if (Input.GetButtonDown("2s"))
            di = "2s";
        else if (Input.GetButtonDown("3s"))
            di = "3s";
    }
    private void AssignPlayerInput()
    {
        //Note: will iterate, but not assign controllers past the 4th input scheme recognized
        if (!string.IsNullOrEmpty(di)){
            for (int i = 0; i < 4; i++){
                if (string.IsNullOrEmpty(playerObjs[i].GetController()))
                {
                    //Set controller to match input, set pid to match joined player
                    playerObjs[i].SetValues(di, i);
                    PressStartUI[i].SetActive(false);
                    DisconnectedUI[i].SetActive(false);
                    PlayerUI[i].SetActive(true);
                    joinedPlayers++;
                    di = "";
                    //Stop after assigning first null player
                    break;
                }
                else if (di.Equals(playerObjs[i].GetController()))
                {
                    playerObjs[i].SetController("");
                    PlayerUI[i].SetActive(false);
                    joinedPlayers--;
                    di = "";
                    //Stop after deallocating player with this controller
                    break;
                }
            }
        }
    }
    void CheckForPlayers()
    {
        string[] temp = Input.GetJoystickNames();
        //because we allow 2 local players on keyboard, the following loop looks nastier than it should
        for (int i = 0; i < 4; ++i)
        {
            if (i == 0 || i == 1)
            {
                if (!PlayerUI[i].activeInHierarchy)
                    PressStartUI[i].SetActive(true);
            }
            else if (i < temp.Length)
            {
                if (!string.IsNullOrEmpty(temp[i]))
                {
                    DisconnectedUI[i].SetActive(false);
                    if (!PlayerUI[i].activeInHierarchy)
                        PressStartUI[i].SetActive(true);
                }
                else
                {
                    PressStartUI[i].SetActive(false);
                    PlayerUI[i].SetActive(false);
                    DisconnectedUI[i].SetActive(true);
                }
            }
        }
    }
}
