using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETBox : EnemyBase {
	const float TURN_SPEED =5.0f;
	// Use this for initialization
	public override void Start () {
		base.Start();
		base.Score = 10;
		base.Hp = 10.0f;
	}
	
	// Update is called once per frame
	public override void Update () {
		this.transform.Rotate(new Vector3(0.0f, TURN_SPEED, 0.0f));
	}
}
