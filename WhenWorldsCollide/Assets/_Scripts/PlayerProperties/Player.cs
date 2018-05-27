using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private string ctrlr;
    private int PID;
    public int SkinID;
    public string GetController(){ return ctrlr; }
    public void SetController(string c){ ctrlr = c; }
    public int GetPID(){ return PID; }
    public void SetPID(int p){ PID = p; }
    /// <summary>
    /// sets the controller and id
    /// </summary>
    /// <param name="c">Controller</param>
    /// <param name="p">ID</param>
    public void SetValues(string c, int p)
    {
        ctrlr = c;
        PID = p;
    }
}
