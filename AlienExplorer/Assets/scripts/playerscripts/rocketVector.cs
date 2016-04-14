using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


namespace nabspace {
    public class rocketVector : MonoBehaviour
    {

        ConstantForce cf;
        float moveCtrl;
        float moveSpeed = 60f;
        Vector3 shipPos_Last;
        public float rocketspeed = 0f;
        float timebackthere;
        float timenow;
        Rigidbody rb;
        private GameManager_Master _gameManager;
        private Player_Master _playerMaster;

        private GameObject _rover;
        private GameObject spawnPointForRover;

        private GameObject planetITouched;



        //void Awake() { }

        //void Start()
        //{

        //}

        void OnEnable()
        {

            spawnPointForRover = transform.GetChild(0).gameObject as GameObject;
            rocketspeed = 0f;

            rb = GetComponent<Rigidbody>();
            timebackthere = 0f;
            shipPos_Last = transform.position;
            cf = GetComponent<ConstantForce>();

            _playerMaster = GetComponent<Player_Master>();
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
            _gameManager.isRocketMode = true;

            _playerMaster.EventCreateRover += popARoverinTheWorld;
            _playerMaster.EventGarageRover += garageARoverOutofTheWorld;
            _gameManager.isAskedToTakeOff = true;
        }
        void OnDisable()
        {
            _playerMaster.EventCreateRover -= popARoverinTheWorld;
            _playerMaster.EventGarageRover -= garageARoverOutofTheWorld;
        }

        void popARoverinTheWorld() {
          //  print("pop a rover");
            _rover= Instantiate(Resources.Load("Rover_Resource/rover1"), spawnPointForRover.transform.position, spawnPointForRover.transform.rotation) as GameObject;
            _rover.GetComponent<RoverOuterShellScript>().setCurPlanetOUTERSHELL(planetITouched);
        }

        void garageARoverOutofTheWorld()
        {
            Destroy(_rover);  
        }




        void Update()
        {
            if (_gameManager.isRocketMode)
            {
                if(_gameManager.useAndroidControls) androidcontrols(10, 4);
                else
                normalcontrols(10, 4);
           
                rocketspeed = transform.InverseTransformDirection(rb.velocity).z;

            }
        }

        void getmyspeed()
        {

            float distance = (transform.position - shipPos_Last).magnitude;
            timenow = Time.time;

            rocketspeed = (distance) / (timenow - timebackthere);
            //  print("speed toward planet " + speedtowardplanet);

            shipPos_Last = transform.position;
            timebackthere = timenow;
        }

        void normalcontrols(float forwardValue, float rotationValue)
        {
            cf.relativeForce = new Vector3(0f, 0f, 0f);

            if (Input.GetKey("up"))
            {
                cf.relativeForce = new Vector3(0f, 0f, forwardValue);
            }


            if (Input.GetKey("down"))
            {
                cf.relativeForce = new Vector3(0f, 0f, -forwardValue);
            }

            if (Input.GetKey("left"))
            {
                this.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
                cf.relativeTorque = new Vector3(0f, -rotationValue, 0f);
            }
            else
            if (Input.GetKeyUp("left"))
            {
                this.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
            }


            if (Input.GetKey("right"))
            {
                this.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
                cf.relativeTorque = new Vector3(0f, rotationValue, 0f);
            }
            else
            if (Input.GetKeyUp("right"))
            {
                this.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
            }

            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }

        void androidcontrols(float forwardValue, float rotationValue)
        {
            cf.relativeForce = new Vector3(0f, 0f, 0f);

            if (CrossPlatformInputManager.GetButton("OnButtonBoost"))
            {
                cf.relativeForce = new Vector3(0f, 0f, forwardValue);
            }


            if (CrossPlatformInputManager.GetButton("OnButtonShoot"))
            {
                Debug.Log("pew pew");
            }


            if (CrossPlatformInputManager.GetButton("OnButtonLeft"))
            {
                this.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
                cf.relativeTorque = new Vector3(0f, -rotationValue, 0f);
            }
            else
           if (CrossPlatformInputManager.GetButtonUp("OnButtonLeft"))
            {
                this.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
            }


            if (CrossPlatformInputManager.GetButton("OnButtonRight"))
            {
                this.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
                cf.relativeTorque = new Vector3(0f, rotationValue, 0f);
            }
            else
            if (CrossPlatformInputManager.GetButtonUp("OnButtonRight"))
            {
                this.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
            }

            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }


        void OnCollisionEnter(Collision collider)
        {


            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            planetITouched = collider.gameObject;
            // print(this.gameObject.GetComponent<Rigidbody>().velocity);
        }


    }
}

