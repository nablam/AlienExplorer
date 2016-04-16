using UnityEngine;
using System.Collections;

public class enemySkyMissileScript : MonoBehaviour {

    float speed = 80;
	void Start () {
        StartCoroutine("killmissilein5seconds");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
    }

    IEnumerator killmissilein5seconds()
    {
         
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }



}
