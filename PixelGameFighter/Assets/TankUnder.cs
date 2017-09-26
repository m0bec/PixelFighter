using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankUnder : EnemyBase {
	EnemyMove enemy_move;

	public float scrol_speed;

	// Use this for initialization
	public override void Start () {
		base.Start();
		enemy_move = GetComponent<EnemyMove>();
		enemy_move.Width = this.GetComponent<Renderer>().bounds.size.x;
		enemy_move.Height = this.GetComponent<Renderer>().bounds.size.y;
		base.SetGameFrame(enemy_move.game_frame);
		//以下は後で消す
		base.ShotSpeed = 100.0f;
		base.ShotType = (int)EnemyBase.enum_shot_type.target_straight;
		base.Hp = 10.0f;
		base.Score = 5;
	}
	
	Vector3 pos;
	// Update is called once per frame
	public override void Update () {
		base.InField = enemy_move.InField;
		base.Update();
		pos = this.transform.position;
		pos.y -= scrol_speed;
		this.transform.position = pos;
	}

	public void SetState(int score_, float hp_, float shot_speed_,
	 int shot_type_, float shot_cool_time_, float scrol_speed_){
		base.Score = score_;
		base.Hp = hp_;
		base.ShotSpeed = shot_speed_;
		base.ShotType = shot_type_;
		base.ShotCoolTime = shot_cool_time_;
		scrol_speed = scrol_speed_;
	}

	public float GetWidth(){return enemy_move.Width;}
	public float GetHeight(){return enemy_move.Height;}
}
