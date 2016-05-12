using UnityEngine;
using System.Collections;
//when planet radius is 100 and its strength is 2.2 and rocket speed is 10 
//it gets a bit cool as you have to swing around the planet to escape its grip on ya ;)

namespace nabspace {
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
    

        Vector3 oppositPlayerNormalizedFROM00;
        float radius;

        float lastDist_speedTOPlanet;
        float time_atDist_speedTOPlanet;
        float time_atLASTDist_speedTOPlanet;
        float speedtowardplanet_seedTOPlanet;
        Vector3 diff;
        public float strength=2.5f;

        public float divideRadiusby = 1.5f; //2 is a good value
        public float testvalue;

      public   float minDistToApplyGravity;
        float DeltaDistancefromBellowSurface;
        float unchangingDistFronPseudosurface;
        float smallerradius;

       public bool castleNotYetGenerated = true;
        GameManager_Master _gameManager;

        EnemyGeneratorScript egs;
        SpaceManager sm;
 



        public float getRadius() { return radius; }
        
        //void OnDrawGizmos()
        //{
        //    // _gameManager.CAllGameOverEvent();
        //    Gizmos.color = color;
        //    if(player != null)
        //    Gizmos.DrawLine(player.transform.position, transform.position);
        //}

        void Start()
        {
            sm = GameObject.Find("Space_The_Final_Frontier").GetComponent<SpaceManager>();
             egs = GameObject.Find("SkyenemyGeneratorObject").GetComponent<EnemyGeneratorScript>(); 
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
            lastDist_speedTOPlanet = 0f;
            speedtowardplanet_seedTOPlanet = 0f;

            time_atDist_speedTOPlanet = 0f;
            time_atLASTDist_speedTOPlanet = 0f;
            player = GameObject.Find("rocketprefab");

           
            mypos = transform.position;
            radius = transform.localScale.z / 2;
            minDistToApplyGravity = radius * 2.5f;

            smallerradius = radius - (radius / 10);
            unchangingDistFronPseudosurface = minDistToApplyGravity - smallerradius;

            //roverref = player.transform.GetChild(0).gameObject;
            //  RScript = roverref.GetComponent<Rover_Script>();
          //  GetComponent<Shader>().m
          //  transform.renderer.materials[0].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        }


        void FixedUpdate()
        {
            okpullfix();
          //  okpullEnemyfix();
            playerosgettingclosser();
        
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

            if (_gameManager.isRocketMode)
            {
                if (player != null)
                {
                    mypos = transform.position;
                    playerpos = player.transform.position;
                 //   Debug.DrawLine(mypos, playerpos, Color.blue);
                    oppositplayer = (mypos - playerpos);
                    GravitationalpullDirectionAndForce = mypos + (oppositplayer.normalized) * minDistToApplyGravity;
                    if (applyGravity)
                    {

                        if (Vector3.Distance(mypos, playerpos) < minDistToApplyGravity)
                        {
                            
                           // _gameManager.playerIsBeigPulledin = true;
                            player.GetComponent<Rigidbody>().AddForce((oppositplayer * 2 / (radius * divideRadiusby)) * strength);
                        }
                    //    else { _gameManager.playerIsBeigPulledin = false; }
                          
                    }

                 //    Debug.DrawLine(mypos, GravitationalpullDirectionAndForce, Color.red);
                }
            }
   
        }



        void okpullEnemyfix()
        {
            if (egs != null && sm != null )
            {
             
                    if (transform.parent == sm.currquad.transform)
                    {
                        mypos = transform.position;
                        foreach (GameObject go in egs.listofbadies)
                        {
                            Vector3 opositenemy = mypos - go.transform.position;
                            float distfromcenter = opositenemy.magnitude;
                            if (applyGravity)
                            {
                                if (Vector3.Distance(mypos, go.transform.position) < minDistToApplyGravity)
                                {
                                    DeltaDistancefromBellowSurface = distfromcenter - smallerradius;

                                    //  go.transform.GetComponent<Rigidbody>().AddForce(    ( (opositenemy*radius/ gravforce) / (distfromcenter)) );
                                    go.transform.GetComponent<Rigidbody>().AddForce((opositenemy / 50) * 4 * (unchangingDistFronPseudosurface / DeltaDistancefromBellowSurface));

                                    // Debug.Log(DeltaDistancefromBellowSurface + " ");


                                    //Debug.DrawLine(transform.position, go.transform.position, Color.red);
                                }
                            }
                        }
                    }
                                 
                // Debug.DrawLine(mypos, GravitationalpullDirectionAndForce, Color.red);
            }
        }


        //void setCurplanetToRover() {
        //    RScript.setCurPlanet(this.gameObject);
        //}


        public bool playerLandedOnMe;

        void OnCollisionEnter(Collision collider)
        {
            print(collider.gameObject.name + " KILLED ME");
          
            if (collider.gameObject.CompareTag("playerTAG"))
            {
               // print("XXXXXcollision at speed" + speedtowardplanet_seedTOPlanet);
                if (speedtowardplanet_seedTOPlanet > 5f || AngleOfShipRelativeToPlanet() > 9f)
                {
                    StartCoroutine("waitforGameOver");
                    //Instantiate(Resources.Load("Explosions/ShipExplosion"), transform.position, transform.rotation);
                   _gameManager.CAllGameOverEvent();

                    Destroy(collider.gameObject);
                }
                else //landed properly
                {
                    playerLandedOnMe = true;
                    _gameManager.CAllPlayerASkedToLand();                    
                    //setCurplanetToRover();

                
                }
            }


            if (collider.gameObject.CompareTag("enemyshipTAG")) {
              //  print("enemy collision");
                _gameManager.CAllEnemyDied(collider.gameObject);
                Instantiate(Resources.Load("Explosions/SkyEnemyExplosion1"), transform.position, transform.rotation);
                Destroy(collider.gameObject);
            }


        }

        IEnumerator waitforGameOver() {
            // _gameManager.isGameOver = true;  
            _gameManager.CAllGameOverEvent();
            Instantiate(Resources.Load("Explosions/ShipExplosion"), player.transform.position, transform.rotation);
            yield return new WaitForSeconds(2);
            _gameManager.CAllGameOverEvent();
        }

        void OnCollisionExit(Collision collider)
        {

            if (collider.gameObject.CompareTag("playerTAG"))
            {
            
                    playerLandedOnMe = false;
                
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
