using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace nabspace
{
    public class b_RoverOuterShell : MonoBehaviour
    {

        private GameManager_Master _gameManager;
        private Player_Master _playermaster;
        private GameObject _player;

        public GameObject curplanetOUTERSHELL;
        public float movespeed = 20f;
        public bool isgroundedIguess;
        public bool goingright;

        private Vector3 _moveDir;
        private ConstantForce _cf;


        private Transform _innershell;




        void Awake() { SetInitialReferences(); }
        void OnEnable() { }
        void Start() { }
        void OnDisable() { }

        void SetInitialReferences()
        {
            _player = GameObject.Find("rocketprefab");
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
            _cf = GetComponent<ConstantForce>();
            goingright = true;
            _innershell = transform.GetChild(0);                               
        }

        public void SetCurPlanetOUTERSHELL(GameObject go) { curplanetOUTERSHELL = go; }
        void Update()
        {
            if (_gameManager.isRoverMode)
            {
                dontdrwone();
                DoAndroidControls(_gameManager.useAndroidControls);
            }

            Debug.DrawLine(transform.position, curplanetOUTERSHELL.transform.position , Color.red);
        }

        void DoAndroidControls(bool android)
        {
            triggerAskTotakeoff();
            if (curplanetOUTERSHELL != null)
            {
                Vector3 diff = curplanetOUTERSHELL.transform.position - transform.position;
               // Debug.DrawLine(transform.position, transform.position + diff, Color.yellow);
                Vector3 myup = transform.position - curplanetOUTERSHELL.transform.position;
              //  Debug.DrawLine(transform.position, transform.position + (myup.normalized * 2), Color.black);
            }

            if (android)
            {

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
                if (curplanetOUTERSHELL != null) {
                    transform.RotateAround(curplanetOUTERSHELL.transform.position, curplanetOUTERSHELL.transform.forward, -Time.deltaTime * movespeed);
                }
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
                if (curplanetOUTERSHELL != null) { transform.RotateAround(curplanetOUTERSHELL.transform.position, curplanetOUTERSHELL.transform.forward,-Time.deltaTime * movespeed); }
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

                //if (isgroundedIguess && Input.GetKey("up"))
                //{
                //    transform.Translate(Vector3.forward * 10 * Time.deltaTime);
                //    /*Starts Ienumerator jump*/
                //    StartCoroutine("jump");
                //}

               // else
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

                //if (isgroundedIguess && CrossPlatformInputManager.GetButton("OnButtonJump"))
                //{
                //    transform.Translate(Vector3.forward * 10 * Time.deltaTime);
                //    StartCoroutine("jump");
                //}

                //else
               if (!isgroundedIguess)
                {
                    transform.Translate(Vector3.back * 5 * Time.deltaTime);
                }
            }
        }
        float distancefromRocket()
        {
            Vector3 diff = _player.transform.position - transform.position;
            return diff.magnitude;
        }

        void dontdrwone() {

            Debug.DrawLine(transform.position, curplanetOUTERSHELL.transform.position, Color.red);
            float gooddist = curplanetOUTERSHELL.GetComponent<b_planet_Gravity>().getRadius();
            float mydist = (transform.position - curplanetOUTERSHELL.transform.position).magnitude;
            Debug.Log(string.Format(" good= {0} my={1}", gooddist, mydist));

        }

        IEnumerator jump()
        {
            yield return new WaitForSeconds(0.1f);
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



        void OnTriggerStay(Collider other) { }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("planetTAG"))
            {
                print(" grounded");
                isgroundedIguess = true;
            }
        }
        void OnTriggerExit(Collider other) { }
        void OnCollisionEnter(Collision collider) { }
        void OnCollisionExit(Collision collider) { }

    }

}