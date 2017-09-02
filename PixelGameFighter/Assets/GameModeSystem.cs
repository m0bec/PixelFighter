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
		CreateStopBackGround();
	}

	public GameObject stop_background;
	bool create_stop_background = false;
	void CreateStopBackGround(){
		if(!game_mode_data_keeper.Stop){
			create_stop_background = false;
		}else{
			if(!create_stop_background){
				Instantiate(stop_background, new Vector3(0.0f, 0.0f, -95.0f), Quaternion.identity);
				create_stop_background = true;
			}
		}
	}
}
