using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameModeOneSystem : MonoBehaviour {
	public GameObject et_box, et_fighter_g, tank, et_fighter_r;
	public GamemodeDataKeeper game_mode_data_keeper = GamemodeDataKeeper.Instance;
	GameFrame game_frame;
	GameObject player_obj;
	// Use this for initialization
	void Start () {
		game_frame = GameObject.Find("GameFrame").GetComponent<GameFrame>();
		player_obj = GameObject.Find("PlayerFighter");
		player_obj.GetComponent<PlayerFighter>().Start();
		game_over_graph_create = false;
		game_over_graph_right = GameObject.Find("GameOverRight");
		game_over_graph_left = GameObject.Find("GameOverLeft");
		gameover_text = GameObject.Find("GameOverText");
	}
	
	// Update is called once per frame
	void Update () {
		if(!game_mode_data_keeper.Stop && !game_mode_data_keeper.GameOverJudge()){
			GameMoveLevel();
			NextScene();
		}
		if(game_mode_data_keeper.GameOverJudge()){
			GameOverAction();
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
						game_frame.GameDispWidthL +  et_fighter_g.GetComponent<EnemyMove>().Width/2 + 100.0f,
						game_frame.GameDispHeightU +  et_fighter_g.GetComponent<EnemyMove>().Height,
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
					one_step = (int)enum_one_level.four;
				}else if(one_step == (int)enum_one_level.four && time > 25.0f){
					CreateEFighterR(et_fighter_r, new Vector3(
						game_frame.GameDispWidthL +  et_fighter_g.GetComponent<EnemyMove>().Width/2 + 100.0f,
						game_frame.GameDispHeightU +  et_fighter_g.GetComponent<EnemyMove>().Height,
						game_mode_data_keeper.PlayerFL
					), 10, 10.0f, 1.0f, 100.0f, (int)EnemyBase.enum_shot_type.target_straight, 1.0f);
					one_step = (int)enum_one_level.five;
					game_level = (int)game_move_level.two;
				}
				break;

			case (int)game_move_level.two:
				
				break;
		}
	}

	//基底クラスに移動予定
	GameObject game_over_graph_right;
	GameObject game_over_graph_left;
	GameObject gameover_text;
	const float GAMEOVER_RIGHT_POS = 109.75f;
	const float GAMEOVER_LEFT_POS = -109.75f;
	const float GAMEOVER_GRAPH_MOVE_SPEED = 5.0f;
	bool game_over_image_right_posset = false;
	bool game_over_image_left_posset = false;
	bool game_over_graph_create = false;
	const float GAMEOVER_TEXT_SET_TIME = 2.0f;
		float gameover_text_time = GAMEOVER_TEXT_SET_TIME;
	string gameover_text_base = "GAME OVER";
	int gameover_text_base_num = 0;
	
	void GameOverAction(){
		Vector3 pos_r = game_over_graph_right.GetComponent<RectTransform>().localPosition;
		Vector3 pos_l = game_over_graph_left.GetComponent<RectTransform>().localPosition;
		if(pos_r.x > GAMEOVER_RIGHT_POS + GAMEOVER_GRAPH_MOVE_SPEED){
			pos_r.x -= GAMEOVER_GRAPH_MOVE_SPEED;
			game_over_graph_right.GetComponent<RectTransform>().localPosition = pos_r;
		}else{
			pos_r.x = GAMEOVER_RIGHT_POS;
			game_over_graph_right.GetComponent<RectTransform>().localPosition = pos_r;
			game_over_image_right_posset = true;
		}
		if(pos_l.x <= GAMEOVER_LEFT_POS - GAMEOVER_GRAPH_MOVE_SPEED){
			pos_l.x += GAMEOVER_GRAPH_MOVE_SPEED;
			game_over_graph_left.GetComponent<RectTransform>().localPosition = pos_l;
		}else{
			pos_l.x = GAMEOVER_LEFT_POS;
			game_over_graph_left.GetComponent<RectTransform>().localPosition = pos_l;
			game_over_image_left_posset = true;
		}

		if(game_over_image_left_posset && game_over_image_right_posset){
			if(gameover_text_base_num < gameover_text_base.Length){
				gameover_text_time += Time.deltaTime;
				if(gameover_text_time > GAMEOVER_TEXT_SET_TIME){
					gameover_text.GetComponent<Text>().text += gameover_text_base[gameover_text_base_num];
					gameover_text_base_num++;
				}
			}
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

	void CreateEFighterR(GameObject fighter_, Vector3 pos_, int score_, float hp_,
	 float move_speed_, float shot_speed_, int shot_type_, float shot_cool_time_){
		str_obj = Instantiate(fighter_, pos_, Quaternion.identity);
		str_obj.GetComponent<ETFighterR>().SetState(score_, hp_, shot_speed_, shot_type_, shot_cool_time_);
		str_obj.GetComponent<EnemyMove>().MoveSpeed = move_speed_;
	}

	void NextScene(){
		if(Input.GetKey(KeyCode.F1)){
			SceneManager.LoadScene("GameModeTwo");
		}
	}
	//
}
