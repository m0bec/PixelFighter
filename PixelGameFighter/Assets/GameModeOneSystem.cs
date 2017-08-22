using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeOneSystem : MonoBehaviour {
	public GamemodeDataKeeper game_mode_data_keeper = GamemodeDataKeeper.Instance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		NextScene();
	}
	
	void NextScene(){
		if(Input.GetKey(KeyCode.F1)){
			SceneManager.LoadScene("GameModeTwo");
		}
	}
}
