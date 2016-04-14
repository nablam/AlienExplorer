using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


namespace nabspace {


    public class roverShoot : MonoBehaviour
    {



        string pathMissile1 = "weapons/missile1_rover";

        public GameObject gunpoint;

        void PCshoot()
        {
            if (Input.GetKeyUp("down"))

            {
                print("PEW PEW ");
                GameObject go = Instantiate(Resources.Load(pathMissile1), gunpoint.transform.position, gunpoint.transform.rotation) as GameObject;
                go.GetComponent<missile1_rover>().setPlanetCenter(rs.curplanet.transform.position);
            }

        }

        void androidshoot()
        {
            if (CrossPlatformInputManager.GetButtonUp("OnButtonShootRover"))

            {
                print("PEW PEW ");
                GameObject go = Instantiate(Resources.Load(pathMissile1), gunpoint.transform.position, gunpoint.transform.rotation) as GameObject;
                 go.GetComponent<missile1_rover>().setPlanetCenter(rs.curplanet.transform.position);
            }

        }

        Rover_Script rs;

        void Start()
        {
            rs = GetComponent<Rover_Script>();
        }

        // Update is called once per frame
        void Update()
        {
            PCshoot();
            // androidshoot();
        }
    }
}