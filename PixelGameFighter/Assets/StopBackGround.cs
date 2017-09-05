using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBackGround : MonoBehaviour {
	public GamemodeDataKeeper game_mode_data_keeper = GamemodeDataKeeper.Instance;
	// Update is called once per frame
	void Update () {
		if(!game_mode_data_keeper.Stop){
			Destroy(this.gameObject);
		}
	}
}
