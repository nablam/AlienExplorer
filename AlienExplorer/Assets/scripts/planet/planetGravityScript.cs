using UnityEngine;
using System.Collections;

public class planetGravityScript : MonoBehaviour
{

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

    float TimeatA;
    float TimeatB;
    float lastDist;

    float time_atDist;
    float time_atLASTDist;

    float speedtowardplanet;
    void OnDrawGizmos() {
        Gizmos.color = color;
        Gizmos.DrawLine(Vector3.zero, transform.position);
    }

    void Start()
    {
        TimeatA = 0f;
        TimeatB = 0f;

        lastDist = 0f;

        speedtowardplanet = 0f;
        time_atDist=0f;
        time_atLASTDist=0f;

        player = GameObject.Find("rocketprefab");
        mypos = transform.position;
        radius = transform.localScale.y / 2;

        gravforce = radius * 3;
       // print("radius=" + radius);
    }


    void FixedUpdate()
    {
        okpullfix();
        findplayerspeed();
         

    }


    void findplayerspeed() {


        playerosgettingclosser();

        mypos = transform.position;
        playerpos = player.transform.position;
        Vector3 diff = mypos - playerpos;
        Vector3 blackvector = diff;

        float distA = radius + (radius / 6);
        float distB = radius + (radius / 10);

      

        if (blackvector.magnitude < distA && blackvector.magnitude > distB)
        {
            print("reached point A");
            TimeatA = Time.time;
            
        }
        if (blackvector.magnitude < distB && blackvector.magnitude > radius)
        {
            print("reached point B");
            TimeatB = Time.time;
        }

        Debug.DrawLine(mypos, mypos-diff, Color.black);
    }


    void playerosgettingclosser() {

        float distance = (transform.position - player.transform.position).magnitude;
        time_atDist = Time.time;
        if (distance < lastDist)
        {
           
            speedtowardplanet = (distance - lastDist) / ( time_atLASTDist - time_atDist );

            print("speed toward planet " + speedtowardplanet);
        }
        lastDist = distance;
        time_atLASTDist = time_atDist;
    }


    void showplayerspeed() {
       print( player.GetComponent<Rigidbody>().velocity);

    }
    void okpullfix()
    {
        mypos = transform.position;
        playerpos = player.transform.position;
        oppositplayer = (mypos - playerpos);
        GravitationalpullDirectionAndForce = mypos + (oppositplayer.normalized) * gravforce;
        

        if (Vector3.Distance(mypos, playerpos) < gravforce)
        {
            player.GetComponent<Rigidbody>().AddForce( (oppositplayer / (radius / 2)) *1.5f );
           

        }


        Debug.DrawLine(mypos, GravitationalpullDirectionAndForce, Color.red);
    //    Debug.DrawLine(mypos, playerpos, Color.yellow);
    }
    void OnCollisionEnter(Collision collider)
    {
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

