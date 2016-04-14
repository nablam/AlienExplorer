using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace nabspace
{
    public class RoverOuterShellScript : MonoBehaviour
    {
        public GameObject curplanetOUTERSHELL;
        public float movespeed = 20f;
        public bool isgroundedIguess;

        GameManager_Master _gameManager;      
        private Vector3 moveDir;
        ConstantForce cf;
        GameObject player;

        Transform innershell;

         public bool goingright;


        void Start()
        {
            player = GameObject.Find("rocketprefab");
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
            cf = GetComponent<ConstantForce>();
             goingright = true;
            innershell = transform.GetChild(0);
        }

        public void setCurPlanetOUTERSHELL(GameObject go) { curplanetOUTERSHELL = go; }

        //void facetherightway()
        //{
        //    if (!goingright)
        //    {
        //        innershell.eulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 90);
        //    }
        //    else
        //        innershell.eulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 270);
        //}

        void Update()
        {
            if (_gameManager.isRoverMode)
            {
                DoAndroidControls(_gameManager.useAndroidControls);
 
             
            }
        }



        void DoAndroidControls(bool android)
        {
            triggerAskTotakeoff();
            if (curplanetOUTERSHELL != null)
            {
                Vector3 diff = curplanetOUTERSHELL.transform.position - transform.position;
                Debug.DrawLine(transform.position, transform.position + diff, Color.blue);
                Vector3 myup = transform.position - curplanetOUTERSHELL.transform.position;
                Debug.DrawLine(transform.position, transform.position + (myup.normalized * 2), Color.black);
            }

            if (android) {

                RawAndroidControls();
                DoJumpAndroid();
            }
            else
            {
                RawPCControls();
                DoJumpPC();
            }
                
        }


        void RawAndroidControls()
        {
            if (CrossPlatformInputManager.GetButton("OnButtonRightRover"))
            {
                goingright = true;
                if (curplanetOUTERSHELL != null) { transform.RotateAround(curplanetOUTERSHELL.transform.position, curplanetOUTERSHELL.transform.forward, -Time.deltaTime * movespeed); }
            }

            if (CrossPlatformInputManager.GetButton("OnButtonLeftRover"))
            {
                goingright = false;
                if (curplanetOUTERSHELL != null) { transform.RotateAround(curplanetOUTERSHELL.transform.position, curplanetOUTERSHELL.transform.forward, Time.deltaTime * movespeed); }

            }
        }
        void RawPCControls()
        {
            if (Input.GetKey("right"))
            {
                goingright = true;
                if (curplanetOUTERSHELL != null) { transform.RotateAround(curplanetOUTERSHELL.transform.position, curplanetOUTERSHELL.transform.forward, -Time.deltaTime * movespeed); }
            }
            if (Input.GetKey("left"))
            {
                goingright = false;
                if (curplanetOUTERSHELL != null) { transform.RotateAround(curplanetOUTERSHELL.transform.position, curplanetOUTERSHELL.transform.forward, Time.deltaTime * movespeed); }
            }
        }




        void DoJumpPC()
        {

            if (curplanetOUTERSHELL != null)
            {

                if (isgroundedIguess && Input.GetKey("up"))
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
        void DoJumpAndroid()
        {

            if (curplanetOUTERSHELL != null)
            {

                if (isgroundedIguess && CrossPlatformInputManager.GetButton("OnButtonJump"))
                {
                    transform.Translate(Vector3.forward * 10 * Time.deltaTime);
                    StartCoroutine("jump");
                }

                else
               if (!isgroundedIguess)
                {
                    transform.Translate(Vector3.back * 5 * Time.deltaTime);
                }
            }
        }

        float distancefromRocket()
        {
            Vector3 diff = player.transform.position - transform.position;
            return diff.magnitude;
        }

        IEnumerator jump()
        {
            yield return new WaitForSeconds(1f);
            isgroundedIguess = false;
        }


        void triggerAskTotakeoff()
        {
            if (distancefromRocket() < 5f && !_gameManager.isAskedToTakeOff)
            {
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
    }
}
