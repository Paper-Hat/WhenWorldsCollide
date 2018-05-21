using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerAssignment : MonoBehaviour {
    public Dictionary<Player, bool> players = new Dictionary<Player, bool>();
    [SerializeField]
    private bool[] pselected = new bool[4];

    public GameObject Player1UI, Player2UI, Player3UI, Player4UI;
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
                Player1UI.SetActive(false);
            }
            else if (!pselected[0]){
                pselected[0] = true;
                playerObjs[0].SetPID(PCtr++);
                Player1UI.SetActive(true);
            }
        }
        else if (Input.GetButtonDown("1sK") || Input.GetButtonDown("1sJ")){
            if (pselected[1]){
                foreach (var p in playerObjs)
                    if (p.GetController().Equals("1"))
                        players[p] = false;
                PCtr--;
                pselected[1] = false;
                Player2UI.SetActive(false);
            }
            else if (!pselected[1]){
                playerObjs[1].SetPID(PCtr++);
                pselected[1] = true;
                Player2UI.SetActive(true);
            }
        }
        else if (Input.GetButtonDown("2s")){
            if (pselected[2]){
                foreach (var p in playerObjs)
                    if (p.GetController().Equals("2"))
                        players[p] = false;
                PCtr--;
                pselected[2] = false;
                Player3UI.SetActive(false);
            }
            else if (!pselected[2]){
                playerObjs[2].SetPID(PCtr++);
                Player3UI.SetActive(true);
            }
        }
        else if (Input.GetButtonDown("3s")){
            if (pselected[3]){
                foreach (var p in playerObjs)
                    if (p.GetController().Equals("3"))
                        players[p] = false;
                PCtr--;
                pselected[3] = false;
                Player4UI.SetActive(false);
            }
            else if (!pselected[3]){
                playerObjs[3].SetPID(PCtr++);
                Player4UI.SetActive(true);
            }
        }
    }
    void CheckForJoyPads()
    {
        //Get Joystick Names
        string[] temp = Input.GetJoystickNames();

        //Check whether array contains anything
        if (temp.Length > 0)
        {
            //Iterate over every element
            for (int i = 0; i < temp.Length; ++i)
            {
                //Check if the string is empty or not
                if (!string.IsNullOrEmpty(temp[i]))
                {
                    //Not empty, controller temp[i] is connected
                    Debug.Log("Controller " + i + " is connected using: " + temp[i]);
                }
                else
                {
                    //If it is empty, controller i is disconnected
                    //where i indicates the controller number
                    Debug.Log("Controller: " + i + " is disconnected.");

                }
            }
        }
    }
}
