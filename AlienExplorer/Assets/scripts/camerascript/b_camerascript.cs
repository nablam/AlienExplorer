using UnityEngine;
using System.Collections;
namespace nabspace {
    public class b_camerascript : MonoBehaviour
    {

        private GameManager_Master _gammaster;
        private Player_Master _playermaster;
        private GameObject _rocket;
        private b_rocket_Vector _rv;
        private float fraction;
        private float _t;
        private Vector3 _initialCameraPositionAbovPlayer;
        private Vector3 _finalCameraPositionAbovePlayer;
        public GameObject roverref;

        float minDistFromShip = 60f;
        float maxDistFRomShip = 220f;
        float mindistFromRover = 50f;
        float distanceFormshipFactor = 5f;

        private float maxdisd = 200f;
        private float mindist = 60;
        private float cnt = 0;
        void OnEnable()
        {
            SetInitialReferences();
            _playermaster.EventCreateRover += findCreatedRover;
            _playermaster.EventGarageRover += forgetCreatedRover;
        }

        void findCreatedRover() { roverref = GameObject.Find("roverOuterInner(Clone)"); }
        void forgetCreatedRover() { roverref = null; }

        void OnDisable()
        {
            _playermaster.EventCreateRover -= findCreatedRover;
            _playermaster.EventGarageRover -= forgetCreatedRover;
        }

        void SetInitialReferences()
        {
            _gammaster = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
            _rocket = GameObject.Find("rocketprefab");
            _rv = _rocket.GetComponent<b_rocket_Vector>();
            _playermaster = _rocket.GetComponent<Player_Master>();
            _t = 0;
        }


        void Start()
        {

            fraction = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (_playermaster.isBeingPulled) maxdisd = 60;
            else
                maxdisd = 200;
            foccusRocketlerp();
            foccusRover();

        }

        void foccusRocketlerp()
        {
            if (_gammaster.isRocketMode)
            {
                if (_rocket != null)
                {
                    //    if(rv.ismoving) transform.position = Vector3.Lerp( new Vector3(rocket.transform.position.x, rocket.transform.position.y, rocket.transform.position.z- minDistFromShip) , new Vector3(rocket.transform.position.x, rocket.transform.position.y, rocket.transform.position.z - maxDistFRomShip), 10*Time.deltaTime);
                    //     else
                    //        transform.position = Vector3.Lerp(new Vector3(rocket.transform.position.x, rocket.transform.position.y, rocket.transform.position.z - maxDistFRomShip), new Vector3(rocket.transform.position.x, rocket.transform.position.y, rocket.transform.position.z - minDistFromShip), distanceFormshipFactor);


                    //if (rv.ismoving) transform.position = new Vector3(rocket.transform.position.x, rocket.transform.position.y, rocket.transform.position.z - maxDistFRomShip );
                    //else
                    //    transform.position = new Vector3(rocket.transform.position.x, rocket.transform.position.y, rocket.transform.position.z - minDistFromShip);
                    doslowup();
                }
            }
        }


        void doslowup()
        {


            if (_rv.ismoving)
            {
                cnt++;
                if (cnt > maxdisd) cnt = maxdisd;
                transform.position = new Vector3(_rocket.transform.position.x, _rocket.transform.position.y, _rocket.transform.position.z - cnt);
            }
            else
            {
                cnt--;
                if (cnt < mindist) cnt = mindist;
                transform.position = new Vector3(_rocket.transform.position.x, _rocket.transform.position.y, _rocket.transform.position.z - cnt);
            }

        }

        void foccusRocket1()
        {
            if (_gammaster.isRocketMode)
            {
                if (_rocket != null)
                {

                    if (_rv.rocketspeed != float.PositiveInfinity)
                        transform.position = new Vector3(_rocket.transform.position.x, _rocket.transform.position.y, -minDistFromShip - (Mathf.Abs(_rv.rocketspeed * distanceFormshipFactor)));
                    else
                        transform.position = new Vector3(_rocket.transform.position.x, _rocket.transform.position.y, transform.position.z + 0f);
                }
            }
        }


        void foccusRover()
        {
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

     
    
    }
}
