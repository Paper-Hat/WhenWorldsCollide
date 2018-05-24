using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;

public class ArenaSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Transform[] spawnpts;
    private int count = 0;

    //spawns players on scene start
	void Start () { SpawnPlayers(); }
    void SpawnPlayers()
    {
        //loops through valid players, instantiates objects with assigned players' controllers
        foreach(KeyValuePair<Player, bool> e in PlayerAssignment.players)
        {
            Debug.Log("Value: " + e.Value);
            Debug.Log("Key: " + e.Key);
            if (e.Value)
            {
                GameObject temp = Instantiate(player, spawnpts[count++]);
                ProCamera2D.Instance.AddCameraTarget(temp.transform, 1f, 1f, 0f);
                Player pcomponent = temp.GetComponent<Player>();
                pcomponent.SetController(e.Key.GetController());
                pcomponent.SetPID(e.Key.GetPID());
            }
        }
    }
}
