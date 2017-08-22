using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
	Text write_text;
	string now_score;
	GameModeOneSystem game_mode_one_system;
	// Use this for initialization
	void Start () {
		write_text = GetComponentInChildren<Text>();
		game_mode_one_system = GameObject.Find("GameModeOneSystem").GetComponent<GameModeOneSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		now_score = game_mode_one_system.game_mode_data_keeper.Score.ToString("D8");
		write_text.text = "Score\n" + now_score;
	}
}
