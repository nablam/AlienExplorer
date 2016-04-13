using UnityEngine;
using System.Collections;

public class castleScript : MonoBehaviour {

    Vector3 myplanetCenter;
    float myplanetRadius;
    GameObject alien;
    string alienPath;
	void Start () {
        alienPath = "Alien_Land/Alien1";



        StartCoroutine("dofor5seconds");
    }
	void Update () {
	
	}

    void MakeOneALien() {
        alien = Instantiate(Resources.Load(alienPath), transform.position, transform.rotation) as GameObject;
        alien.GetComponent<AlienLandScript>().setMyplanetCEnterandRadius(myplanetCenter, myplanetRadius);
    }

    public void setMyplanetCenterAndRadius(Vector3 center, float radius) { myplanetCenter = center; myplanetRadius = radius; }


    IEnumerator dofor5seconds() {
        InvokeRepeating("MakeOneALien", 0, 4);
        yield return new WaitForSeconds(12);
        CancelInvoke("MakeOneALien");
    }
   


}