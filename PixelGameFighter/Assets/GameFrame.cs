using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFrame : MonoBehaviour {
	const float GAME_DISP_WIDTH = 400.0f;
	public float GameDispWidth{
		get{return GAME_DISP_WIDTH;}
	}
	const float GAME_DISP_HEIGHT = 360.0f;
	public float GameDispHeight{
		get{return GAME_DISP_HEIGHT;}
	}
	
	public float width, height;
	public float Width{
		get{return width;}
	}
	public float Height{
		get{return height;}
	}
	// Use this for initialization
	void Start () {
		width = this.GetComponent<SpriteRenderer>().bounds.size.x;
		height = this.GetComponent<SpriteRenderer>().bounds.size.y;
	}
	
	// Update is called once per frame
}
