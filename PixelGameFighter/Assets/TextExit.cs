﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextExit : SText {

	// Use this for initialization
	public override void Start () {
		base.Start();
		base.SetStateNum((int)MenueStateEnum.StateName.Exit);
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
			Application.Quit();
		}
	}
}
