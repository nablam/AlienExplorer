using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityStandardAssets.CrossPlatformInput;

namespace nabspace {
    public class b_planetList : MonoBehaviour
    {

        public List<Vector3> listOfplanetPositions;
        public List<Vector3> listOfFuelPositions;
        public Vector3 nearestPLANETDistToplayer;
        public Vector3 nearestFUELdistToplayer;
        private GameManager_Master _gameManager;
        private GameObject _playership;

        void getSmallestPlanetDist() {
            if(listOfplanetPositions.Count>0)
            nearestPLANETDistToplayer = listOfplanetPositions.OrderBy(p => (p - _playership.transform.position).magnitude).First<Vector3>();
        }

        void getSmallestFuelDist()
        {
            if (listOfFuelPositions.Count > 0)
                nearestFUELdistToplayer = listOfFuelPositions.OrderBy(p => (p - _playership.transform.position).magnitude).First<Vector3>();
        }

        void Awake()
        {
            SetInitialReferences();
        }

        void SetInitialReferences()
        {
            _playership = GameObject.Find("rocketprefab");
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
            listOfplanetPositions = new List<Vector3>();
            listOfFuelPositions = new List<Vector3>();
        }



       void Update()
        {
            if (CrossPlatformInputManager.GetButtonUp("OnButtonUINearestPlanet"))
            {
                getSmallestPlanetDist();
                _gameManager.CAllNearestPlanetIsBEingInquired(nearestPLANETDistToplayer);
            }

            if (CrossPlatformInputManager.GetButton("OnButtonUIPlanetEarth"))
            {
                _gameManager.CAllNearestPlanetIsBEingInquired(Vector3.zero);
            }

            if (CrossPlatformInputManager.GetButton("OnButtonUINearestFuel"))
            {
                getSmallestFuelDist();
                _gameManager.CAllNearestPlanetIsBEingInquired(nearestFUELdistToplayer);
            }
        }
    }
}
