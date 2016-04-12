using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace S3 {
    public class GM_toggleLandingQuestion : MonoBehaviour
    {
        public GameObject GuestionUi;

        private GameManager_Master _gameManager;
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
        }

        void ToggleQuestionUI() {
            GuestionUi.SetActive(!GuestionUi.activeSelf);
            _gameManager.isAskedToLandl = !_gameManager.isAskedToLandl;

        }



        void Update()
        {

            if (CrossPlatformInputManager.GetButtonUp("OnButtonYes"))
            {
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
