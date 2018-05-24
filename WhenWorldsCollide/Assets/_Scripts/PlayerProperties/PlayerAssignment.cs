using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerAssignment : MonoBehaviour {

    public Dictionary<Player, bool> players = new Dictionary<Player, bool>();

    [SerializeField]
    private GameObject[] PlayerUI, DisconnectedUI, PressStartUI;
    public Player[] playerObjs;
    public bool finishedSelection;
    private int PCtr = 0;
    private void Awake(){DontDestroyOnLoad(gameObject);}
    void Start(){
        players.Add(playerObjs[0], false);
        players.Add(playerObjs[1], false);
        players.Add(playerObjs[2], false);
        players.Add(playerObjs[3], false);
    }
    private void Update(){
        if (!finishedSelection)
        {
            DeterminePlayerInput();
            CheckForPlayers();
        }
    }
    /// <summary>
    /// get the amount of joined players
    /// </summary>
    /// <returns></returns>
    public int GetJoinedCount(){
        int joined = 0;
        foreach (var p in players){
            if (p.Value){
                joined++;
            }
        }
        return joined;
    }
    private void DeterminePlayerInput()
    {
        if (Input.GetButtonDown("0sK") || Input.GetButtonDown("0sJ")){
            if (players[playerObjs[0]]){
                //access the array we use as our keys, because modifying an enumeration we are simulatenously using to iterate will cause problems
                foreach (var p in playerObjs)           
                    if (p.GetController().Equals("0"))  
                        players[p] = false;             //modify dictionary using key
                PCtr--;
                players[playerObjs[0]] = false;
                PlayerUI[0].SetActive(false);
            }
            else if (!players[playerObjs[0]]) {
                players[playerObjs[0]] = true;
                playerObjs[0].SetPID(PCtr++);
                PressStartUI[0].SetActive(false);
                PlayerUI[0].SetActive(true);
            }
        }
        else if (Input.GetButtonDown("1sK") || Input.GetButtonDown("1sJ")){
            if (players[playerObjs[1]]) {
                foreach (var p in playerObjs)
                    if (p.GetController().Equals("1"))
                        players[p] = false;
                PCtr--;
                players[playerObjs[1]] = false;
                PlayerUI[1].SetActive(false);
            }
            else if (!players[playerObjs[1]]) {
                playerObjs[1].SetPID(PCtr++);
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
                PCtr--;
                players[playerObjs[2]] = false;
                PressStartUI[0].SetActive(false);
                PlayerUI[2].SetActive(false);
            }
            else if (!players[playerObjs[2]]) {
                playerObjs[2].SetPID(PCtr++);
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
                PCtr--;
                players[playerObjs[3]] = false;
                PlayerUI[3].SetActive(false);
            }
            else if (!players[playerObjs[3]]) {
                playerObjs[3].SetPID(PCtr++);
                players[playerObjs[3]] = true;
                PressStartUI[3].SetActive(false);
                PlayerUI[3].SetActive(true);
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
            else
                DisconnectedUI[i].SetActive(true);
        }
    }
}
