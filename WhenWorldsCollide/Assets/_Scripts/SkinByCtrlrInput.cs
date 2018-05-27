using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkinByCtrlrInput : MonoBehaviour {

    [SerializeField]
    private string ctrlr;
    [SerializeField]
    private int player;
    [SerializeField]
    private PlayerSkinSelectionController pssc;
    [SerializeField]
    private Player p;
    [SerializeField]
    bool up, down;
    void Update () {
        AllowSelectByInput();
	}
    void AllowSelectByInput()
    {
        //Needs to continually refresh
        player = p.GetPID();
        ctrlr = p.GetController();
        if (Input.GetButtonDown(ctrlr + "Boost")){
            pssc.ToggleReady(player);
        }
        if (Input.GetAxis(ctrlr + "Horizontal") > 0)
            up = true;
        else if (Input.GetAxis(ctrlr + "Horizontal") < 0)
            down = true;
        //Cycle skin on release
        else{
            if (up){
                pssc.CycleSkinUp(player);
                up = false;
            }
            else if(down){
                pssc.CycleSkinDown(player);
                down = false;
            }
        }
    }
}
