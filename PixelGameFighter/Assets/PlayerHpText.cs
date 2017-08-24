using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpText : MonoBehaviour {
	Text write_text;
	int player_hp;
	string str_text;
	GamemodeDataKeeper gamemode_data_keeper = GamemodeDataKeeper.Instance;
	// Use this for initialization
	void Start () {
		write_text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		player_hp = gamemode_data_keeper.PlayerHp;
		str_text = player_hp.ToString();
		write_text.text = "残機\n" + str_text;
	}
}
