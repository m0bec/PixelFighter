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
		Shot();
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

	public GameObject shot;
	const float SHOT_RIGHT = 10.0f;
	const float SHOT_LEFT = -10.0f;
	bool shot_flag = false;
	const float SHOT_COOL_TIME = 0.2f;
	float shot_time = 0.0f;
	void Shot(){
			if(Input.GetKey(KeyCode.Space) && !shot_flag){
				Instantiate(shot, new Vector3(
					this.transform.position.x + SHOT_RIGHT,
					this.transform.position.y,
					this.transform.position.z + 1.0f),
					Quaternion.identity);
				Instantiate(shot, new Vector3(
					this.transform.position.x + SHOT_LEFT,
					this.transform.position.y,
					this.transform.position.z + 1.0f),
					Quaternion.identity);
				shot_flag = true;
			}

			if(shot_flag){
				shot_time += Time.deltaTime;
				if(shot_time > SHOT_COOL_TIME){
					shot_time = 0.0f;
					shot_flag = false;
				}
			}
	}
}
