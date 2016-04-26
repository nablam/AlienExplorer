using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace nabspace {
    public class SpaceManager : MonoBehaviour
    {
        GameObject playership;

        private GameManager_Master _gameManager;

        List<GameObject> listofsectors;

        void Awake()
        {
            listofsectors = new List<GameObject>();
          sizeofQuad = 0;
          aquad = Instantiate(Resources.Load("Quads/quad1"), Vector3.zero, Quaternion.identity) as GameObject;
            listofsectors.Add(aquad);
        }

        void OnEnable()
        {

            SetInitialReferences();
            spm.Iaminthissector += setCurSector;

        }

        void OnDisable()
        {
            spm.Iaminthissector -= setCurSector;

        }

        void setCurSector(GameObject go) { currquad = go; }

        void Start()
        {
           currquad = aquad;
            sizeofQuad = aquad.transform.localScale.x;
            calculateLocalbounds();
        }

        void Update()
        {
            Vector3 playerpos = playership.transform.position;
            print(playerpos.x + " "+ curmaxX);
            findcurquad();
            if (playerpos.x > curmaxX)
            {
                Vector3 here = new Vector3(currquad.transform.position.x + sizeofQuad, currquad.transform.position.y, 0);

                if (!doesExist(here))
                {
                    aquad = Instantiate(Resources.Load("Quads/quad1")) as GameObject;
                    aquad.transform.position = here;
                    listofsectors.Add(aquad);
                }

                //currquad = aquad;
             
                calculateLocalbounds();

            }


            if (playerpos.x < curMinX)
            {
                Vector3 here = new Vector3(currquad.transform.position.x - sizeofQuad, currquad.transform.position.y, 0);

                if (!doesExist(here))
                {
                    aquad = Instantiate(Resources.Load("Quads/quad1")) as GameObject;
                    aquad.transform.position = here;
                    listofsectors.Add(aquad);
                }

                //currquad = aquad;

                calculateLocalbounds();

            }



            if (playerpos.y < curMinY)
            {
                Vector3 here = new Vector3(currquad.transform.position.x,  currquad.transform.position.y - sizeofQuad, 0);

                if (!doesExist(here))
                {
                    aquad = Instantiate(Resources.Load("Quads/quad1")) as GameObject;
                    aquad.transform.position = here;
                    listofsectors.Add(aquad);
                }

                //currquad = aquad;

                calculateLocalbounds();

            }

            if (playerpos.y > curmaxY)
            {
                Vector3 here = new Vector3(currquad.transform.position.x, currquad.transform.position.y + sizeofQuad, 0);

                if (!doesExist(here))
                {
                    aquad = Instantiate(Resources.Load("Quads/quad1")) as GameObject;
                    aquad.transform.position = here;
                    listofsectors.Add(aquad);
                }

                //currquad = aquad;

                calculateLocalbounds();

            }

        }

        bool doesExist(Vector3 h) {
            bool exists = false;
            foreach (GameObject go in listofsectors) {
                if (go.transform.position == h) { exists = true; }
            }
            return exists;
        }
     public   float curMinX;
     public   float curmaxX;
        public float curMinY;
        public float curmaxY;

        void calculateLocalbounds() {
            curMinX = currquad.transform.position.x - (sizeofQuad / 2);
            curmaxX = currquad.transform.position.x + (sizeofQuad / 2);
            curMinY = currquad.transform.position.y - (sizeofQuad / 2);
            curmaxY = currquad.transform.position.y + (sizeofQuad / 2);
        }

        void findcurquad() {

            foreach (GameObject go in listofsectors) {

                Debug.DrawLine(go.transform.position, playership.transform.position, Color.red);
                Vector3 diff = playership.transform.position - go.transform.position;
                if (diff.magnitude < sizeofQuad / 2) {
                    currquad = go;
                }
            }
        }



        GameObject aquad;

        public GameObject currquad;

        float sizeofQuad;
        SpaceMaster spm;
        void SetInitialReferences()
        {
            _gameManager = GetComponent<GameManager_Master>();
            playership = GameObject.Find("rocketprefab");
            spm = transform.GetComponent<SpaceMaster>();

        }
    }
}
