using UnityEngine;
using System.Collections;


namespace nabspace {
    public class StarGenerator : MonoBehaviour
    {

        //GameObject player;
        //string pathbase;

        //GameObject go1;
        //GameObject go2;
        //GameObject go3;
        //void Start()
        //{
        //    player = GameObject.Find("rocketprefab");
        //    pathbase = "flatStars/star";

        //    go1 = transform.GetChild(0).gameObject;
        //    go2 = transform.GetChild(1).gameObject;
        //    go3 = transform.GetChild(2).gameObject;



        //    dothestars();
        //}


        //Vector3 playerpos;
        bool mutex = false;
        void Update()
        {

            //playerpos = player.transform.position;
            //   int playposxINt = (int)playerpos.x;

            //   if (playposxINt % 100 == 0 && mutex==false) mutex = true;
            //   //     if (playposxINt % 100 != 0) mutex = false;
            //   if (mutex) { print("now"); }

            print("YOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
        }

        //void makestars(Vector3 playerposhere) {
        //    float randx = Random.RandomRange(-2000, 2000);
        //    float randy = Random.RandomRange(-2000, 2000);
        //    Instantiate(go1, new Vector3(playerposhere.x+randx, playerposhere.y+randy, 0), Quaternion.identity);
        //}

        //void dothestars() {
        //    playerpos = player.transform.position;
        //    for (int x=0; x<10000; x++)
        //    makestars(playerpos);
        //}
    }
}
