using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EFighterP : MonoBehaviour {
	const float ROLL_SPEED = 10.0f;
	public GamemodeDataKeeper game_mode_data_keeper = GamemodeDataKeeper.Instance;

	// Update is called once per frame
	void Update () {
		if(!game_mode_data_keeper.Stop){
			this.transform.Rotate(new Vector3(0.0f, ROLL_SPEED, 0.0f));
		}
	}
}
