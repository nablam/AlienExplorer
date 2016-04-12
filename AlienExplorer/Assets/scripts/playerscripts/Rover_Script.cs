using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace S3 {


    public class Rover_Script : MonoBehaviour
    {


        GameManager_Master _gameManager;

        public GameObject curplanet;

        public void setCurPlanet(GameObject go) { curplanet = go; }


        public float movespeed = 10f;
        private Vector3 moveDir;

        ConstantForce cf;

        void Start()
        {
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
            cf = GetComponent<ConstantForce>();
            isGrounded = false;

        }

        bool isGrounded;

        void DoJump()
        {
            //if (isGrounded)
            //{
            //    if (Input.GetButton("up"))
            //    {
            //        moveDirection.y = jumpSpeed;
            //    }
            //    else {
            //        moveDirection.y = 0.0;
            //    }
            //}
            //else {
            //    // Apply gravity
            //    moveDirection.y -= gravity * Time.deltaTime;
            //}
            //transform.translate(moveDirection);
        }

        void Update()
        {
            if (_gameManager.isRoverMode)
            {
                //AndroidControls();
               PCsontrols(); ;
            }



        }

        void AndroidControls() {


            triggerAskTotakeoff();


            if (curplanet != null)
            {
                Vector3 diff = curplanet.transform.position - transform.position;

                Debug.DrawLine(transform.position, transform.position + diff, Color.blue);


                Vector3 myup = transform.position - curplanet.transform.position;
                Debug.DrawLine(transform.position, transform.position + (myup.normalized * 2), Color.black);


            }
            
            if (CrossPlatformInputManager.GetButton("OnButtonRightRover"))
            {
                if (curplanet != null) { transform.RotateAround(curplanet.transform.position, curplanet.transform.forward, -Time.deltaTime * 10); }
            }



            if (CrossPlatformInputManager.GetButton("OnButtonLeftRover"))
            {
                if (curplanet != null) { transform.RotateAround(curplanet.transform.position, curplanet.transform.forward, Time.deltaTime * 10); }

            }

        }

        void PCsontrols() {


            triggerAskTotakeoff();


            if (curplanet != null)
            {
                Vector3 diff = curplanet.transform.position - transform.position;

                Debug.DrawLine(transform.position, transform.position + diff, Color.blue);


                Vector3 myup = transform.position - curplanet.transform.position;
                Debug.DrawLine(transform.position, transform.position + (myup.normalized * 2), Color.black);


            }




            if (Input.GetKey("up"))
            {

            }
            if (Input.GetKey("down"))
            {

            }

            if (Input.GetKey("right"))
            {
                if (curplanet != null) { transform.RotateAround(curplanet.transform.position, curplanet.transform.forward, -Time.deltaTime * 10); }
            }



            if (Input.GetKey("left"))
            {
                if (curplanet != null) { transform.RotateAround(curplanet.transform.position, curplanet.transform.forward, Time.deltaTime * 10); }

            }
        }

        void FixedUpdate()
        {
            //  GetComponent<Rigidbody>().MovePosition(transform.position + transform.TransformDirection(moveDir) * movespeed * Time.deltaTime);
        }




        float distancefromRocket() {
            Vector3 diff = transform.parent.transform.position - transform.position;
           return diff.magnitude;
        }

        void triggerAskTotakeoff() {

            if (distancefromRocket() < 5f && !_gameManager.isAskedToTakeOff) {
               
               _gameManager.CAllPlayerASkedToTakeOff();
                
            }
            else
           if (distancefromRocket() > 5f)
            {
                _gameManager.isAskedToTakeOff = false;

            }
            
        }

    }


}
