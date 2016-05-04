using UnityEngine;
using System.Collections;

public class OneSecondDestroy : MonoBehaviour {

 
	void Start () {
        StartCoroutine("dodestroy");

    }
	
	

    IEnumerator dodestroy() {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

}
