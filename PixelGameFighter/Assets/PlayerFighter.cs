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
	public Vector3 DEF_START_POS = new Vector3(-54.0f, -300.0f, -10.0f);
	public GameObject main_cam;
	public GameObject gray_cam;
	// Use this for initialization
	void Start () {
		fighter = transform.Find("Fighter").gameObject;
		game_frame = GameObject.Find("GameFrame").GetComponent<GameFrame>();
		main_cam = GameObject.Find("MainCamera");
		gray_cam = GameObject.Find("GrayCamera");
		GetObjecSize();
		this.transform.position = DEF_START_POS;
		player_state = (int)player_state_name.start;
	}
	
	public enum player_state_name{
		normal, start, restart, death, invalid
	}
	int player_state;
	public int PlayerState{
		set{player_state = value;}
		get{return player_state;}
	}
	// Update is called once per frame
	void Update () {
		switch(player_state){
			case (int)player_state_name.start:
				ChangeMainCom();
				StartMovie();
				break;

			case (int)player_state_name.restart:
				ChangeMainCom();
				RestartMove();
				break;

			case (int)player_state_name.normal:
				ChangeMainCom();
				DeathCheck();
				Move();
				Shot();
				Bomb();
				break;

			case (int)player_state_name.death:
				Death();
				break;

			case (int)player_state_name.invalid:
				ChangeGrayCam();
				DeathCheck();
				Move();
				Shot();
				break;
		}
	}

	public GamemodeDataKeeper game_mode_data_keeper = GamemodeDataKeeper.Instance;

	void Bomb(){
		//test
		if(Input.GetKey(KeyCode.F2)){
			player_state = (int)player_state_name.invalid;
		}
	}

	float overlay_intensity;
	const float change_overlay_speed = 0.03f;
	void ChangeGrayCam(){
		overlay_intensity = main_cam.GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().intensity;
		if(overlay_intensity < 1.0f - change_overlay_speed){
			main_cam.GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().intensity += change_overlay_speed;
		}else{
			main_cam.GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().intensity = 1.0f;
		}
	}
	void ChangeMainCom(){
		overlay_intensity = main_cam.GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().intensity;
		if(overlay_intensity > change_overlay_speed){
			main_cam.GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().intensity -= change_overlay_speed;
		}else{
			main_cam.GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().intensity = 0.0f;
		}
	}

	void Death(){
		if(this.transform.position != DEF_START_POS)	this.transform.position = DEF_START_POS;
	}

	void DeathCheck(){
		if(game_mode_data_keeper.PlayerDeathFlag){
			if(game_mode_data_keeper.PlayerHp >= 0){
				player_state = (int)player_state_name.restart;
				SetRestartPos();	
			}else{
				Instantiate(explosion_effect, this.transform.position, Quaternion.identity);
				player_state = (int)player_state_name.death;
			}
		}
	}

	bool restart_flag = false;
	public bool RestartFlag{
		set{restart_flag  =value;}
		get{return restart_flag;}
	}
	const float RESTART_MOVE_SPEED  =5.0f;
	public GameObject explosion_effect;
	public void SetRestartPos(){
		Instantiate(explosion_effect, this.transform.position, Quaternion.identity);
		this.transform.position = DEF_START_POS;
	}
	void RestartMove(){
		Vector3 str_res_pos = this.transform.position;
		str_res_pos.y += RESTART_MOVE_SPEED;
		this.transform.position = str_res_pos;
		if(str_res_pos.y > bord_go_step_control){
			player_state = (int)player_state_name.normal;
			game_mode_data_keeper.PlayerDeathFlag = false;
		}
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
					player_state = (int)player_state_name.normal;
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
	const float SHOT_COOL_TIME = 0.05f;
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
