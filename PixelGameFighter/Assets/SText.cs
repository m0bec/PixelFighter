using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SText : MonoBehaviour {
	int state_num;
	GameObject start_menue_system;
	public SelectMenueState select_menue_system;
	public StopSystem stop_system;

	public Color select_color = new Color(0f / 255f, 0f / 255f, 0f / 255f);
	public Color not_select_color = new Color(96f / 255f, 88f / 255f, 88f / 255f);
	public Color select_stop_color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
	public Color not_select_stop_color = new Color(171f / 255f, 161f / 255f, 161f / 255f);
	// Use this for initialization
	public virtual void Start () {
		if(this.gameObject.transform.tag == "TitleText"){
			start_menue_system = GameObject.Find("StartMenueSystem");
		}else if(this.gameObject.transform.tag == "StopMenue"){
			stop_system = GameObject.Find("StopSystem").GetComponent<StopSystem>();
		}
	}

	// Update is called once per frame
	public virtual void Update () {
		if(this.gameObject.transform.tag == "TitleText"){
			select_menue_system  = start_menue_system.GetComponent<SelectMenueState>();
		}
	}

	public virtual void SetStateNum(int state_num_){
		state_num = state_num_;
	}

	public int GetStateNum(){
		return state_num;
	}
	
}
