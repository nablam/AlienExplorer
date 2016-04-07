using UnityEngine;
using System.Collections;

public class planetGravityScript : MonoBehaviour
{



    GameObject player;
    Vector3 playerpos;
    Vector3 mypos;
    Vector3 oppositplayer;
    Vector3 unitOposit;
    Vector3 GravitationalpullDirectionAndForce;
    float gravforce;

    Vector3 oppositPlayerNormalizedFROM00;
    float radius;

    void Start()
    {

        player = GameObject.Find("rocketprefab");
        mypos = transform.position;
        radius = transform.localScale.y / 2;

        gravforce = radius * 3;
        print("radius=" + radius);
    }


    void FixedUpdate()
    {



        badpull2();

    }

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
}

