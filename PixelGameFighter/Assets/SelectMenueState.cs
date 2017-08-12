using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMenueState : MonoBehaviour {
	int menue_state;
	// Use this for initialization
	void Start () {
		menue_state = (int)MenueStateEnum.StateName.Start;
	}
	
	// Update is called once per frame
	void Update () {
		ChangeMenueState();
	}

	public int GetMenueState(){
		return menue_state;
	}

	void ChangeMenueState(){
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			menue_state++;
		}
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			menue_state--;
		}
		if(menue_state > (int)MenueStateEnum.StateName.Exit){
			menue_state = (int)MenueStateEnum.StateName.Start;
		}else if(menue_state < (int)MenueStateEnum.StateName.Start){
			menue_state = (int)MenueStateEnum.StateName.Exit;
		}
	}
}
