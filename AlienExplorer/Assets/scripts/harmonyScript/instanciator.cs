using UnityEngine;
using System.Collections;

public class instanciator : MonoBehaviour {


    public GameObject ball;
    GameObject go;

	// Use this for initialization
	void Start () {

        for (int x = 2; x < 20; x++) {

            go = Instantiate(ball, new Vector3(x, 0, 0), Quaternion.identity) as GameObject;

            go.GetComponent<MeshRenderer>().material.color = new Color(1,0.2f*x, 0.1f*x);
     
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
