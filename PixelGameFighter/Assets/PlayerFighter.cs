using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : MonoBehaviour {
	GameFrame gameFrame;
	// Use this for initialization
	void Start () {
		gameFrame = GameObject.Find("GameFrame").GetComponent<GameFrame>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
