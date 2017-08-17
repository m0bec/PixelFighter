using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneOne : SPlane {
	GameFrame game_frame;
	bool create_flag = false;
	const float margin = 100.0f;
	// Use this for initialization
	public override void Start () {
		base.Start();
		game_frame = GameObject.Find("GameFrame").GetComponent<GameFrame>();
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
		if(this.transform.position.y < -base.Size.y && !create_flag){
			Instantiate(
				this,
				new Vector3(base.Size.x, base.Size.y + game_frame.Height, base.Size.z),
				base.Rotate);
			create_flag = true;
		}
		if(this.transform.position.y < -base.Size.y - margin - game_frame.Height){
			Destroy(this.gameObject);
		}
	}
}
