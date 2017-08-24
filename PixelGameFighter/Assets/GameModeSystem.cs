using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeSystem : MonoBehaviour {
	public GamemodeDataKeeper game_mode_data_keeper = GamemodeDataKeeper.Instance;
	PlayerFighter player_fighter;
	// Use this for initialization
	void Start () {
		player_fighter = GameObject.Find("PlayerFighter").GetComponent<PlayerFighter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void PlayeDeathSeq(){
		if(game_mode_data_keeper.PlayerDeathFlag){
			
		}
	}
}
