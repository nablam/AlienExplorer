using UnityEngine;
using System.Collections;


namespace S3 {
    public class planetGravityScript : MonoBehaviour
    {

        public bool applyGravity;

        private Color color = Color.green;

        GameObject player;
        Vector3 playerpos;
        Vector3 mypos;
        Vector3 oppositplayer;
        Vector3 unitOposit;
        Vector3 GravitationalpullDirectionAndForce;
        float gravforce;

        Vector3 oppositPlayerNormalizedFROM00;
        float radius;

        float lastDist_speedTOPlanet;
        float time_atDist_speedTOPlanet;
        float time_atLASTDist_speedTOPlanet;
        float speedtowardplanet_seedTOPlanet;
        Vector3 diff;

        GameManager_Master _gameManager;

        GameObject roverref;
        Rover_Script RScript;
        
        void OnDrawGizmos()
        {
            // _gameManager.CAllGameOverEvent();
            Gizmos.color = color;
            Gizmos.DrawLine(Vector3.zero, transform.position);
        }

        void Start()
        {

            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
            lastDist_speedTOPlanet = 0f;
            speedtowardplanet_seedTOPlanet = 0f;

            time_atDist_speedTOPlanet = 0f;
            time_atLASTDist_speedTOPlanet = 0f;
            player = GameObject.Find("rocketprefab");

           
            mypos = transform.position;
            radius = transform.localScale.y / 2;
            gravforce = radius * 3;

            roverref = player.transform.GetChild(0).gameObject;
            RScript = roverref.GetComponent<Rover_Script>();


        }


        void FixedUpdate()
        {
            okpullfix();
            playerosgettingclosser();
           //print( "angl  " +AngleOfShipRelativeToPlanet());
        }

        void playerosgettingclosser()
        {
            if (player != null)
            {
                float distance = (transform.position - player.transform.position).magnitude;
                time_atDist_speedTOPlanet = Time.time;
                if (distance < lastDist_speedTOPlanet)
                {
                    speedtowardplanet_seedTOPlanet = (distance - lastDist_speedTOPlanet) / (time_atLASTDist_speedTOPlanet - time_atDist_speedTOPlanet);
                    //  print("speed toward planet " + speedtowardplanet);
                }
                lastDist_speedTOPlanet = distance;
                time_atLASTDist_speedTOPlanet = time_atDist_speedTOPlanet;
            }

        }

        float AngleOfShipRelativeToPlanet()
        {
            float angle = 0f;
            if (player != null)
            {
                //Debug.DrawLine(mypos, mypos - diff, Color.black);
                Vector3 playerposVector = (player.transform.position - transform.position);
                angle = Vector3.Angle(playerposVector, player.transform.forward);
            }
            return angle;
        }



        void okpullfix()
        {
            if (player != null)
            {

                mypos = transform.position;
                playerpos = player.transform.position;
                oppositplayer = (mypos - playerpos);
                GravitationalpullDirectionAndForce = mypos + (oppositplayer.normalized) * gravforce;


                if (applyGravity)
                {
                    if (Vector3.Distance(mypos, playerpos) < gravforce)
                    {
                        player.GetComponent<Rigidbody>().AddForce((oppositplayer / (radius / 2)) * 1.5f);


                    }
                }

                Debug.DrawLine(mypos, GravitationalpullDirectionAndForce, Color.red);
            }
        }


        void setCurplanetToRover() {
            RScript.setCurPlanet(this.gameObject);
        }

        void OnCollisionEnter(Collision collider)
        {
            //if (AngleOfShipRelativeToPlanet() > 9f) { Destroy(collider.gameObject); }
            //else
            if (collider.gameObject.tag == "playerTAG")
            {
               // print("XXXXXcollision at speed" + speedtowardplanet_seedTOPlanet);
                if (speedtowardplanet_seedTOPlanet > 5f || AngleOfShipRelativeToPlanet() > 9f)
                {
                    _gameManager.CAllGameOverEvent();
                    Destroy(collider.gameObject);
                }
                else //landed properly
                {
                    _gameManager.CAllPlayerASkedToLand();
                    setCurplanetToRover();

               
                }
            }
        }





















        #region oldcode





        //void okpull()
        //{
        //    mypos = transform.position;
        //    playerpos = player.transform.position;
        //    oppositplayer = (mypos - playerpos);
        //    GravitationalpullDirectionAndForce = mypos + (oppositplayer.normalized) * gravforce;
        //    float g = GravitationalpullDirectionAndForce.magnitude;

        //    if (Vector3.Distance(mypos, playerpos) < gravforce)
        //    {
        //        player.GetComponent<Rigidbody>().AddForce(GravitationalpullDirectionAndForce/10);
        //        Debug.Log(GravitationalpullDirectionAndForce);
        //    }


        //    Debug.DrawLine(mypos, GravitationalpullDirectionAndForce, Color.red);
        //    Debug.DrawLine(mypos, playerpos, Color.yellow);
        //}

        //void badpull2()
        //{

        //    Vector3 playerpos;

        //    Vector3 behind;

        //    Vector3 vtoplayer;
        //    Vector3 rangeofaction;
        //    playerpos = player.transform.position;
        //    oppositplayer = mypos - playerpos;
        //    oppositplayer.Normalize();
        //    GravitationalpullDirectionAndForce = oppositplayer * radius * 3;
        //    float g = GravitationalpullDirectionAndForce.magnitude;
        //    vtoplayer = playerpos - mypos;

        //    //  print(vtoplayer.magnitude);

        //    if (vtoplayer.magnitude < g)
        //    {

        //        player.GetComponent<Rigidbody>().AddForce(GravitationalpullDirectionAndForce / (radius * 2f));

        //    }

        //    Debug.DrawLine(mypos, GravitationalpullDirectionAndForce, Color.red);
        //    Debug.DrawLine(mypos, playerpos, Color.yellow);

        //}

        //void badpull()
        //{

        //    Vector3 playerpos;

        //    Vector3 behind;

        //    Vector3 vtoplayer;
        //    Vector3 rangeofaction;
        //    playerpos = player.transform.position;
        //    oppositplayer = mypos - playerpos;
        //    oppositplayer.Normalize();
        //    GravitationalpullDirectionAndForce = oppositplayer * radius * 3  ;
        //    float g = GravitationalpullDirectionAndForce.magnitude;
        //    vtoplayer = playerpos - mypos;

        //    //  print(vtoplayer.magnitude);

        //    if (vtoplayer.magnitude < g)
        //    {

        //        player.GetComponent<Rigidbody>().AddForce(GravitationalpullDirectionAndForce / (radius*2f));

        //    }

        //    Debug.DrawLine(mypos, GravitationalpullDirectionAndForce, Color.red);
        //    Debug.DrawLine(mypos, playerpos, Color.yellow);

        //}


        //void OnCollisionEnter(Collision collider)
        //{
        //    print(collider.gameObject.tag);
        //}
        #endregion

    }

}
