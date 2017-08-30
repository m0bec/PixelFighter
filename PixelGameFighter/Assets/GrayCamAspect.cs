using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayCamAspect : MonoBehaviour {
	public RenderTexture render_texture;
	Camera cam;
	// Use this for initialization
	void Start () {
		cam = this.GetComponent<Camera>();
		float camera_aspect = cam.aspect;
		cam.targetTexture = render_texture;
		cam.aspect = camera_aspect;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
