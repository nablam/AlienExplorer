using UnityEngine;
using System.Collections;

public class harmony : MonoBehaviour {


   float distfromcenter; 


	// Use this for initialization
	void Start () {

        Vector3 diff = Vector3.zero - transform.position;

        distfromcenter = diff.magnitude;

    }
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(Vector3.zero, Vector3.up, 500 * Time.deltaTime / distfromcenter);

    }
}
