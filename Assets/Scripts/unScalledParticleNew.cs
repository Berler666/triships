using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unScalledParticleNew : MonoBehaviour {
	ParticleSystem ps;
	// Use this for initialization
	void Start () {
		ps = transform.gameObject.GetComponent <ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale < 0.01f) {
			ps.Simulate (Time.unscaledDeltaTime, true, false);
		}
		
	}
}
