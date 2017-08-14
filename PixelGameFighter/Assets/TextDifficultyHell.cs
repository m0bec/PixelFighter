using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextDifficultyHell : SStartSelectMenueText {

	// Use this for initialization
	public override void Start () {
		base.Start();
		base.SetStateNum((int)StartSelectMenueSystem.DifficultyState.Hell);
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
			base.gamemode_data_keeper.Difficulty = (int)StartSelectMenueSystem.DifficultyState.Hell;
			SceneManager.LoadScene(base.GameModeSceneName);
		}
	}
}
