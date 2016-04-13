using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace S3 {
    public class Player_Rover : MonoBehaviour
    {


        private GameManager_Master _gameManager;
        private Player_Master _playerMAster;
        int numberofRovers;
        int maxRovers;
        public Text roverText;


        void OnEnable()
        {
            maxRovers = 3;
            numberofRovers = maxRovers;
          
            SetInitialReferences();
            setUI();
            _playerMAster.EventPlayerGainedaRover += increaseRover;
            _playerMAster.EventPlayerLostaRover += deductRover;

        }

        void OnDisable()
        {
            _playerMAster.EventPlayerGainedaRover -= increaseRover;
            _playerMAster.EventPlayerLostaRover -= deductRover;

        }

        void SetInitialReferences()
        {
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
            _playerMAster = GetComponent<Player_Master>();
        }


        void Start()
        {
           
        }
 

        void deductRover( )
        {
            numberofRovers--;
            if (numberofRovers <= 0)
            {
                numberofRovers = 0;
                
            }
            setUI();


        }
        void increaseRover()
        {
            numberofRovers++;
            if (numberofRovers >= maxRovers)
            {
                numberofRovers = maxRovers;
                
            }
            setUI();

        }
        void setUI()
        {
            if (roverText != null)
            {
                roverText.text = "rovers="+ numberofRovers.ToString();
            }
        }
    }
}
