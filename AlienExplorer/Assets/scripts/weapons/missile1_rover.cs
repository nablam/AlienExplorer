using UnityEngine;
using System.Collections;

public class missile1_rover : MonoBehaviour {



    Vector3 centerOfPlanet;
    float missilespeed =50;

    public void setPlanetCenter(Vector3 c) { centerOfPlanet = c; }

	void Start () {
         StartCoroutine("killinseconds");
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(centerOfPlanet, transform.right, Time.deltaTime * missilespeed);
    }

    IEnumerator killinseconds() {

        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemylandTAG")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }



  
}
