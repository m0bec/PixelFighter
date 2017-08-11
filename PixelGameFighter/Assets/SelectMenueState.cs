using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMenueState : MonoBehaviour {
	int menue_state;
	// Use this for initialization
	void Start () {
		menue_state = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int GetMenueState(){
		return menue_state;
	}
}
