using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerAssignment : MonoBehaviour {
    public Dictionary<Player, bool> players = new Dictionary<Player, bool>();
    [SerializeField]
    private bool[] pselected = new bool[4];

    public GameObject[] PlayerUI, DisconnectedUI, PressStartUI;
    public Player[] playerObjs;
    private int PCtr = 0;

    void Start(){
        players.Add(playerObjs[0], pselected[0]);
        players.Add(playerObjs[1], pselected[1]);
        players.Add(playerObjs[2], pselected[2]);
        players.Add(playerObjs[3], pselected[3]);
    }

    private void Update(){
        DeterminePlayerInput();
        CheckForJoyPads();
    }
    private void DeterminePlayerInput()
    {
        if (Input.GetButtonDown("0sK") || Input.GetButtonDown("0sJ")){
            if (pselected[0]){
                //access the array we use as our keys, because modifying an enumeration we are simulatenously using to iterate will cause problems
                foreach (var p in playerObjs)           
                    if (p.GetController().Equals("0"))  
                        players[p] = false;             //modify dictionary using key
                PCtr--;
                pselected[0] = false;
                PlayerUI[0].SetActive(false);
            }
            else if (!pselected[0]){
                pselected[0] = true;
                playerObjs[0].SetPID(PCtr++);
                PressStartUI[0].SetActive(false);
                PlayerUI[0].SetActive(true);
            }
        }
        else if (Input.GetButtonDown("1sK") || Input.GetButtonDown("1sJ")){
            if (pselected[1]){
                foreach (var p in playerObjs)
                    if (p.GetController().Equals("1"))
                        players[p] = false;
                PCtr--;
                pselected[1] = false;

                PlayerUI[1].SetActive(false);
            }
            else if (!pselected[1]){
                playerObjs[1].SetPID(PCtr++);
                pselected[1] = true;
                PressStartUI[1].SetActive(false);
                PlayerUI[1].SetActive(true);
            }
        }
        else if (Input.GetButtonDown("2s")){
            if (pselected[2]){
                foreach (var p in playerObjs)
                    if (p.GetController().Equals("2"))
                        players[p] = false;
                PCtr--;
                pselected[2] = false;
                PressStartUI[0].SetActive(false);
                PlayerUI[2].SetActive(false);
            }
            else if (!pselected[2]){
                playerObjs[2].SetPID(PCtr++);
                pselected[2] = true;
                PressStartUI[2].SetActive(false);
                PlayerUI[2].SetActive(true);
            }
        }
        else if (Input.GetButtonDown("3s")){
            if (pselected[3]){
                foreach (var p in playerObjs)
                    if (p.GetController().Equals("3"))
                        players[p] = false;
                PCtr--;
                pselected[3] = false;
                PlayerUI[3].SetActive(false);
            }
            else if (!pselected[3]){
                playerObjs[3].SetPID(PCtr++);
                pselected[3] = true;
                PressStartUI[3].SetActive(false);
                PlayerUI[3].SetActive(true);
            }
        }
    }
    void CheckForJoyPads()
    {
        string[] temp = Input.GetJoystickNames();
        //because we allow 2 local players on keyboard, the following loop looks nastier than it shou
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
