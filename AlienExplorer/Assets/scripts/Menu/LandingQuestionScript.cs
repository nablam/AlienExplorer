using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


namespace nabspace {
    public class LandingQuestionScript : MonoBehaviour
    {


        GameManager_Master _gameManager;
        // Use this for initialization
        void Start()
        {
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();

        }

        // Update is called once per frame
        void Update()
        {

            if (CrossPlatformInputManager.GetButton("OnButtonYes"))
            {
                //_gameManager.CAllPlayerLanded();
            }
            else
           if (CrossPlatformInputManager.GetButton("OnButtonNo"))
            {
            }


        }
    }
}
