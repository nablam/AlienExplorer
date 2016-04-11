using UnityEngine;
using System.Collections;
namespace S3{

    public class camerascript1 : MonoBehaviour
    {

        private GameManager_Master _gammaster;
        private GameObject rocket;

        private rosketVector rv;
        
        void Start()
        {

             
            rocket = GameObject.Find("rocketprefab");
            rv = rocket.GetComponent<rosketVector>();

        }

        // Update is called once per frame
        void Update()
        {
            showplayerspeed();

            if (rocket != null) {

                if (rv.rocketspeed != float.PositiveInfinity)
                    transform.position = new Vector3(rocket.transform.position.x, rocket.transform.position.y, -45f - (Mathf.Abs(rv.rocketspeed * 2)));
                else
                    transform.position = new Vector3(rocket.transform.position.x, rocket.transform.position.y, transform.position.z + 0f);
            }
         
        }


        void showplayerspeed()
        {
           // print(rocket.GetComponent<Rigidbody>().velocity);

        }
    }

}
