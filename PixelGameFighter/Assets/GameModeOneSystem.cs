using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeOneSystem : MonoBehaviour {
	public GameObject et_box, et_fighter_g, tank;
	public GamemodeDataKeeper game_mode_data_keeper = GamemodeDataKeeper.Instance;
	GameFrame game_frame;
	GameObject player_obj;
	// Use this for initialization
	void Start () {
		game_frame = GameObject.Find("GameFrame").GetComponent<GameFrame>();
		player_obj = GameObject.Find("PlayerFighter");
		player_obj.GetComponent<PlayerFighter>().Start();
	}
	
	// Update is called once per frame
	void Update () {
		if(!game_mode_data_keeper.Stop){
			GameMoveLevel();
			NextScene();
		}
	}
	
	enum game_move_level{
		one, two
	}
	int game_level = (int)game_move_level.one;
	float time = 0.0f;
	enum enum_one_level{one, two, three, four, five, six, seve, eight}
	int one_step = (int)enum_one_level.one;
	
	GameObject str_obj;
	void GameMoveLevel(){
		time += Time.deltaTime;
		switch(game_level){
			case (int)game_move_level.one:
				if(one_step == (int)enum_one_level.one && time > 10.0f) {
					CreateEFighter(et_fighter_g, new Vector3(
						game_frame.GameDispWidthL + tank.GetComponent<EnemyMove>().Width/2 + 100.0f,
						game_frame.GameDispHeightU + tank.GetComponent<EnemyMove>().Height,
						game_mode_data_keeper.PlayerFL
					), 10, 10.0f, 1.0f, 100.0f, (int)EnemyBase.enum_shot_type.target_straight, 1.0f);
					one_step = (int)enum_one_level.two;
				}else if(one_step == (int)enum_one_level.two && time > 15.0f){
					CreateTank(tank, new Vector3(
						game_frame.GameDispWidthL + tank.GetComponent<EnemyMove>().Width/2 + 200.0f,
						game_frame.GameDispHeightU + tank.GetComponent<EnemyMove>().Height,
						game_mode_data_keeper.PlayerFL
					), 10, 10.0f, 1.0f, 100.0f, (int)EnemyBase.enum_shot_type.target_straight, 1.0f);
					one_step = (int)enum_one_level.three;
				}else if(one_step == (int)enum_one_level.three && time > 20.0f){
					CreateTank(tank, new Vector3(
						game_frame.GameDispWidthL + tank.GetComponent<EnemyMove>().Width/2 + 300.0f,
						game_frame.GameDispHeightU + tank.GetComponent<EnemyMove>().Height,
						game_mode_data_keeper.PlayerFL
					), 10, 10.0f, 1.0f, 100.0f, (int)EnemyBase.enum_shot_type.target_straight, 1.0f);
					one_step = (int)enum_one_level.one;
					game_level = (int)game_move_level.two;
				}
				break;

			case (int)game_move_level.two:
				
				break;
		}
	}

	void CreateTank(GameObject tank_, Vector3 pos_, int score_, float hp_,
	 float move_speed_, float shot_speed_, int shot_type_, float shot_cool_time_){
		str_obj = Instantiate(tank_, pos_, Quaternion.identity);
		str_obj.GetComponent<TankUnder>().SetState(score_, hp_, shot_speed_, shot_type_, shot_cool_time_);
		str_obj.GetComponent<EnemyMove>().MoveSpeed = move_speed_;
	}

	void CreateEFighter(GameObject fighter_, Vector3 pos_, int score_, float hp_,
	 float move_speed_, float shot_speed_, int shot_type_, float shot_cool_time_){
		str_obj = Instantiate(fighter_, pos_, Quaternion.identity);
		str_obj.GetComponent<ETFighterG>().SetState(score_, hp_, shot_speed_, shot_type_, shot_cool_time_);
		str_obj.GetComponent<EnemyMove>().MoveSpeed = move_speed_;
	}

	void NextScene(){
		if(Input.GetKey(KeyCode.F1)){
			SceneManager.LoadScene("GameModeTwo");
		}
	}
}
