using UnityEngine;
using System.Collections;
namespace nabspace {
    public class b_EnemnyFlyAimFollow : MonoBehaviour
    {

        private GameManager_Master _gameManager;
        private Player_Master _playermaster;
        private GameObject _player;
        private ConstantForce _cf;
        private Vector3 _initialPosition;
        private Vector3 _PlayerCurPos;
        private float _minDistanceTotriggerAttack = 200f;
        private float _enemyShipForwardSpeed = 12f;
        private float _enemyShipRotationSpeed = 10f;

        public bool AGRO;

        void Awake() { SetInitialReferences(); }
        void OnEnable() { }
        void Start() { }
        void OnDisable() { }

        void SetInitialReferences()
        {
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
            _player = GameObject.Find("rocketprefab");
            _playermaster = _player.GetComponent<Player_Master>();
            _cf = GetComponent<ConstantForce>();
            AGRO = false;
            _initialPosition = transform.position;
        }

        void Update() { DoFullAttack(); }

        void StartGoHome()
        {
            _PlayerCurPos = _player.transform.position;
            faceThisPOsition(_initialPosition);
            moveForward();
        }

        void StartFindPlayerMoveToPlayer()
        {
            _PlayerCurPos = _player.transform.position;
            faceThisPOsition(_PlayerCurPos);
            moveForward();
        }

        float distToPlayer()
        {
            Vector3 diff = _PlayerCurPos - transform.position;
            return diff.magnitude;
        }


        void faceThisPOsition(Vector3 here)
        {

            if(here - transform.position != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(here - transform.position, Vector3.back), _enemyShipRotationSpeed * Time.deltaTime);
        }

        void moveForward()
        {
            _cf.relativeForce = new Vector3(0f, 0f, _enemyShipForwardSpeed);
        }


        void DoFullAttack() {
            if (!_gameManager.isGameOver)
            {
                if (_player != null)
                {
                    if (distToPlayer() < _minDistanceTotriggerAttack && _gameManager.isRocketMode)
                    {
                        StartFindPlayerMoveToPlayer();
                        AGRO = true;
                    }
                    else
                    {
                        AGRO = false;
                        StartGoHome();
                    }
                }           
            }
        }

        void OnTriggerStay(Collider other) { }
        void OnTriggerExit(Collider other) { }
        void OnCollisionEnter(Collision collider) { }
        void OnTriggerEnter(Collider other) { }
    }
}
