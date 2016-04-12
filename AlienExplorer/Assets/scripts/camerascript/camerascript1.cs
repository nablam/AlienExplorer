using UnityEngine;
using System.Collections;
namespace S3{

    public class camerascript1 : MonoBehaviour
    {

        private GameManager_Master _gammaster;
        private GameObject rocket;

        private rosketVector rv;

        GameObject roverref;
        Rover_Script RScript;

        void Start()
        {
            _gammaster = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>(); 

            rocket = GameObject.Find("rocketprefab");
            rv = rocket.GetComponent<rosketVector>();




            roverref = rocket.transform.GetChild(0).gameObject;
            RScript = roverref.GetComponent<Rover_Script>();

        }

        // Update is called once per frame
        void Update()
        {
            if (_gammaster.isRocketMode)
            {
                if (rocket != null)
                {

                    if (rv.rocketspeed != float.PositiveInfinity)
                        transform.position = new Vector3(rocket.transform.position.x, rocket.transform.position.y, -45f - (Mathf.Abs(rv.rocketspeed * 2)));
                    else
                        transform.position = new Vector3(rocket.transform.position.x, rocket.transform.position.y, transform.position.z + 0f);
                }
            }
            else
             if (_gammaster.isRoverMode)
            {
                if (roverref != null)
                {
                    transform.position = new Vector3(roverref.transform.position.x, roverref.transform.position.y, transform.position.z + 0f);
                    transform.localRotation = new Quaternion(0,  0, -roverref.transform.localRotation.y, roverref.transform.localRotation.w );
                }
            }
        }


        void showplayerspeed()
        {
           // print(rocket.GetComponent<Rigidbody>().velocity);

        }
    }

}
