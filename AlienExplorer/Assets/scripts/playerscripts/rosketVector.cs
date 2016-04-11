using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


namespace S3 {
    public class rosketVector : MonoBehaviour
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

        void Awake() { rocketspeed = 0f; }

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            timebackthere = 0f;
            shipPos_Last = transform.position;
            cf = GetComponent<ConstantForce>();

            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();

            _gameManager.isRocketMode = true;

    }


        void Update()
        {
            if (_gameManager.isRocketMode)
            {
                normalcontrols(10, 4);
                //androidcontrols(10, 4);
                rocketspeed = transform.InverseTransformDirection(rb.velocity).z;

                //  var locVel = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
                //  print("velo=" + transform.TransformDirection(locVel) );

                // print(cf.relativeForce);
                //  Debug.DrawLine(transform.position, transform.position+(transform.forward*4) );
                //  getmyspeed();
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
            // print(this.gameObject.GetComponent<Rigidbody>().velocity);
        }


    }
}


//    if (Input.GetKey("left"))  {}
//    if (Input.GetKey("right"))  {}

//if (Input.GetKey("up"))  {}
//if (Input.GetKey("down"))  {}


