using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
	GameFrame game_frame;
	// Use this for initialization
	void Start(){
		game_frame = GameObject.Find("GameFrame").GetComponent<GameFrame>();
	}
	// Update is called once per frame
	void Update () {
		Move();
	}

	int move_num;
	public int MoveNum{set{move_num = value;}}
	enum MOVE_NUM{
		straight_down
	}
	float move_speed;
	public float MoveSpeed{set{move_speed = value;}}
	Vector3 str_pos;
	bool in_field = false;
	public bool InField{
		get{return in_field;}
	}
	void Move(){
		str_pos = this.transform.position;
		if(!in_field){
			if(CheckIn())	in_field = true;
		}else{
			if(!CheckIn())	Destroy(this.gameObject);
		}
		switch(move_num){
			case (int)MOVE_NUM.straight_down:
				str_pos.y -= move_speed;
				this.transform.position = str_pos;
				break;
		}
	}

	bool CheckIn(){
		if(str_pos.x <= game_frame.GameDispWidthR - width/2 &&
		str_pos.x >= game_frame.GameDispWidthL + width/2 &&
		str_pos.y <= game_frame.GameDispHeightU - height/2 &&
		str_pos.y <= game_frame.GameDispHeightD + height/2){
			return true;		
		}else{
			return false;
		}
	}

	float width, height;
	public float Width{
		get{return width;}
		set{width = value;}
	}
	public float Height{
		get{return height;}
		set{height = value;}
	}
}
