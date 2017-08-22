using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : MonoBehaviour {
	GameFrame game_frame;
	const float MOVE_NORMAL_SPEED = 4.0f;
	Vector3 next_position;
	// Use this for initialization
	void Start () {
		game_frame = GameObject.Find("GameFrame").GetComponent<GameFrame>();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move(){
		next_position = this.transform.position;
		if(Input.GetKey(KeyCode.UpArrow)){
			next_position.y += MOVE_NORMAL_SPEED;
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			next_position.y -= MOVE_NORMAL_SPEED;
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			next_position.x += MOVE_NORMAL_SPEED;
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			next_position.x -= MOVE_NORMAL_SPEED;
		}

		if(next_position.x >= game_frame.GameDispWidthR){
			next_position.x = game_frame.GameDispWidthR;
		}else if(next_position.x <= game_frame.GameDispWidthL){
			next_position.x = game_frame.GameDispWidthL;
		}
		if(next_position.y >= game_frame.GameDispHeightU){
			next_position.y = game_frame.GameDispHeightU;
		}else if(next_position.y <= game_frame.GameDispHeightD){
			next_position.y = game_frame.GameDispHeightD;
		}

		this.transform.position = next_position;
	}
}
