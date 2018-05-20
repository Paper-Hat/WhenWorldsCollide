using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAssignment : MonoBehaviour {

    [SerializeField]
    public List<Player> players;
    [SerializeField]
    private bool[] pselected = new bool[4];

    private int PCtr = 0;
    private void Update(){
        DeterminePlayerInput();
    }
    private void DeterminePlayerInput()
    {
        if (Input.GetButton("0sK") || Input.GetButton("0sJ")){
            if (!pselected[0])
                players.Add(new Player("0", PCtr++));
            pselected[0] = true;
        }
        else if (Input.GetButton("1sK") || Input.GetButton("1sJ")){
            if (!pselected[1])
                players.Add(new Player("1", PCtr++));
            pselected[1] = true;
        }
        else if (Input.GetButton("2s")){
            if (!pselected[2])
                players.Add(new Player("2", PCtr++));
            pselected[2] = true;
        }
        else if (Input.GetButton("3s")){
            if (!pselected[3])
                players.Add(new Player("3", PCtr++));
            pselected[3] = true;
        }

    }
}
