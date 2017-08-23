using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeOneSystem : MonoBehaviour {
	public GameObject et_box, et_fighter_g;
	public GamemodeDataKeeper game_mode_data_keeper = GamemodeDataKeeper.Instance;
	GameFrame game_frame;
	// Use this for initialization
	void Start () {
		game_frame = GameObject.Find("GameFrame").GetComponent<GameFrame>();
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
					str_obj = Instantiate(et_fighter_g, new Vector3(
						game_frame.GameDispWidthL + et_fighter_g.GetComponent<EnemyMove>().Width/2 + 100.0f,
						game_frame.GameDispHeightU + et_fighter_g.GetComponent<EnemyMove>().Height,
						game_mode_data_keeper.PlayerFL
					),
					Quaternion.identity);
					str_obj.GetComponent<ETFighterG>().SetState(10, 10.0f);
					str_obj.GetComponent<EnemyMove>().MoveSpeed = 1.0f;
					time -= 5.0f;
				}
				break;
		}
	}

	void NextScene(){
		if(Input.GetKey(KeyCode.F1)){
			SceneManager.LoadScene("GameModeTwo");
		}
	}
}
