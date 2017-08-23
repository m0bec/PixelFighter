using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EFighterP : MonoBehaviour {
	const float ROLL_SPEED = 10.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(new Vector3(0.0f, ROLL_SPEED, 0.0f));
	}
}
