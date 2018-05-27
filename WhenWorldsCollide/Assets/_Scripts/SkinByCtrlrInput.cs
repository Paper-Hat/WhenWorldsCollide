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
    private float cycleSpeed;
    private Coroutine cycleUp;
    private Coroutine cycleDown;
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
        {
            if (cycleUp == null && cycleDown == null)
                cycleUp = StartCoroutine(CycleUpCo());
        }
        else if (Input.GetAxis(ctrlr + "Horizontal") < 0)
        {
            if (cycleUp == null && cycleDown == null)
                cycleDown = StartCoroutine(CycleDownCo());
        }
    }
    private IEnumerator CycleDownCo()
    {
        pssc.CycleSkinDown(player);
        yield return new WaitForSeconds(cycleSpeed);
        cycleDown = null;
    }
    private IEnumerator CycleUpCo()
    {
        pssc.CycleSkinUp(player);
        yield return new WaitForSeconds(cycleSpeed);
        cycleUp = null;
    }
}
