using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
	Text write_text;
	string now_score;
	int write_score = 0;
	GamemodeDataKeeper gamemode_data_keeper = GamemodeDataKeeper.Instance;
	// Use this for initialization
	void Start () {
		write_text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(write_score < gamemode_data_keeper.Score){
			write_score++;
		}
		now_score = write_score.ToString("D8");
		write_text.text = "Score\n" + now_score;
	}
}
