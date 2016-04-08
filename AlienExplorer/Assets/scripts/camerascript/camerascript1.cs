using UnityEngine;
using System.Collections;
namespace S3{

    public class camerascript1 : MonoBehaviour
    {

        private GameManager_Master _gammaster;
        private GameObject rocket;
        // Use this for initialization
        void Start()
        {

             
            rocket = GameObject.Find("rocketprefab");


        }

        // Update is called once per frame
        void Update()
        {
            showplayerspeed();



            transform.position = new Vector3(rocket.transform.position.x, rocket.transform.position.y, transform.position.z);
        }


        void showplayerspeed()
        {
           // print(rocket.GetComponent<Rigidbody>().velocity);

        }
    }

}
