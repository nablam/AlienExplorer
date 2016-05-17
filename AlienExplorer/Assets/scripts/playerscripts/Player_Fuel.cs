using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace nabspace
{
    public class Player_Fuel : MonoBehaviour
    {
        private GameManager_Master _gameManager;
        private Player_Master _playerMAster;
        public int playerFuel;
        public Text fuelText;


        void OnEnable()
        {
            SetInitialReferences();
            setUI();
            _playerMAster.EventPlayerFuelDown += deductFuel;
            _playerMAster.EventPlayerFuelhUp += increastFuel;

        }

        void OnDisable()
        {
            _playerMAster.EventPlayerHealthDown -= deductFuel;
            _playerMAster.EventPlayerHealthUp -= increastFuel;

        }

        void SetInitialReferences()
        {
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
            _playerMAster = GetComponent<Player_Master>();
        }


        void Start()
        {
            // StartCoroutine(testHEalthDeduction());
        }
    

        void deductFuel(int thismuch)
        {
            playerFuel -= thismuch;
            if (playerFuel <= 0)
            {
                playerFuel = 0;
                _gameManager.CAllGameOverEvent();
            }
            setUI();


        }
        void increastFuel(int thismuch)
        {
            playerFuel += thismuch;
            if (playerFuel >= 100)
            {
                playerFuel = 100;

            }
            setUI();

        }
        void setUI()
        {
            if (fuelText != null)
            {
                fuelText.text = "Fuel= " + playerFuel.ToString();
            }
        }

    }
}