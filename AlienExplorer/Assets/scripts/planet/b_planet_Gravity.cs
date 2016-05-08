using UnityEngine;
using System.Collections;
namespace nabspace
{
    public class b_planet_Gravity : MonoBehaviour
    {
        public bool applyGravity;
        public bool playerLandedOnMe;

        private GameManager_Master _gameManager;
		private Player_Master _playermaster;
        private GameObject _player;
        private Vector3 _planetPosition;
        private Vector3 _playerPosition;
        private Vector3 _vectorOppositPlayer;
        private Vector3 _vectorGravityDirectionAndForce;
        private float _radius;
        private float _lastRecordedDist_speedTOPlanet;
        private float _time_atDist_speedTOPlanet;
        private float _time_atLastRecordedDist_speedTOPlanet;
        private float _speedtowardplanet_seedTOPlanet;

        void Awake() {
        SetInitialReferences();
        }

        void OnEnable(){}
        void Start(){}
        void OnDisable(){} 
		
        void SetInitialReferences()
        {
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
			_player = GameObject.Find("rocketprefab");		
            _playermaster = _player.GetComponent<Player_Master>();

            applyGravity = true;
            _radius = transform.FindChild("atmosphere").GetComponent<SphereCollider>().radius;
            print(_radius);

         _lastRecordedDist_speedTOPlanet=0f;
         _time_atDist_speedTOPlanet = 0f;
         _time_atLastRecordedDist_speedTOPlanet = 0f;
         _speedtowardplanet_seedTOPlanet = 0f;
    }

		void Update(){}
		
	    //void OnDrawGizmos() { Gizmos.color = Color.red; Gizmos.DrawLine(GameObject.Find("rocketprefab").transform.position, transform.position); }


        void DrawBlueLine(Vector3 here, Vector3 toHere)
        {
            Debug.DrawLine(here, toHere, Color.blue);
        }

        void ApplyGravityToObject(GameObject obj)
        {
            if (testForEnemyOrPlayer(obj))
            {
                float forceFactor = 1f;
                if (obj.transform.tag == "playerTAG") forceFactor = 15f;
                if (obj.transform.tag == "enemyshipTAG") forceFactor = 20f;
                if (obj.transform.tag == "roverTAG") forceFactor = 20f;

                if (_gameManager.isRocketMode)
                {
                    if (obj != null)
                    {
                        _planetPosition = transform.position;
                        _playerPosition = obj.transform.position;
                        DrawBlueLine(_planetPosition, _playerPosition);
                        _vectorOppositPlayer = (_planetPosition - _playerPosition);
                        _vectorGravityDirectionAndForce = _planetPosition + (_vectorOppositPlayer.normalized) * 100f;
                        if (applyGravity)
                        {
                            obj.transform.GetComponent<Rigidbody>().AddForce((_vectorOppositPlayer.normalized) * forceFactor);
                        }

                        Debug.DrawLine(_planetPosition, _vectorGravityDirectionAndForce, Color.red);
                    }
                }
            }

        }

        bool testForEnemyOrPlayer(GameObject obj) {
            if (obj.transform.tag == "playerTAG" || obj.transform.tag == "enemyshipTAG" || obj.transform.tag == "roverTAG") return true;
            else
                return false;
             
        }


        void playerosgettingclosser()
        {
            if (_player != null)
            {
                float distance = (transform.position - _player.transform.position).magnitude;
                _time_atDist_speedTOPlanet = Time.time;
                if (distance < _lastRecordedDist_speedTOPlanet)
                {
                    _speedtowardplanet_seedTOPlanet = (distance - _lastRecordedDist_speedTOPlanet) / (_time_atLastRecordedDist_speedTOPlanet - _time_atDist_speedTOPlanet);
                    //  print("speed toward planet " + speedtowardplanet);
                }
                _lastRecordedDist_speedTOPlanet = distance;
                _time_atLastRecordedDist_speedTOPlanet = _time_atDist_speedTOPlanet;
            }
        }

        float AngleOfShipRelativeToPlanet()
        {
            float angle = 0f;
            if (_player != null)
            {
                Vector3 playerposVector = (_player.transform.position - transform.position);
                angle = Vector3.Angle(playerposVector, _player.transform.forward);
            }
            return angle;
        }

        void OnTriggerStay(Collider other)
        {
            if (_player != null)
            {
                DrawBlueLine(other.transform.position, this.transform.position);
                if (applyGravity)
                {
                    ApplyGravityToObject(other.gameObject);
                }
                
            }
        }

 


        void OnCollisionEnter(Collision collider)
        {
            print("collision");
            if (collider.gameObject.tag == "playerTAG")
            {
                if (_speedtowardplanet_seedTOPlanet > 5f || AngleOfShipRelativeToPlanet() > 9f)
                {
                    StartCoroutine("waitforGameOver");
                   // _gameManager.CAllGameOverEvent();
                   Destroy(collider.gameObject);
                }
                else //landed properly
                {
                    playerLandedOnMe = true;
                    _gameManager.CAllPlayerASkedToLand();
                }
            }


            if (collider.gameObject.tag == "enemyshipTAG")
            {
                //  print("enemy collision");
                _gameManager.CAllEnemyDied(collider.gameObject);
                Instantiate(Resources.Load("Explosions/SkyEnemyExplosion1"), transform.position, transform.rotation);
                Destroy(collider.gameObject);
            }
        }



        void OnCollisionExit(Collision collider)
        {
            if (collider.gameObject.tag == "playerTAG")
            {
                playerLandedOnMe = false;
            }
        }

        IEnumerator waitforGameOver()
        {                        
            Instantiate(Resources.Load("Explosions/ShipExplosion"), _player.transform.position, transform.rotation);
            yield return new WaitForSeconds(2);
            _gameManager.CAllGameOverEvent();
        }

    }
}