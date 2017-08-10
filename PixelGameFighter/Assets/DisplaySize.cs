using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySize : MonoBehaviour {
	
	public int width, height;
	// Use this for initialization
	void Start () {
		width = Screen.width;
		height = Screen.height;
	}
	
	// Update is called once per frame
	

	public int GetWidth(){
		return width;
	}

	public int GetHeight(){
		return height;
	}
}
