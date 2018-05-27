using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine.Networking;

public class ArenaSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject spawner;
    [SerializeField]
    private PlayerAssignment p;
    [SerializeField]
    private Transform[] spawnpts;
    private int count = 0;

    private void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        p = spawner.GetComponent<PlayerAssignment>();
    }
    //spawns players on scene start
    void Start ()
    {
        SpawnPlayers();
    }
    void SpawnPlayers()
    {
        //loops through valid players, instantiates objects with assigned players' controllers
        for(int i=0;i<p.playerObjs.Length;i++)
        {
            Debug.Log("PlayerController: " + p.playerObjs[i].GetController());
            if (!string.IsNullOrEmpty(p.playerObjs[i].GetController())){
                GameObject temp = Instantiate(player, spawnpts[i].transform.position, Quaternion.identity);
                //assign their controller
                temp.GetComponent<PlayerMovement>().SetController(p.playerObjs[i].GetController());
                temp.GetComponentInChildren<PlayerSkinApplier>().SetPlayerSkinID(p.playerObjs[i].GetPID(), p.playerObjs[i].SkinID);
                ProCamera2D.Instance.AddCameraTarget(temp.transform, 1f, 1f, 0f);
            }
        }
    }
}
