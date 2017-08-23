using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : MonoBehaviour {
	static PlayerFighter instance;

	PlayerFighter(){}

	void Awake(){
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(gameObject);
		}else{
			Destroy(gameObject);
		}
	}

	GameFrame game_frame;
	GameObject fighter;
	const float MOVE_NORMAL_SPEED = 4.0f;
	Vector3 next_position;
	public float width;
	public float height;
	Vector3 DEF_START_POS = new Vector3(-54.0f, -300.0f, -10.0f);
	// Use this for initialization
	void Start () {
		fighter = transform.Find("Fighter").gameObject;
		game_frame = GameObject.Find("GameFrame").GetComponent<GameFrame>();
		GetObjecSize();
		this.transform.position = DEF_START_POS;
	}
	
	// Update is called once per frame
	void Update () {
		if(control_flag){
			Move();
			Shot();
		}else{
			StartMovie();
		}
	}

	bool control_flag = false;
	void CanControl(){

	}

	const float bord_go_step_two = 0.0f;
	const float bord_go_step_three = -150.0f;
	const float bord_go_step_four = 400.0f;
	const float bord_go_step_control = -150.0f;
	const float ROLLING_SPEED = 10.0f;
	enum start_step_num{
		one, two, three, four
	}
	int start_step = (int)start_step_num.one;
	bool start_step_one = false;
	Vector3 start_movie_pos;
	void StartMovie(){
		switch(start_step){
			case (int)start_step_num.one:
				start_movie_pos = this.transform.position;
				start_movie_pos.y += 5.0f;
				this.transform.position = start_movie_pos;
				if(start_movie_pos.y > bord_go_step_two){
					start_step = (int)start_step_num.two;
				}
				break;

			case (int)start_step_num.two:
				start_movie_pos = this.transform.position;
				start_movie_pos.y -= 3.0f;
				this.transform.position = start_movie_pos;
				this.transform.Rotate(new Vector3(0.0f, ROLLING_SPEED, 0.0f));
				if(start_movie_pos.y < bord_go_step_three){
					start_step = (int)start_step_num.three;
				}
				break;

			case (int)start_step_num.three:
				start_movie_pos = this.transform.position;
				start_movie_pos.y += 15.0f;
				this.transform.position = start_movie_pos;
				if(start_movie_pos.y > bord_go_step_four){
					start_step = (int)start_step_num.four;
				}
				break;
			
			case (int)start_step_num.four:
				start_movie_pos = this.transform.position;
				start_movie_pos.y -= 2.0f;
				this.transform.position = start_movie_pos;
				if(start_movie_pos.y < bord_go_step_control){
					start_step = (int)start_step_num.one;
					control_flag = true;
				}
				break;
		}

		if(start_step > (int)start_step_num.two && this.transform.rotation.eulerAngles.y != 0.0f){
			if(Mathf.Abs(this.transform.rotation.eulerAngles.y) < ROLLING_SPEED){
				Quaternion str_rotate = this.transform.rotation;
				str_rotate.eulerAngles = new Vector3(0.0f, 0.0f, 180.0f);;
				this.transform.rotation = str_rotate;
			}else{
				this.transform.Rotate(new Vector3(0.0f, ROLLING_SPEED, 0.0f));
			}
		}
		
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
