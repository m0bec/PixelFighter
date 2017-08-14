using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlane : MonoBehaviour {
	Vector3 size;
	const float move_speed = 5.0f;
	// Use this for initialization
	public virtual void Start () {
		size = this.transform.position;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		transform.position -= new Vector3(0.0f, move_speed, 0.0f);
	}
}
