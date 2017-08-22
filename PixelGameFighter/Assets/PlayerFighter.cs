using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : MonoBehaviour {
	GameFrame game_frame;
	GameObject fighter;
	const float MOVE_NORMAL_SPEED = 4.0f;
	Vector3 next_position;
	public float width;
	public float height;
	// Use this for initialization
	void Start () {
		fighter = transform.Find("Fighter").gameObject;
		game_frame = GameObject.Find("GameFrame").GetComponent<GameFrame>();
		GetObjecSize();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void GetObjecSize(){
		width = fighter.GetComponent<Renderer>().bounds.size.x;
		height = fighter.GetComponent<Renderer>().bounds.size.y;
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

		if(next_position.x >= game_frame.GameDispWidthR - width/2){
			next_position.x = game_frame.GameDispWidthR - width/2;
		}else if(next_position.x <= game_frame.GameDispWidthL + width/2){
			next_position.x = game_frame.GameDispWidthL + width/2;
		}
		if(next_position.y >= game_frame.GameDispHeightU - height/2){
			next_position.y = game_frame.GameDispHeightU - height/2;
		}else if(next_position.y <= game_frame.GameDispHeightD + height/2){
			next_position.y = game_frame.GameDispHeightD + height/2;
		}

		this.transform.position = next_position;
	}
}
