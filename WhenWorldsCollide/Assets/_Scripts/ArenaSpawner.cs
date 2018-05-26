using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine.Networking;

public class ArenaSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    public GameObject spawner;
    [SerializeField]
    private PlayerAssignment p;
    [SerializeField]
    private Transform[] spawnpts;
    private int count = 0;
    public List<GameObject> playersInArena;

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
        for(int i=0;i<p.players.Count;i++)
        {
            var e = p.players.ElementAt(i);
            if (e.Value){
                GameObject temp = Instantiate(player, spawnpts[i].transform.position, Quaternion.identity);
                //add to list to send over to gamecontroller when done assigning
                playersInArena.Add(temp);
                //assign their everything
                temp.GetComponent<PlayerHealth>().playerID = e.Key.GetPID();
                temp.GetComponent<PlayerMovement>().SetController(e.Key.GetController());
                temp.GetComponentInChildren<PlayerSkinApplier>().SetPlayerSkinID(e.Key.GetPID(), e.Key.SkinID);
                ProCamera2D.Instance.AddCameraTarget(temp.transform, 1f, 1f, 0f);
            }
        }
        GameController.instance.SetInGamePlayers(playersInArena);
    }
}
