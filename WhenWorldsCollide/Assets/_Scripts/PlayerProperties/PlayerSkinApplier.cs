using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinApplier : MonoBehaviour {
    public int PlayerID = 0;
    public int SkinID = 0;
    public Animator anim;

    public void SetPlayerSkinID(int pID, int sID){
        PlayerID = pID;
        SkinID = sID;
        anim.SetInteger("SkinID", SkinID);
    }

    void Start() {
        //Debug.Log(PlayerPrefs.GetInt("P1SkinID"));
        //Debug.Log(PlayerPrefs.GetInt("P2SkinID"));
        //anim.SetInteger("SkinID", (PlayerID==1)?PlayerPrefs.GetInt("P1SkinID"): PlayerPrefs.GetInt("P2SkinID"));
        //PlayerSpriteObject.sprite = SkinManager.GetSkinbyID(1, PlayerPrefs.GetInt("P1SkindID", 0));
    }
}
