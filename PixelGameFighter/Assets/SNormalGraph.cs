using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SNormalGraph : MonoBehaviour {
	const float DEF_WIDTH = 640;
	const float DEF_HEIGHT = 480;
	DisplaySize display_size;
	GameObject statemrt_menue_sys;
	float width, height;
	public float width_rate, height_rate;
	// Use this for initialization
	public virtual void Start () {
		width = Screen.width;
		height = Screen.height;
		width_rate = width/DEF_WIDTH;
		height_rate = height/DEF_HEIGHT;
	}
	
	// Update is called once per frame
}
