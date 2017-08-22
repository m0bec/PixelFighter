using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFrame : MonoBehaviour {
	const float GAME_DISP_WIDTH_L = -280.0f;
	public float GameDispWidthL{
		get{return GAME_DISP_WIDTH_L;}
	}
	const float GAME_DISP_WIDTH_R = 120.0f;
	public float GameDispWidthR{
		get{return GAME_DISP_WIDTH_R;}
	}
	const float GAME_DISP_HEIGHT_U = 200.0f;
	public float GameDispHeightU{
		get{return GAME_DISP_HEIGHT_U;}
	}
	const float GAME_DISP_HEIGHT_D = -160.0f;
	public float GameDispHeightD{
		get{return GAME_DISP_HEIGHT_D;}
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
