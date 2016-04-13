using UnityEngine;
using System.Collections;


namespace S3
{
    public class planet_alienMaker : MonoBehaviour
    {


        GameObject player;
        GameObject castlego;
        private Player_Master _playerMaster;

        string castlepath;


        void OnEnable()
        {
            SetInitialReferences();
            _playerMaster.EventCreateRover += popacastlehere;
        }

        void OnDisable()
        {
            _playerMaster.EventCreateRover -= popacastlehere;
        }

        void SetInitialReferences()
        {
            player = GameObject.Find("rocketprefab");         
            castlepath = "Castle/Castle1";
            _playerMaster = player.GetComponent<Player_Master>();
        }

        void Start()
        {
                   
        }

        // Update is called once per frame
        void Update()
        {
            
        }

      
        Vector3 dooppositline() {
            Vector3  diff = (transform.position - player.transform.position);
            Vector3  oppositPlayer = transform.position + (diff.normalized) * transform.localScale.y/2;
            return oppositPlayer;
           // Debug.DrawLine(transform.position, oppositPlayer, Color.red);
        }


        void popacastlehere() { 
            if (GetComponent<planetGravityScript>().playerLandedOnMe)
            {
                Vector3 diff1 = (transform.position - player.transform.position);
                Vector3 castleplace = dooppositline();
                Vector3 Zaxis =   Vector3.Cross(castleplace, Vector3.forward);

                // castlego = Instantiate(Resources.Load(castlepath), castleplace, Quaternion.LookRotation(diff1)) as GameObject;


                castlego = Instantiate(Resources.Load(castlepath)) as GameObject;
                castlego.transform.position = castleplace;
                castlego.transform.rotation = Quaternion.LookRotation(diff1, Vector3.up );


                //  castlego.transform.right = Vector3.forward;  //my red x going deep 



                //    castlego.transform.forward = diff1;

                //  castlego.transform.eulerAngles = new Vector3(diff1.x, diff1.y, 1);


                //  castlego.transform.up= diff1;
                //      castlego.transform.forward = diff1;

                // castlego = Instantiate(Resources.Load(castlepath), castleplace, Quaternion.LookRotation(diff1, Zaxis)) as GameObject;


                castlego.GetComponent<castleScript>().setMyplanetCenterAndRadius(this.transform.position, GetComponent<planetGravityScript>().getRadius() );
            }
        }


    }
}