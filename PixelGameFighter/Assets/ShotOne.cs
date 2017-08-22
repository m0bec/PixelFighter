using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotOne : MonoBehaviour {
	GameFrame game_frame;
	float width, height;
	// Use this for initialization
	void Start () {
		game_frame = GameObject.Find("GameFrame").GetComponent<GameFrame>();
		width = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
		height = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
	}
	
	Vector3 next_pos;
	const float MOVE_SPEED = 10.0f;
	bool death_flag = false;
	// Update is called once per frame
	void Update () {
		next_pos = this.transform.position;
		next_pos.y += 10.0f;
		if(next_pos.x >= game_frame.GameDispWidthR - width/2){ death_flag = true;}
		else if(next_pos.x <= game_frame.GameDispWidthL + width/2){ death_flag = true; }
		if(next_pos.y >= game_frame.GameDispHeightU - height/2){ death_flag = true; }
		else if(next_pos.y <= game_frame.GameDispHeightD + height/2){ death_flag = true; }
		if(death_flag)	Destroy(this.gameObject);
		this.transform.position = next_pos;
	}
}
