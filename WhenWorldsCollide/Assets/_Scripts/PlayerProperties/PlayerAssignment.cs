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
            //CheckForPlayers();
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
        /*if (Input.GetButtonDown("0sK") || Input.GetButtonDown("0sJ")){
            if (players[playerObjs[0]]){
                //access the array we use as our keys, because modifying an enumeration we are simulatenously using to iterate will cause problems
                foreach (var p in playerObjs)           
                    if (p.GetController().Equals("0"))  
                        players[p] = false;             //modify dictionary using key
                ////PCtr--;
                players[playerObjs[0]] = false;
                PlayerUI[0].SetActive(false);
            }
            else if (!players[playerObjs[0]]) {
                players[playerObjs[0]] = true;
                playerObjs[0].SetPID(//PCtr++0);
                PressStartUI[0].SetActive(false);
                PlayerUI[0].SetActive(true);
            }
        }
        else if (Input.GetButtonDown("1sK") || Input.GetButtonDown("1sJ")){
            if (players[playerObjs[1]]) {
                foreach (var p in playerObjs)
                    if (p.GetController().Equals("1"))
                        players[p] = false;
                ////PCtr--;
                players[playerObjs[1]] = false;
                PlayerUI[1].SetActive(false);
            }
            else if (!players[playerObjs[1]]) {
                playerObjs[1].SetPID(/*PCtr++1);
                players[playerObjs[1]] = true;
                PressStartUI[1].SetActive(false);
                PlayerUI[1].SetActive(true);
            }
        }
        else if (Input.GetButtonDown("2s")){
            if (players[playerObjs[2]]){
                foreach (var p in playerObjs)
                    if (p.GetController().Equals("2"))
                        players[p] = false;
                ////PCtr--;
                players[playerObjs[2]] = false;
                PressStartUI[0].SetActive(false);
                PlayerUI[2].SetActive(false);
            }
            else if (!players[playerObjs[2]]) {
                playerObjs[2].SetPID(/*PCtr++2);
                players[playerObjs[2]] = true;
                PressStartUI[2].SetActive(false);
                PlayerUI[2].SetActive(true);
            }
        }
        else if (Input.GetButtonDown("3s")){
            if (players[playerObjs[3]]) {
                foreach (var p in playerObjs)
                    if (p.GetController().Equals("3"))
                        players[p] = false;
                ////PCtr--;
                players[playerObjs[3]] = false;
                PlayerUI[3].SetActive(false);
            }
            else if (!players[playerObjs[3]]) {
                playerObjs[3].SetPID(/*PCtr++3);
                players[playerObjs[3]] = true;
                PressStartUI[3].SetActive(false);
                PlayerUI[3].SetActive(true);
            }
        }*/
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
            else
                DisconnectedUI[i].SetActive(true);
        }
    }
}
