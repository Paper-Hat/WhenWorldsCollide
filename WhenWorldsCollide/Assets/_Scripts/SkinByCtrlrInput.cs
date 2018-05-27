using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkinByCtrlrInput : MonoBehaviour {

    [SerializeField]
    private int ctrlr;
    [SerializeField]
    private PlayerSkinSelectionController pssc;
    [SerializeField]
    bool up, down;

	void Update () {
        AllowSelectByInput();
	}
    void AllowSelectByInput()
    {
        if (Input.GetButtonDown(ctrlr + "sBoost"))
            pssc.ToggleReady(ctrlr);
        if (Input.GetAxis(ctrlr + "sHorizontal") > 0)
            up = true;
        else if (Input.GetAxis(ctrlr + "sHorizontal") < 0)
            down = true;
        //Cycle skin on release
        else{
            if (up){
                pssc.CycleSkinUp(ctrlr);
                up = false;
            }
            else if(down){
                pssc.CycleSkinDown(ctrlr);
                down = false;
            }
        }
    }
}
