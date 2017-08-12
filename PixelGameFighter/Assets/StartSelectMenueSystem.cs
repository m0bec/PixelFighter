using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSelectMenueSystem : MonoBehaviour {
	int menue_state;
	public enum DifficultyState{
		Normal,
		Hard,
		Hell
	};
	// Use this for initialization
	void Start () {
		menue_state = (int)DifficultyState.Normal;
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
		if(menue_state > (int)DifficultyState.Hell){
			menue_state = (int)DifficultyState.Normal;
		}else if(menue_state < (int)DifficultyState.Normal){
			menue_state = (int)DifficultyState.Hell;
		}
	}
}
