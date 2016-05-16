using UnityEngine;
using System.Collections;

namespace nabspace
{
    public class b_Planet_Alien_Maker : MonoBehaviour
    {
        private GameObject _player;
        private GameObject _castleGO;
        private Player_Master _playerMaster;
        private b_planet_Gravity _b_planetGravScript;
        private string _castlePath;

        void Awake()
        {
            SetInitialReferences();
        }

        void OnEnable()
        {                     
            _playerMaster.EventCreateRover += popacastlehere;
        }

        void OnDisable()
        {
            _playerMaster.EventCreateRover -= popacastlehere;
        }

        void SetInitialReferences()
        {
            _player = GameObject.Find("rocketprefab");
            _castlePath = "Castle/Castle1";
            _playerMaster = _player.GetComponent<Player_Master>();
            _b_planetGravScript = GetComponent<b_planet_Gravity>();
        }

   

        Vector3 DoOppositLine()
        {
            Vector3 diff = (transform.position - _player.transform.position);
            Vector3 oppositPlayer = transform.position + (diff.normalized) *  GetComponent<b_planet_Gravity>().getRadius();
            return oppositPlayer;
        }


        void popacastlehere()
        {
            if (_b_planetGravScript.playerLandedOnMe)
            {
                if (_b_planetGravScript.castleNotYetGenerated)
                {
                    Vector3 diff1 = (transform.position - _player.transform.position);
                    Vector3 castleplace = DoOppositLine();
                    Vector3 Zaxis = Vector3.Cross(castleplace, Vector3.forward);

                    // castlego = Instantiate(Resources.Load(castlepath), castleplace, Quaternion.LookRotation(diff1)) as GameObject;


                    _castleGO = Instantiate(Resources.Load(_castlePath)) as GameObject;
                    _castleGO.transform.position = castleplace;
                    _castleGO.transform.rotation = Quaternion.LookRotation(diff1, Vector3.up);

                    _castleGO.transform.parent = this.transform;


                    //print("build cstle at"+GetComponent<b_planet_Gravity>().getRadius());
                     _castleGO.GetComponent<castleScript>().setMyplanetCenterAndRadius(this.transform.position, GetComponent<b_planet_Gravity>().getRadius());
                   
                    _b_planetGravScript.castleNotYetGenerated = false;
                }


            }
        }
    }
}