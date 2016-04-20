﻿using UnityEngine;
using System.Collections;


namespace nabspace {
    public class enemySkyMissileScript : MonoBehaviour
    {

        Player_Master pm;
        float enemyrocketspeed = 100;
        void Start()
        {
            pm = GameObject.Find("rocketprefab").GetComponent<Player_Master>();
            StartCoroutine("killmissilein5seconds");
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * enemyrocketspeed, Space.Self);
        }

        IEnumerator killmissilein5seconds()
        {

            yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }

        //void OnTriggerEnter(Collider other)
        //{
        //    if (other.gameObject.tag == "playerTAG")
        //    {
        //        pm.CALLEventPlayerHealthDown(10);
        //        Destroy(this.gameObject);
               
        //    }
        //}

        void OnCollisionEnter(Collision collider)
        {
            if (collider.gameObject.tag == "playerTAG")
            {
                pm.CALLEventPlayerHealthDown(10);
                Destroy(this.gameObject);
            }
        }

    }
}