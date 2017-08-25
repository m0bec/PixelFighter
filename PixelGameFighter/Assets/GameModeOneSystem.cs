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
	}
	
	// Update is called once per frame
	void Update () {
		GameMoveLevel();
		NextScene();
	}
	
	enum game_move_level{
		one
	}
	int game_level = (int)game_move_level.one;
	float time = 0.0f;
	List<float> one_next_game_level = new List<float>{10.0f};
	enum enum_one_level{one}
	int one_step = (int)enum_one_level.one;
	
	GameObject str_obj;
	void GameMoveLevel(){
		switch(game_level){
			case (int)game_move_level.one:
				time += Time.deltaTime;
				if(one_step == (int)enum_one_level.one && 
				time > one_next_game_level[(int)enum_one_level.one]){
					CreateTank(tank, new Vector3(
						game_frame.GameDispWidthL + tank.GetComponent<EnemyMove>().Width/2 + 100.0f,
						game_frame.GameDispHeightU + tank.GetComponent<EnemyMove>().Height,
						game_mode_data_keeper.PlayerFL
					), 10, 10.0f, 1.0f);
					time -= 5.0f;
				}
				break;
		}
	}

	void CreateTank(GameObject tank_, Vector3 pos_, int score_, float hp_, float move_speed_){
		str_obj = Instantiate(tank_, pos_, Quaternion.identity);
		str_obj.GetComponent<TankUnder>().SetState(score_, hp_);
		str_obj.GetComponent<EnemyMove>().MoveSpeed = move_speed_;
	}

	void NextScene(){
		if(Input.GetKey(KeyCode.F1)){
			SceneManager.LoadScene("GameModeTwo");
		}
	}
}
