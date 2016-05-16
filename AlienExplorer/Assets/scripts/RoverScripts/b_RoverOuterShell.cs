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
         public bool IamGrounded;
        public bool IamInAjump;


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
            IamGrounded=false;
            IamInAjump=false;
    }

        public void SetCurPlanetOUTERSHELL(GameObject go) { curplanetOUTERSHELL = go; }
        void Update()
        {
            if (_gameManager.isRoverMode)
            {
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

        void DoJumpAndroid()
        {

            if (curplanetOUTERSHELL != null)
            {
                if (curplanetOUTERSHELL != null)
                {

                    if (IamGrounded && CrossPlatformInputManager.GetButtonUp("OnButtonJump") && !IamInAjump)
                    {
                        StartCoroutine("jump2");
                    }
                    else
                     if (!IamGrounded && !IamInAjump)
                    {
                        transform.Translate(Vector3.back * 5 * Time.deltaTime);
                        print("going down");
                    }
                    else
                        if (IamInAjump && !IamGrounded)
                    {
                        transform.Translate(Vector3.forward * 10 * Time.deltaTime);
                    }
                }
                
         
            }
        }

        void DoJumpPC()
        {

            if (curplanetOUTERSHELL != null)
            {

                if (IamGrounded && Input.GetKeyUp("up") && !IamInAjump)
                {
                    StartCoroutine("jump2");
                }
                else
                 if (!IamGrounded && !IamInAjump)
                {
                    transform.Translate(Vector3.back * 5 * Time.deltaTime);
                    print("going down");
                }
                else
                    if (IamInAjump && !IamGrounded) {
                    transform.Translate(Vector3.forward * 10 * Time.deltaTime);
                }
            }
        }


        IEnumerator jump2()
        {
            IamInAjump = true;
            IamGrounded = false;
            yield return new WaitForSeconds(0.5f);
            IamInAjump =  false;
        }


        float distancefromRocket()
        {
            Vector3 diff = _player.transform.position - transform.position;
            return diff.magnitude;
        }



        IEnumerator jump()
        {
            yield return new WaitForSeconds(0.1f);
            IamGrounded = false;
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
            if (other.gameObject.CompareTag("planetTAG"))
            {
                print(" grounded");
                IamGrounded = true;
                IamInAjump = false;
            }
        }
        //  void OnTriggerStay(Collider other) { }
        //void OnTriggerExit(Collider other) {        }
        //void OnCollisionEnter(Collision collider) { }
        //void OnCollisionExit(Collision collider) { }

    }

}