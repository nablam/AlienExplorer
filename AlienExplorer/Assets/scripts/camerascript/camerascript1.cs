using UnityEngine;
using System.Collections;
namespace nabspace{

    public class camerascript1 : MonoBehaviour
    {

        private GameManager_Master _gammaster;
        private GameObject rocket;

        private rocketVector rv;
        private Player_Master _playermaster;


         public GameObject roverref;
        //   Rover_Script RScript;


        float minDistFromShip = 80f;
        float mindistFromRover = 50f;


        void OnEnable()
        {
            SetInitialReferences();
            _playermaster.EventCreateRover += findCreatedRover;
            _playermaster.EventGarageRover += forgetCreatedRover;
        }

        void findCreatedRover() { roverref = GameObject.Find("rover1(Clone)"); }
        void forgetCreatedRover() { roverref = null; }

        void OnDisable()
        {
            _playermaster.EventCreateRover -= findCreatedRover;
            _playermaster.EventGarageRover -= forgetCreatedRover;
        }

        void SetInitialReferences()
        {
            _gammaster = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
            rocket = GameObject.Find("rocketprefab");
            rv = rocket.GetComponent<rocketVector>();
            _playermaster = rocket.GetComponent<Player_Master>();
            //  roverref = rocket.transform.GetChild(0).gameObject;
            //  RScript = roverref.GetComponent<Rover_Script>();
            t = 0;
        }


        void Start()
        {
         

        }

        // Update is called once per frame
        void Update()
        {
            foccusRocket();
            foccusRover();

        }


        void foccusRocket() {
            if (_gammaster.isRocketMode)
            {
                if (rocket != null)
                {

                    if (rv.rocketspeed != float.PositiveInfinity)
                        transform.position = new Vector3(rocket.transform.position.x, rocket.transform.position.y, -minDistFromShip - (Mathf.Abs(rv.rocketspeed * 20)));
                    else
                        transform.position = new Vector3(rocket.transform.position.x, rocket.transform.position.y, transform.position.z + 0f);
                }
            }
        }


        void foccusRover() {
            if (_gammaster.isRoverMode)
            {
                if (roverref == null) { findCreatedRover(); }
                followrover();
            }
        }


        void followrover()
        {
             transform.position = new Vector3(roverref.transform.position.x, roverref.transform.position.y, transform.position.z + 0f);
            transform.localRotation = new Quaternion(0, 0, -roverref.transform.localRotation.y, roverref.transform.localRotation.w);
          //  roverref.transform.parent = this.transform;
        }

        void oldWayofFocussingOnRocketOrRover() {
            if (_gammaster.isRocketMode)
            {
                if (rocket != null)
                {

                    if (rv.rocketspeed != float.PositiveInfinity)
                        transform.position = new Vector3(rocket.transform.position.x, rocket.transform.position.y, -60f - (Mathf.Abs(rv.rocketspeed * 2)));
                    else
                        transform.position = new Vector3(rocket.transform.position.x, rocket.transform.position.y, transform.position.z + 0f);
                }
            }
            else
            if (_gammaster.isRoverMode)
            {
                //if (roverref != null)
                //{
                //    followrover(); 

                //}
            }
        }

        float t;
        //IEnumerator camfix() {

        //    Quaternion start = transform.rotation;
        //    Quaternion end = roverref.transform.localRotation;
        //    t += 0.1f;
        //  //  transform.rotation = Quaternion.Slerp(start,end ,t );
        //    yield return new WaitForSeconds(2f);
        //    followrover();
        //}

        //void followrover()
        //{
        //    transform.position = new Vector3(roverref.transform.position.x, roverref.transform.position.y, transform.position.z + 0f);
        //    transform.localRotation = new Quaternion(0, 0, -roverref.transform.localRotation.y, roverref.transform.localRotation.w);
        //}

        void showplayerspeed()
        {
           // print(rocket.GetComponent<Rigidbody>().velocity);

        }
    }

}
