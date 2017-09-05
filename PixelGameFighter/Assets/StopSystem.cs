using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		menue_state = (int)StateName.Cont;
	}

	public GamemodeDataKeeper game_mode_data_keeper = GamemodeDataKeeper.Instance;
	// Update is called once per frame
	void Update () {
		if(game_mode_data_keeper.Stop){
			ChangeMenueState();
		}
	}

	public enum StateName{
		Cont, Exit
	}
	int menue_state;
	public int MenueState{
		get{return menue_state;}
	}
	void ChangeMenueState(){
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			menue_state++;
		}
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			menue_state--;
		}
		if(menue_state > (int)StateName.Exit){
			menue_state = (int)StateName.Cont;
		}else if(menue_state < (int)StateName.Cont){
			menue_state = (int)StateName.Exit;
		}
	}
}
