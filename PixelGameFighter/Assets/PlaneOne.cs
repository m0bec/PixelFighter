﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneOne : SPlane {
	GameFrame game_frame;
	bool create_flag = false;
	const float margin = 400.0f;
	Vector3 this_plane_size;
	public Vector3 ThisPlaneSize{
		get{return this_plane_size;}
	}
	StageOneScrollSystem scroll_system;
	// Use this for initialization
	public override void Start () {
		base.Start();
		game_frame = GameObject.Find("GameFrame").GetComponent<GameFrame>();
		scroll_system = GameObject.Find("StageOneScrollSystem").GetComponent<StageOneScrollSystem>();
		this_plane_size = base.Size;
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
		if(this.transform.position.y < -scroll_system.PlanePosition.y + margin && !create_flag){
			Instantiate(
				this,
				new Vector3(scroll_system.PlanePosition.x, scroll_system.PlanePosition.y + game_frame.Height + margin, scroll_system.PlanePosition.z),
				base.Rotate);
			create_flag = true;
		}
		if(this.transform.position.y < -base.Size.y - margin - game_frame.Height){
			Destroy(this.gameObject);
		}
	}
}
