﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticles : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<ParticleSystem>().Emit(100);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
