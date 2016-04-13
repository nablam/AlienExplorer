using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace S3 {


    public class Rover_Script : MonoBehaviour
    {


        GameManager_Master _gameManager;
        public GameObject curplanet;
        public float movespeed = 20f;
        private Vector3 moveDir;
        ConstantForce cf;
        GameObject player;

        void Start()
        {
            player = GameObject.Find("rocketprefab");
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
            cf = GetComponent<ConstantForce>();
        }


        void Update()
        {
            if (_gameManager.isRoverMode)
            {
                AndroidControls();            
                DoJumpAndroid();
                // PCsontrols();
                // DoJumpPC();
            }
        }

        public void setCurPlanet(GameObject go) { curplanet = go; }

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
                if (curplanet != null) { transform.RotateAround(curplanet.transform.position, curplanet.transform.forward, -Time.deltaTime * movespeed); }
            }



            if (CrossPlatformInputManager.GetButton("OnButtonLeftRover"))
            {
                if (curplanet != null) { transform.RotateAround(curplanet.transform.position, curplanet.transform.forward, Time.deltaTime * movespeed); }

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
                if (curplanet != null) { transform.RotateAround(curplanet.transform.position, curplanet.transform.forward, -Time.deltaTime * movespeed); }
            }



            if (Input.GetKey("left"))
            {
                if (curplanet != null) { transform.RotateAround(curplanet.transform.position, curplanet.transform.forward, Time.deltaTime * movespeed); }

            }
        }


        float distancefromRocket() {
            Vector3 diff = player.transform.position - transform.position;
            return diff.magnitude;
        }



        public bool isgroundedIguess;

        void DoJumpPC()
        {

            if (curplanet != null) {

                if (isgroundedIguess && Input.GetKey("up"))
                {                                    
                        transform.Translate(Vector3.forward * 10 * Time.deltaTime);
                        /*Starts Ienumerator jump*/
                        StartCoroutine("jump");                                   
                }

               else
               if(!isgroundedIguess)
                {
                    transform.Translate(Vector3.back * 5 * Time.deltaTime);
                }
            }
        }




        void DoJumpAndroid()
        {

            if (curplanet != null)
            {

                if (isgroundedIguess && CrossPlatformInputManager.GetButton("OnButtonJump"))
                {
                    transform.Translate(Vector3.forward * 10 * Time.deltaTime);
                    /*Starts Ienumerator jump*/
                    StartCoroutine("jump");
                }

                else
               if (!isgroundedIguess)
                {
                    transform.Translate(Vector3.back * 5 * Time.deltaTime);
                }
            }
        }
        IEnumerator jump()
        {
            yield return new WaitForSeconds(1f);
            isgroundedIguess = false;
        }
        IEnumerator goup() {

            transform.position = (new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z));
            yield return new WaitForSeconds(1);
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

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "planetTAG")
            {
                print(" grounded");
                isgroundedIguess = true;
            }
        }


        //void OnCollisionEnter(Collision collider)
        //{
        //    print(" COLLISION");
        //    if (collider.gameObject.tag == "planetTAG")
        //    {
        //        print(" grounded");
        //        isgroundedIguess = true;
        //    }
        //}
    }


}
