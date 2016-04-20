using UnityEngine;

public class rocket_missileScript : MonoBehaviour {

     float speed = 100f;
    Transform playertrans;
    Vector3 playerpos;


	void Start () {

        playertrans = GameObject.Find("rocketprefab").transform;

    }


    float distToRocket() {
        Vector3 diff = transform.position - playerpos;

        Debug.DrawLine(transform.position, playerpos, Color.red);

        return diff.magnitude;
    }

	// Update is called once per frame
	void Update () {
        if (playertrans != null)
        {
            playerpos = playertrans.position;
            //  transform.Translate(transform.forward * Time.deltaTime);
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
            checkdestroyByDistance();
        }

    }


    void checkdestroyByDistance() {

        if (distToRocket() > 100f) Destroy(gameObject);
    }



    void OnCollisionEnter(Collision collider)
    {

        Destroy(gameObject);

        //if (collider.gameObject.tag == "enemyshipTAG")
        //{        
        //    Destroy(collider.gameObject);
        //}
        //if (collider.gameObject.tag == "enemylandTAG")
        //{
        //    Destroy(collider.gameObject);
        //}

    }
}
