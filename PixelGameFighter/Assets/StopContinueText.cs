using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopContinueText : SText {

	// Use this for initialization
	public override void Start () {
		base.Start();
		this.GetComponent<Text>().text = "";
		base.SetStateNum((int)StopSystem.StateName.Cont);
	}

	public GamemodeDataKeeper game_mode_data_keeper = GamemodeDataKeeper.Instance;
	// Update is called once per frame
	public override void Update () {
		if(game_mode_data_keeper.Stop){
			base.Update();
			this.GetComponent<Text>().text = "ゲームを続ける";
			if(base.GetStateNum() == base.stop_system.MenueState){
				this.GetComponent<Text>().color = base.select_stop_color;
				SelectAction();
			}else{
				this.GetComponent<Text>().color = base.not_select_stop_color;
			}
		}else{
			this.GetComponent<Text>().text = "";
		}
	}

	void SelectAction(){

	}
}
