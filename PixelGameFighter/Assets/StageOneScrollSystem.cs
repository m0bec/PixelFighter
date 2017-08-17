using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOneScrollSystem : MonoBehaviour {
	GameFrame game_frame;
	float game_frame_width, game_frame_height;
	Vector3 plane_position;
	public Vector3 PlanePosition{
		get{return plane_position;}
	}
	PlaneOne plane_one;
	// Use this for initialization
	void Start () {
		game_frame = GameObject.Find("GameFrame").GetComponent<GameFrame>();
		plane_one = GameObject.Find("PlaneOne").GetComponent<PlaneOne>();
	}
	
	// Update is called once per frame
	void Update () {
		if(plane_one != null){
			plane_position = plane_one.ThisPlaneSize;
		}
	}
}
