using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace nabspace
{
    public class b_RoverInnerShell : MonoBehaviour
    {

        string pathMissile1 = "weapons/missile1_rover";
        public GameObject gunpoint;

        GameManager_Master _gameManager;
        void Start()
        {
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();

        }

        // Update is called once per frame
        void Update()
        {
            if (_gameManager.isRoverMode)
            {
                shootstyleAndroid(_gameManager.useAndroidControls);
                facetherightway();
            }

        }



        void PCshoot()
        {
            if (Input.GetKeyUp("down"))

            {
                print("PEW PEW ");
                GameObject go = Instantiate(Resources.Load(pathMissile1), gunpoint.transform.position, gunpoint.transform.rotation) as GameObject;
                go.GetComponent<missile1_rover>().setPlanetCenter(transform.parent.GetComponent<b_RoverOuterShell>().curplanetOUTERSHELL.transform.position);
            }

        }


        void facetherightway()
        {
            if (transform.parent.GetComponent<b_RoverOuterShell>().goingright)
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            else
                transform.localEulerAngles = new Vector3(0, 0, 180);
        }

        void androidshoot()
        {
            if (CrossPlatformInputManager.GetButtonUp("OnButtonShootRover"))

            {
                print("PEW PEW ");
                GameObject go = Instantiate(Resources.Load(pathMissile1), gunpoint.transform.position, gunpoint.transform.rotation) as GameObject;
                go.GetComponent<missile1_rover>().setPlanetCenter(transform.parent.GetComponent<b_RoverOuterShell>().curplanetOUTERSHELL.transform.position);
            }

        }

        void shootstyleAndroid(bool b)
        {
            if (b) androidshoot();
            else
                PCshoot();
        }
    }
}
