﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace nabspace
{
    public class b_EnemyGenerator : MonoBehaviour
    {

        string pathtoenemy;
        GameObject player;
        private GameManager_Master _gameManager;
        public List<GameObject> listofbadies;
        SpaceMaster _spaceMaster;

        void Awake()
        {
            listofbadies = new List<GameObject>();
        }

        void OnEnable()
        {
            _spaceMaster = GameObject.Find("SpaceMaster_Event_Object").GetComponent<SpaceMaster>();
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
            _gameManager.EnemyHasDied += TakeOutThisEnemy;
            _spaceMaster.IhaveBeenCreated += makesomeenemiesHere;

        }

        void OnDisable()
        {
            _gameManager.EnemyHasDied -= TakeOutThisEnemy;
            _spaceMaster.IhaveBeenCreated -= makesomeenemiesHere;
        }


        void Start()
        {

            player = GameObject.Find("rocketprefab");
            pathtoenemy = "EnemySkyResources/SkyEnemy1";



            //for (int x = 1; x < 5; x++)
            //{
            //    GameObject go = Instantiate(Resources.Load(pathtoenemy), new Vector3(-400, 100*x ,0),  transform.rotation ) as GameObject;
            //    listofbadies.Add(go);
            //}

            //for (int x = 0; x < 5; x++)
            //{
            //    GameObject go = Instantiate(Resources.Load(pathtoenemy), new Vector3(400, 100 * x, 0), transform.rotation) as GameObject;
            //    listofbadies.Add(go);
            //}


            //for (int x = 0; x < 5; x++)
            //{
            //    GameObject go = Instantiate(Resources.Load(pathtoenemy), new Vector3(-400, -100 * x, 0), transform.rotation) as GameObject;
            //    listofbadies.Add(go);
            //}
        }
        void TakeOutThisEnemy(GameObject go)
        {

            listofbadies.Remove(go);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void makesomeenemiesHere(GameObject thisQuad)
        {
            //  print("SECTOR WAS GENEREATED " + thisQuad.transform.position);

            float _sizeofQuad = thisQuad.transform.GetComponent<b_Quad_Script>().GetSectorScale();

            float curMinX = thisQuad.transform.position.x - (_sizeofQuad / 2);
            float curmaxX = thisQuad.transform.position.x + (_sizeofQuad / 2);
            float curMinY = thisQuad.transform.position.y - (_sizeofQuad / 2);
            float curmaxY = thisQuad.transform.position.y + (_sizeofQuad / 2);

            for (int cnt = 0; cnt < 3; cnt++)
            {
                float x = Random.Range(curMinX, curmaxX);
                float y = Random.Range(curMinY, curmaxY);
                int number= Random.Range(1, 6);
                string path = "EnemySkyResources/SkyEnemy" + number.ToString();
                Quaternion goodrotation = Quaternion.Euler(0, 90, 0);
                GameObject go = Instantiate(Resources.Load(path), new Vector3(x, y, 0), goodrotation) as GameObject;
                go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, 0);

                go.transform.parent = thisQuad.transform;
                //   go.transform.localScale = new Vector3(thisQuad.transform.localScale.y , thisQuad.transform.localScale.y, thisQuad.transform.localScale.y);

                listofbadies.Add(go);
            }


        }
    }
}