using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETFighterG : EnemyBase {
	EnemyMove enemy_move;
	// Use this for initialization
	public override void Start () {
		base.Start();
		enemy_move = GetComponent<EnemyMove>();
		enemy_move.Width = this.GetComponent<Renderer>().bounds.size.x;
		enemy_move.Height = this.GetComponent<Renderer>().bounds.size.y;
		base.Score = 10;
		base.Hp = 15.0f;
	}
	
	// Update is called once per frame
	public override void Update () {
		base.InField = enemy_move.InField;
	}

	public void SetState(int score_, float hp_){
		base.Score = score_;
		base.Hp = hp_;
	}

	public float GetWidth(){return enemy_move.Width;}
	public float GetHeight(){return enemy_move.Height;}
}
