using System.Collections;
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
	// Use this for initialization
	public override void Start () {
		base.Start();
		game_frame = GameObject.Find("GameFrame").GetComponent<GameFrame>();
		this_plane_size = base.Size;
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
		if(this.transform.position.y < -base.Height/2 + game_frame.Height + margin && !create_flag){
			Instantiate(
				this,
				new Vector3(this.transform.position.x, this.transform.position.y + base.Height, this.transform.position.z),
				base.Rotate);
			create_flag = true;
		}
		if(this.transform.position.y < -base.Size.y - margin - game_frame.Height){
			Destroy(this.gameObject);
		}
	}
}
