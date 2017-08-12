using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStart : SText {
	public MenueStateEnum menue_state_enum;
	// Use this for initialization
	public override void Start () {
		base.Start();
		base.SetStateNum((int)MenueStateEnum.StateName.Start);
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
		if(select_menue_system.GetMenueState() == base.GetStateNum()){
			this.GetComponent<Text>().color = base.select_color;
		}else{
			this.GetComponent<Text>().color = base.not_select_color;
		}
	}
}
