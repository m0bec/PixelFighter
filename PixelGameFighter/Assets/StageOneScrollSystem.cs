using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOneScrollSystem : MonoBehaviour {
	GameFrame game_frame;
	float game_frame_width, game_frame_height;
	// Use this for initialization
	void Start () {
		game_frame = GameObject.Find("GameFrame").GetComponent<GameFrame>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
