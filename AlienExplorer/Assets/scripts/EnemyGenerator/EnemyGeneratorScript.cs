using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace nabspace {
    public class EnemyGeneratorScript : MonoBehaviour
    {

        string pathtoenemy;
        GameObject player;
        private GameManager_Master _gameManager;
        public List<GameObject> listofbadies;
        SpaceMaster _spaceMaster;


        void OnEnable()
        {
            _spaceMaster = transform.GetComponent<SpaceMaster>();
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
            listofbadies = new List<GameObject>();


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
        void TakeOutThisEnemy(GameObject go) {
          
            listofbadies.Remove(go);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void makesomeenemiesHere(GameObject thisQuad) {
          //  print("SECTOR WAS GENEREATED " + thisQuad.transform.position);

            float _sizeofQuad = thisQuad.transform.localScale.x;

            float curMinX = thisQuad.transform.position.x - (_sizeofQuad / 2);
            float curmaxX = thisQuad.transform.position.x + (_sizeofQuad / 2);
            float curMinY = thisQuad.transform.position.y - (_sizeofQuad / 2);
            float curmaxY = thisQuad.transform.position.y + (_sizeofQuad / 2);

            for (int cnt = 0; cnt < 3; cnt++)
            {
                float x = Random.Range(curMinX, curmaxX);
            float y = Random.Range(curMinY, curmaxY);

            GameObject go = Instantiate(Resources.Load("EnemySkyResources/SkyEnemy1"), new Vector3(x, y, 0), transform.rotation) as GameObject;
            listofbadies.Add(go);
            }


        }
    }
}
