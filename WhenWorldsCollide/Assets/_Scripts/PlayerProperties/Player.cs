using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private string ctrlr;
    private static int PID;
    public int SkinID;
    public Player(string controller, int playerID)
    {
        ctrlr = controller;
        PID = playerID;
    }
    public string GetController()
    {
        return ctrlr;
    }
    public int GetPID()
    {
        return PID;
    }

    public void SetPID(int p){
        PID = p;
    }
}
