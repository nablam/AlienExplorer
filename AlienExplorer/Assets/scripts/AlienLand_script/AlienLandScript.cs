using UnityEngine;
using System.Collections;

public class AlienLandScript : MonoBehaviour {

    Vector3 centerOfMyplanet;
    float radiusOfMyPlanet;
    float alienspeed;
    public void setMyplanetCEnterandRadius(Vector3 c, float r) { centerOfMyplanet = c; radiusOfMyPlanet = r; }

	void Start () {
        alienspeed = 5f;

    }
	
 
	void Update () {
       transform.RotateAround(centerOfMyplanet, transform.right, -Time.deltaTime * alienspeed);
    }
}
