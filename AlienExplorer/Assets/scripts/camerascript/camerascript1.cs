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

                   
                    // roverref.transform.parent = this.transform;
                      transform.position = new Vector3(roverref.transform.position.x, roverref.transform.position.y, transform.position.z + 0f);
                    //  transform.rotation = new Quaternion( 0 ,0, roverref.transform.rotation.y, 0);// transform.rotation.w);

                     float therot = (roverref.transform.eulerAngles.x -270 ) % 360;
                    transform.rotation = Quaternion.Euler(0,  0, therot);
                    // transform.eulerAngles =  new Vector3(0,0, therot);

                    //Debug.Log(transform.rotation + "  " +" "+ roverref.transform.rotation+ " " + transform.eulerAngles + " "+ roverref.transform.rotation.eulerAngles);

                }
            }





        }


        void showplayerspeed()
        {
           // print(rocket.GetComponent<Rigidbody>().velocity);

        }
    }

}
