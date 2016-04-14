using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace nabspace
{
    public class GM_toggleTakeOffQuestion : MonoBehaviour
    {
        public GameObject GuestionTakeOFfUi;


        private GameManager_Master _gameManager;

        private Player_Master _playerMaster;
        void OnEnable()
        {
            SetInitialReferences();
            _gameManager.playerAskedtoTakeOff += ToggleQuestionUI;

        }

        void OnDisable()
        {
            _gameManager.playerAskedtoTakeOff -= ToggleQuestionUI;

        }
        void SetInitialReferences()
        {
            _gameManager = GetComponent<GameManager_Master>();
            _playerMaster = GameObject.Find("rocketprefab").GetComponent<Player_Master>();
        }

        void ToggleQuestionUI()
        {
            _gameManager.isAskedToTakeOff = true;
            GuestionTakeOFfUi.SetActive(!GuestionTakeOFfUi.activeSelf);
            

        }






        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {


            if (CrossPlatformInputManager.GetButtonUp("OnButtonYesTakeOff"))
            { 
                ToggleQuestionUI();
                _gameManager.GetComponent<GameManager_TogglePause>().DoPublicTogglePause();

                _playerMaster.CALLEventGarageRover();

                _gameManager.isRocketMode = true;
                _gameManager.isRoverMode = false;

               
                // _gameManager.isAskedToTakeOff = false;
                _gameManager.CAllChangeMode();


            }
            else
           if (CrossPlatformInputManager.GetButtonUp("OnButtonNoTakeOff"))
            {
                ToggleQuestionUI();
                _gameManager.GetComponent<GameManager_TogglePause>().DoPublicTogglePause();
                _gameManager.isRocketMode = false;
                _gameManager.isRoverMode = true;
                
            }


        }
    }
}