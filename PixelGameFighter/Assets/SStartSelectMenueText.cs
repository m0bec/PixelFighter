using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SStartSelectMenueText : MonoBehaviour {
	int state_num;
	GameObject start_select_menue_system;
	public StartSelectMenueSystem select_menue_system;

	public Color select_color = new Color(0f / 255f, 0f / 255f, 0f / 255f);
	public Color not_select_color = new Color(96f / 255f, 88f / 255f, 88f / 255f);
	// Use this for initialization
	public virtual void Start () {
		start_select_menue_system = GameObject.Find("StartSelectMenueSystem");
	}

	// Update is called once per frame
	public virtual void Update () {
		select_menue_system  = start_select_menue_system.GetComponent<StartSelectMenueSystem>();
	}

	public void SetStateNum(int state_num_){
		state_num = state_num_;
	}

	public int GetStateNum(){
		return state_num;
	}
	
}
