using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace S3 {
    public class Player_Health : MonoBehaviour
    {

        private GameManager_Master _gameManager;
        private Player_Master _playerMAster;
        public int playerHEalth;
        public Text healthText;


        void OnEnable()
        {
            SetInitialReferences();
            setUI();
            _playerMAster.EventPlayerHEalthDown += deductHealth;
            _playerMAster.EventPlayerHEalthUp+= increastHealth;

        }

        void OnDisable()
        {
            _playerMAster.EventPlayerHEalthDown -= deductHealth;
            _playerMAster.EventPlayerHEalthUp -= increastHealth;

        }

        void SetInitialReferences()
        {
            _gameManager =  GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
            _playerMAster = GetComponent<Player_Master>();
        }


        void Start() {
          // StartCoroutine(testHEalthDeduction());
        }
        IEnumerator testHEalthDeduction() {
            yield return new WaitForSeconds(4);
            deductHealth(100);
        }

        void deductHealth(int thismuch) {
            playerHEalth -= thismuch;
            if (playerHEalth <= 0) {
                playerHEalth = 0;
                _gameManager.CAllGameOverEvent();
            }
            setUI();


        }
        void increastHealth(int thismuch) {
            playerHEalth += thismuch;
            if (playerHEalth >= 100)
            {
                playerHEalth = 100;
                _gameManager.CAllGameOverEvent();
            }
            setUI();

        }
        void setUI() {
            if (healthText != null) {
                healthText.text = playerHEalth.ToString();
            }
        }
    }


}
