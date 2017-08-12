using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMenueState : MonoBehaviour {
	public enum MenueType{
		Main
	};
	int menue_type;
	int menue_state;
	// Use this for initialization
	void Start () {
		menue_state = 0;
		menue_type = (int)MenueType.Main;
	}
	
	// Update is called once per frame
	void Update () {
		if(menue_type == (int)MenueType.Main){
			ChangeMenueState();
		}
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

	public void SetMainMenueStateFlag(int menue_type_){
		menue_type = menue_type_;
	}
}
