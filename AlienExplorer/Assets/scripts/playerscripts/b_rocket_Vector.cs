using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace nabspace
{
    public class b_rocket_Vector : MonoBehaviour
    {

        public float rocketspeed = 0f;
        public bool ismoving = false;
        public bool turningRIGHT = false;
        public bool turningLEFT = false;
        public bool goingForward = false;
        public float valSide = 0f;
        public Text speedText;
        public GameObject planetITouched;

        private GameManager_Master _gameManager;
        private Player_Master _playerMaster;
        private ConstantForce _cf;
        private Rigidbody _rb;
        private GameObject _spawnPointForRover;
        private GameObject _rover;
        

        private float _moveCtrl;
        private float _moveSpeed = 60f;
        private Vector3 _shipPos_Last;
        private float _timeBackThere;
        private float _timeNow;
        private float _shipSpeed = 18f;
        private float _shipRotationSpeed = 6f;


        void Awake() { SetInitialReferences(); }
        void OnEnable()
        {
            _playerMaster.EventCreateRover += popARoverinTheWorld;
            _playerMaster.EventGarageRover += garageARoverOutofTheWorld;
        }
        void Start() { }
        void OnDisable()
        {
            _playerMaster.EventCreateRover -= popARoverinTheWorld;
            _playerMaster.EventGarageRover -= garageARoverOutofTheWorld;
        }

        void SetInitialReferences()
        {
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
            _playerMaster = GetComponent<Player_Master>();
            _cf = GetComponent<ConstantForce>();
            _rb = GetComponent<Rigidbody>();
            _spawnPointForRover = transform.FindChild("spawnPointForRover").gameObject;
            _gameManager.isRocketMode = true;
            //_shipSpeed = 0f;
            _gameManager.isAskedToTakeOff = true;
        }

        void Update()
        {
            if (_gameManager.isRocketMode)
            {
                Debug.DrawLine(transform.position, Vector3.zero, Color.cyan);
                updateVales();
                if (_gameManager.useAndroidControls) androidcontrols(_shipSpeed, _shipRotationSpeed);
                else
                    normalcontrols(_shipSpeed, _shipRotationSpeed);
                rocketspeed = transform.InverseTransformDirection(_rb.velocity).z;
            }
            int myspeed = (int)rocketspeed;
                speedText.text = "speed=" + myspeed;
        }

 


        void popARoverinTheWorld()
        {

            transform.parent = planetITouched.transform;
            _rover = Instantiate(Resources.Load("Rover_Resource/roverOuterInner"), _spawnPointForRover.transform.position, _spawnPointForRover.transform.rotation) as GameObject;
            _rover.GetComponent<b_RoverOuterShell>().SetCurPlanetOUTERSHELL(planetITouched);
            _rover.transform.parent = planetITouched.transform;
        }

        void garageARoverOutofTheWorld()
        {
            transform.parent = null;
           Destroy(_rover);
        }

        void updateVales()
        {
            if (turningLEFT) valSide = 5f;
            else
            if (turningRIGHT) valSide = -5f;
            else
                valSide = 0f;
        }

        void getmyspeed()
        {
            float distance = (transform.position - _shipPos_Last).magnitude;
            _timeNow = Time.time;
            rocketspeed = (distance) / (_timeNow - _timeBackThere);
            _shipPos_Last = transform.position;
            _timeBackThere = _timeNow;
        }

        void normalcontrols(float forwardValue, float rotationValue)
        {
            _cf.relativeForce = new Vector3(0f, 0f, 0f);
            ismoving = false;
            turningRIGHT = false;
            turningLEFT = false;

            if (Input.GetKey("up"))
            {
                ismoving = true;
                _cf.relativeForce = new Vector3(0f, 0f, forwardValue);
            }


            if (Input.GetKey("down"))
            {
                _cf.relativeForce = new Vector3(0f, 0f, -forwardValue);
            }

            if (Input.GetKey("left"))
            {

                turningLEFT = true;
                this.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
                this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
                _cf.relativeTorque = new Vector3(0f, -rotationValue, 0f);
            }
            else
            if (Input.GetKeyUp("left"))
            {
                this.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
            }


            if (Input.GetKey("right"))
            {
                turningRIGHT = true;
                this.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
                this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
                //this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
                _cf.relativeTorque = new Vector3(0f, rotationValue, 0f);
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
            _cf.relativeForce = new Vector3(0f, 0f, 0f);

            ismoving = false;
            turningRIGHT = false;
            turningLEFT = false;
            if (CrossPlatformInputManager.GetButton("OnButtonBoost"))
            {
                ismoving = true;
                _cf.relativeForce = new Vector3(0f, 0f, forwardValue);
            }


            if (CrossPlatformInputManager.GetButton("OnButtonShoot"))
            {
                Debug.Log("pew pew");
            }


            if (CrossPlatformInputManager.GetButton("OnButtonLeft"))
            {
                turningLEFT = true;
                this.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
                this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
                _cf.relativeTorque = new Vector3(0f, -rotationValue, 0f);
            }
            else
           if (CrossPlatformInputManager.GetButtonUp("OnButtonLeft"))
            {
                this.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
            }


            if (CrossPlatformInputManager.GetButton("OnButtonRight"))
            {
                turningRIGHT = true;
                this.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
                this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
                _cf.relativeTorque = new Vector3(0f, rotationValue, 0f);
            }
            else
            if (CrossPlatformInputManager.GetButtonUp("OnButtonRight"))
            {
                this.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
            }

            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }


        void OnTriggerStay(Collider other) { }
        void OnTriggerEnter(Collider other)
        {
            GetComponent<Player_Master>().isBeingPulled = true;//works
        }
        void OnTriggerExit(Collider other)
        {
            GetComponent<Player_Master>().isBeingPulled = false;//works
        }
        void OnCollisionEnter(Collision collider)
        {  
            if (collider.gameObject.CompareTag("planetTAG"))
            {
                
                this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                planetITouched = collider.gameObject;
                }

                // print(this.gameObject.GetComponent<Rigidbody>().velocity);
            }
        
        void OnCollisionExit(Collision collider) {  }


    }
}
