using UnityEngine;
using System.Collections;

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

 
    float lastDist;

    float time_atDist;
    float time_atLASTDist;

    float speedtowardplanet;

    Vector3 diff;
    void OnDrawGizmos() {
        Gizmos.color = color;
        Gizmos.DrawLine(Vector3.zero, transform.position);
    }

    void Start()
    {
        lastDist = 0f;
        speedtowardplanet = 0f;
        time_atDist=0f;
        time_atLASTDist=0f;
        player = GameObject.Find("rocketprefab");
        mypos = transform.position;
        radius = transform.localScale.y / 2;
        gravforce = radius * 3;
    
    }


    void FixedUpdate()
    {
        okpullfix();
        findplayerspeed();
        playerosgettingclosser();
        AngleOfShipRelativeToPlanet();
    }


    void findplayerspeed() {     
        mypos = transform.position;
        playerpos = player.transform.position;
        diff = mypos - playerpos;
      
       // Debug.DrawLine(mypos, mypos-diff, Color.black);
    }



    void playerosgettingclosser() {

        float distance = (transform.position - player.transform.position).magnitude;
        time_atDist = Time.time;
        if (distance < lastDist)
        {          
            speedtowardplanet = (distance - lastDist) / ( time_atLASTDist - time_atDist );
          //  print("speed toward planet " + speedtowardplanet);
        }
        lastDist = distance;
        time_atLASTDist = time_atDist;
    }





    float AngleOfShipRelativeToPlanet() {
      
     //  Debug.DrawLine(mypos, mypos - diff, Color.black);
        Vector3 playerposVector = (player.transform.position - transform.position);
        float angle = Vector3.Angle(playerposVector, player.transform.forward);
     //   Debug.Log(angle);
        return angle;
   }



    void okpullfix()
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
    //    Debug.DrawLine(mypos, playerpos, Color.yellow);
    }
    void OnCollisionEnter(Collision collider)
    {
        if (AngleOfShipRelativeToPlanet() >10f   ) { Destroy(collider.gameObject); }

        if (collider.gameObject.tag == "playerTAG") {
            print("XXXXXcollision at speed" + speedtowardplanet);
            if (speedtowardplanet > 5f) {
                Destroy(collider.gameObject);
            }
        }
    }





















    #region oldcode





    void okpull()
    {
        mypos = transform.position;
        playerpos = player.transform.position;
        oppositplayer = (mypos - playerpos);
        GravitationalpullDirectionAndForce = mypos + (oppositplayer.normalized) * gravforce;
        float g = GravitationalpullDirectionAndForce.magnitude;

        if (Vector3.Distance(mypos, playerpos) < gravforce)
        {
            player.GetComponent<Rigidbody>().AddForce(GravitationalpullDirectionAndForce/10);
            Debug.Log(GravitationalpullDirectionAndForce);
        }


        Debug.DrawLine(mypos, GravitationalpullDirectionAndForce, Color.red);
        Debug.DrawLine(mypos, playerpos, Color.yellow);
    }

    void badpull2()
    {

        Vector3 playerpos;

        Vector3 behind;

        Vector3 vtoplayer;
        Vector3 rangeofaction;
        playerpos = player.transform.position;
        oppositplayer = mypos - playerpos;
        oppositplayer.Normalize();
        GravitationalpullDirectionAndForce = oppositplayer * radius * 3;
        float g = GravitationalpullDirectionAndForce.magnitude;
        vtoplayer = playerpos - mypos;

        //  print(vtoplayer.magnitude);

        if (vtoplayer.magnitude < g)
        {

            player.GetComponent<Rigidbody>().AddForce(GravitationalpullDirectionAndForce / (radius * 2f));

        }

        Debug.DrawLine(mypos, GravitationalpullDirectionAndForce, Color.red);
        Debug.DrawLine(mypos, playerpos, Color.yellow);

    }

    void badpull()
    {

        Vector3 playerpos;
      
        Vector3 behind;

        Vector3 vtoplayer;
        Vector3 rangeofaction;
        playerpos = player.transform.position;
        oppositplayer = mypos - playerpos;
        oppositplayer.Normalize();
        GravitationalpullDirectionAndForce = oppositplayer * radius * 3  ;
        float g = GravitationalpullDirectionAndForce.magnitude;
        vtoplayer = playerpos - mypos;

        //  print(vtoplayer.magnitude);

        if (vtoplayer.magnitude < g)
        {

            player.GetComponent<Rigidbody>().AddForce(GravitationalpullDirectionAndForce / (radius*2f));

        }

        Debug.DrawLine(mypos, GravitationalpullDirectionAndForce, Color.red);
        Debug.DrawLine(mypos, playerpos, Color.yellow);

    }


    //void OnCollisionEnter(Collision collider)
    //{
    //    print(collider.gameObject.tag);
    //}
    #endregion

}

