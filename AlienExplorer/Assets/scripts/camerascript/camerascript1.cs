using UnityEngine;
using System.Collections;

public class camerascript1 : MonoBehaviour {


    private GameObject rocket;
	// Use this for initialization
	void Start () {
        rocket = GameObject.Find("rocketprefab");


    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(rocket.transform.position.x, rocket.transform.position.y, transform.position.z);
	}
}
