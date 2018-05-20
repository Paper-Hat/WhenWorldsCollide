using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private static string ctrlr;
    private static int PID;
    public Player(string controller, int playerID)
    {
        ctrlr = controller;
        PID = playerID;
    }
    public int GetPID()
    {
        return PID;
    }
}
