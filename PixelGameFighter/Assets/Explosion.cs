using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
	ParticleSystem particle;
	// Use this for initialization
	void Start () {
		particle = transform.Find("Particle System").GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!particle.isPlaying)	Destroy(this.gameObject);	
	}
}
