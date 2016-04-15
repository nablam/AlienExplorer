using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace nabspace {
    public class playerShoot : MonoBehaviour
    {

        private GameManager_Master _gameManager;

        public Transform cannontrans;
        void Start()
        {
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
        }

      
        void Update()
        {
            if (_gameManager.isRocketMode) {
                if (_gameManager.useAndroidControls) { AndroidShoot(); }
                else
                    pcShoot();
            }

        }

        void AndroidShoot() {
            if ( CrossPlatformInputManager.GetButtonUp("OnButtonShoot") ) {
                Instantiate(Resources.Load("weapons/rocket_missile_prefab"), cannontrans.position, cannontrans.rotation); 
            }

        }
        void pcShoot() {
            if (Input.GetKeyUp("space")) { Instantiate(Resources.Load("weapons/rocket_missile_prefab"), cannontrans.position, cannontrans.rotation); }
        }
    }
}
