using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace nabspace {
    public class GM_toggleLandingQuestion : MonoBehaviour
    {
        public GameObject GuestionUi;

        private GameManager_Master _gameManager;
        private Player_Master _playerMaster;

        void OnEnable()
        {
            SetInitialReferences();
            _gameManager.playerAskedtoLand += ToggleQuestionUI;


        }

        void OnDisable()
        {
            _gameManager.playerAskedtoLand -= ToggleQuestionUI;

        }
        void SetInitialReferences()
        {
            _gameManager = GetComponent<GameManager_Master>();

            _playerMaster =  GameObject.Find("rocketprefab").GetComponent<Player_Master>();


        }

        void ToggleQuestionUI() {
            GuestionUi.SetActive(!GuestionUi.activeSelf);
            _gameManager.isAskedToLandl = !_gameManager.isAskedToLandl;

        }



        void Update()
        {

            if (CrossPlatformInputManager.GetButtonUp("OnButtonYes"))
            {
                _playerMaster.CALLEventCreateRover();
                //GameObject.Find("rocketprefab").GetComponent<BoxCollider>().enabled = false;
                ToggleQuestionUI();
                _gameManager.GetComponent<GameManager_TogglePause>().DoPublicTogglePause();
                //Load Rover
              
                _gameManager.isRocketMode = false;
                _gameManager.isRoverMode = true;

                _gameManager.CAllChangeMode();
               

            }
            else
           if (CrossPlatformInputManager.GetButtonUp("OnButtonNo"))
            {
               ToggleQuestionUI();
                _gameManager.GetComponent<GameManager_TogglePause>().DoPublicTogglePause();
                _gameManager.isRocketMode = true;
                _gameManager.isRoverMode = false;
               
            }


        }

    }
}
