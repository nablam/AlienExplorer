﻿using UnityEngine;
using System.Collections;

public class CompassScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Vector3.zero);
    }
}