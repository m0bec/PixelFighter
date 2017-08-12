using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SText : MonoBehaviour {
	int state_num;
	GameObject start_menue_system;
	public SelectMenueState select_menue_system;

	public Color select_color = new Color(0f / 255f, 0f / 255f, 0f / 255f);
	public Color not_select_color = new Color(96f / 255f, 88f / 255f, 88f / 255f);
	// Use this for initialization
	public virtual void Start () {
		start_menue_system = GameObject.Find("StartMenueSystem");
	}

	// Update is called once per frame
	public virtual void Update () {
		select_menue_system  = start_menue_system.GetComponent<SelectMenueState>();
	}

	public virtual void SetStateNum(int state_num_){
		state_num = state_num_;
	}

	public int GetStateNum(){
		return state_num;
	}
	
}
