using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextDifficultyNormal : SStartSelectMenueText {
	GamemodeDataKeeper gamemode_data_keeper = GamemodeDataKeeper.Instance;
	// Use this for initialization
	public override void Start () {
		base.Start();
		base.SetStateNum((int)StartSelectMenueSystem.DifficultyState.Normal);
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
		if(select_menue_system.GetMenueState() == base.GetStateNum()){
			this.GetComponent<Text>().color = base.select_color;
			SelectAction();
		}else{
			this.GetComponent<Text>().color = base.not_select_color;
		}
	}

	void SelectAction(){
		if(Input.GetKeyDown(KeyCode.Return)){
			gamemode_data_keeper.Difficulty = (int)StartSelectMenueSystem.DifficultyState.Normal;
			SceneManager.LoadScene("GameModeOne");
		}
	}
}
