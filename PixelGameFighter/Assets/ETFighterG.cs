using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETFighterG : EnemyBase {

	// Use this for initialization
	public override void Start () {
		base.Start();
		base.Score = 10;
		base.Hp = 15.0f;
	}
	
	// Update is called once per frame
	public override void Update () {
		
	}
}
