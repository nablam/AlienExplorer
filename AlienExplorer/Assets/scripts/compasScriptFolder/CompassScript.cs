using UnityEngine;
using System.Collections;
namespace nabspace
{
    public class CompassScript : MonoBehaviour
    {


        private GameManager_Master _gameManager;

        private Vector3 WHERETOLOOK=Vector3.zero;
        void Awake() { SetInitialReferences(); }
        void OnEnable() { _gameManager.inquireNearestPlanet += SetWhereToLook; }
        void Start() { }
        void OnDisable() { _gameManager.inquireNearestPlanet -= SetWhereToLook; }


        void SetInitialReferences()
        {
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
        }


        void pointtoearth() { transform.LookAt(Vector3.zero); }

        void SetWhereToLook(Vector3 thisplanet)
        {
            if (thisplanet != null)
                WHERETOLOOK= thisplanet;
        }

        void Update() {

            transform.LookAt(WHERETOLOOK);
        }
    }
}