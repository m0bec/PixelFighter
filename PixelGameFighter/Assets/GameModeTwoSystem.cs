using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeTwoSystem : MonoBehaviour {
	PlayerFighter player_fighter;
	GameFrame game_frame;
	Vector3 DEF_PlAYER_POS = new Vector3(0.0f, -20.0f, 0.0f);
	// Use this for initialization
	void Start () {
		player_fighter = GameObject.Find("PlayerFighter").GetComponent<PlayerFighter>();
		game_frame = GameObject.Find("GameFrame").GetComponent<GameFrame>();
		player_fighter.transform.position = DEF_PlAYER_POS;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
