using UnityEngine;
using System.Collections;

public class BottomCollider : MonoBehaviour {

	 
	void Start () {
        print(transform.parent.name);
	}
	
	 
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {


       

            print("good hit");
     }
}
