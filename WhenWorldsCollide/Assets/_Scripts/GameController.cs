using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
public class GameController : MonoBehaviour {
    public static GameController instance;
    public delegate void VictoryEvent(int player);
    public event VictoryEvent onVictory;

    public Dictionary<PlayerHealth, bool> _players; //track players and their living state
    public int LiveCount;

    /// <summary>
    /// Get a count of how many players we have and set up the game
    /// </summary>
    /// <param name="p"></param>
    public void SetInGamePlayers(List<GameObject> p){
        _players = new Dictionary<PlayerHealth, bool>(p.Count);
        LiveCount = p.Count;
        for (int i = 0; i < p.Count; i++){
            _players.Add(p.ElementAt(i).GetComponent<PlayerHealth>(), true);
            p.ElementAt(i).GetComponent<PlayerHealth>().Died += CountDeath;
        }
        
    }

	// Use this for initialization
	void Awake () {
        instance = this;

    }

    /// <summary>
    /// every a time a player dies, set their state to false
    /// if one is left alive, end the game
    /// </summary>
    /// <param name="ID"></param>
    private void CountDeath(int ID){
        LiveCount--;
        foreach (var p in _players){
            if (p.Key.playerID == ID){
                _players[p.Key] = false;
                break;
            }
        }
        if (LiveCount == 1){
            foreach (var p in _players){
                if (p.Value){
                    HandleWin(p.Key.playerID);
                }
            }
        }
    }

    /// <summary>
    /// handles the gameover state
    /// </summary>
    /// <param name="player"></param> the player who won
    public void HandleWin(int player) {
        onVictory(player);
    }

}
