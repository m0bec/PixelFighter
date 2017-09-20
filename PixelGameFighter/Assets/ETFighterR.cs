using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETFighterR : EnemyBase {
	EnemyMove enemy_move;
	// Use this for initialization
	public override void Start () {
		base.Start();
		enemy_move = GetComponent<EnemyMove>();
		enemy_move.Width = this.GetComponent<Renderer>().bounds.size.x;
		enemy_move.Height = this.GetComponent<Renderer>().bounds.size.y;
		base.SetGameFrame(enemy_move.game_frame);
		base.Score = 10;
		base.Hp = 15.0f;
	}
	
	// Update is called once per frame
	public override void Update () {
		base.InField = enemy_move.InField;
		base.Update();
	}

	public void SetState(int score_, float hp_, float shot_speed_,
	 int shot_type_, float shot_cool_time_){
		base.Score = score_;
		base.Hp = hp_;
		base.ShotSpeed = shot_speed_;
		base.ShotType = shot_type_;
		base.ShotCoolTime = shot_cool_time_;
	}

	public float GetWidth(){return enemy_move.Width;}
	public float GetHeight(){return enemy_move.Height;}
}
