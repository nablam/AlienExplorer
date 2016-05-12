using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace nabspace {
    public class b_Space_Manager : MonoBehaviour
    {


        public GameObject currquad;
        public float curMinX;
        public float curmaxX;
        public float curMinY;
        public float curmaxY;

        private GameObject _playership;
        private GameObject _aquad;
        private GameManager_Master _gameManager;
        private List<GameObject> _listofsectors;
        private float _sizeofQuad;
        private SpaceMaster _spaceMaster;

        void Awake()
        {
            _listofsectors = new List<GameObject>();
            _sizeofQuad = 0;
            _aquad = Instantiate(Resources.Load("Quads/b_SpaceQuad"), new Vector3(0, 0, 10), Quaternion.identity) as GameObject;
            _aquad.transform.parent = this.transform;
            _aquad.GetComponent<b_Quad_Script>().iscentertile = true;
            _listofsectors.Add(_aquad);
          //  print("i am stuck on " + this.gameObject.name);
            _spaceMaster = GameObject.Find("SpaceMaster_Event_Object").GetComponent<SpaceMaster>();
            
        }

        void OnEnable()
        {
            SetInitialReferences();
        }

        void OnDisable()
        {
        }

        void Start()
        {
            currquad = _aquad;
            _sizeofQuad =  _aquad.GetComponent<b_Quad_Script>().GetSectorScale();
            calculateLocalbounds();
            buildallquad();
        }

        void Update()
        {
            if (!_gameManager.isGameOver)
            {
                findCurrQuad();
                if (_playership != null)
                {
                    Vector3 playerpos = _playership.transform.position;
                    if (playerpos.x > curmaxX || playerpos.x < curMinX || playerpos.y > curmaxY || playerpos.y < curMinY) buildallquad();
                }

               trackDistanceFromQuad();

            }

        }

        void findCurrQuad()
        {
            if (_playership != null)
            {
                Vector3 playerpos = _playership.transform.position;
                Vector3 raycasterStart = new Vector3(_playership.transform.position.x, _playership.transform.position.y, _playership.transform.position.z - 2);
             //   Debug.DrawLine(raycasterStart, new Vector3(_playership.transform.position.x, _playership.transform.position.y, _playership.transform.position.z - 12), Color.blue);
                //Physics.Raycast(raycasterStart, Vector3.back * 15f);
                Ray theray = new Ray(playerpos, Vector3.back);
                RaycastHit hit;
                //if (Physics.Raycast(raycasterStart, new Vector3(_playership.transform.position.x, _playership.transform.position.y, _playership.transform.position.z - 12), out hit))
                if (Physics.Raycast(theray, out hit, 15f))
                {

                    if (hit.collider.CompareTag("sectorTAG"))
                    {
                        currquad = hit.collider.gameObject;
                    }
                }
            }

        }


        void buildallquad()
        {
            biuildQuad1();
            biuildQuad2();
            biuildQuad3();
            biuildQuad4();
            biuildQuad6();
            biuildQuad7();
            biuildQuad8();
            biuildQuad9();
            calculateLocalbounds();
        }

        void biuildQuad2()
        {
            Vector3 here = new Vector3(currquad.transform.position.x, currquad.transform.position.y - _sizeofQuad, 10);
            if (!doesExist(here))
            {
                _aquad = Instantiate(Resources.Load("Quads/b_SpaceQuad")) as GameObject;
                _aquad.transform.position = here; _aquad.transform.parent = this.transform;
                _spaceMaster.CAllThisSectorWasCreated(_aquad);
                _listofsectors.Add(_aquad);
            }
        }
        void biuildQuad1()
        {
            Vector3 here = new Vector3(currquad.transform.position.x - _sizeofQuad, currquad.transform.position.y - _sizeofQuad, 10);
            if (!doesExist(here))
            {
                _aquad = Instantiate(Resources.Load("Quads/b_SpaceQuad")) as GameObject;
                _aquad.transform.position = here; _aquad.transform.parent = this.transform;
                _spaceMaster.CAllThisSectorWasCreated(_aquad);
                _listofsectors.Add(_aquad);
            }
        }
        void biuildQuad3()
        {
            Vector3 here = new Vector3(currquad.transform.position.x + _sizeofQuad, currquad.transform.position.y - _sizeofQuad, 10);
            if (!doesExist(here))
            {
                _aquad = Instantiate(Resources.Load("Quads/b_SpaceQuad")) as GameObject;
                _aquad.transform.position = here; _aquad.transform.parent = this.transform;
                _spaceMaster.CAllThisSectorWasCreated(_aquad);
                _listofsectors.Add(_aquad);
            }
        }
        void biuildQuad8()
        {
            Vector3 here = new Vector3(currquad.transform.position.x, currquad.transform.position.y + _sizeofQuad, 10);
            if (!doesExist(here))
            {
                _aquad = Instantiate(Resources.Load("Quads/b_SpaceQuad")) as GameObject;
                _aquad.transform.position = here; _aquad.transform.parent = this.transform;
                _spaceMaster.CAllThisSectorWasCreated(_aquad);
                _listofsectors.Add(_aquad);
            }
        }
        void biuildQuad7()
        {
            Vector3 here = new Vector3(currquad.transform.position.x - _sizeofQuad, currquad.transform.position.y + _sizeofQuad, 10);
            if (!doesExist(here))
            {
                _aquad = Instantiate(Resources.Load("Quads/b_SpaceQuad")) as GameObject;
                _aquad.transform.position = here; _aquad.transform.parent = this.transform;
                _spaceMaster.CAllThisSectorWasCreated(_aquad);
                _listofsectors.Add(_aquad);
            }
        }
        void biuildQuad9()
        {
            Vector3 here = new Vector3(currquad.transform.position.x + _sizeofQuad, currquad.transform.position.y + _sizeofQuad, 10);
            if (!doesExist(here))
            {
                _aquad = Instantiate(Resources.Load("Quads/b_SpaceQuad")) as GameObject;
                _aquad.transform.position = here; _aquad.transform.parent = this.transform;
                _spaceMaster.CAllThisSectorWasCreated(_aquad);
                _listofsectors.Add(_aquad);
            }
        }
        void biuildQuad4()
        {
            Vector3 here = new Vector3(currquad.transform.position.x - _sizeofQuad, currquad.transform.position.y, 10);
            if (!doesExist(here))
            {
                _aquad = Instantiate(Resources.Load("Quads/b_SpaceQuad")) as GameObject;
                _aquad.transform.position = here; _aquad.transform.parent = this.transform;
                _spaceMaster.CAllThisSectorWasCreated(_aquad);
                _listofsectors.Add(_aquad);
            }
        }
        void biuildQuad6()
        {
            Vector3 here = new Vector3(currquad.transform.position.x + _sizeofQuad, currquad.transform.position.y, 10);
            if (!doesExist(here))
            {
                _aquad = Instantiate(Resources.Load("Quads/b_SpaceQuad")) as GameObject;
                _aquad.transform.position = here; _aquad.transform.parent = this.transform;
                _spaceMaster.CAllThisSectorWasCreated(_aquad);
                _listofsectors.Add(_aquad);
            }
        }

        bool doesExist(Vector3 h)
        {
            bool exists = false;
            foreach (GameObject go in _listofsectors)
            {
                if (go.transform.position == h) { exists = true; }
            }
            return exists;
        }


        void calculateLocalbounds()
        {
            curMinX = currquad.transform.position.x - (_sizeofQuad / 2);
            curmaxX = currquad.transform.position.x + (_sizeofQuad / 2);
            curMinY = currquad.transform.position.y - (_sizeofQuad / 2);
            curmaxY = currquad.transform.position.y + (_sizeofQuad / 2);
        }


        void trackDistanceFromQuad() {
            if (!_gameManager.isGameOver && _playership != null)
            {
                foreach (GameObject sec in _listofsectors)
                {
                    Vector3 diff = sec.transform.position - _playership.transform.position;
                    if (diff.magnitude > 800) { Debug.DrawLine(sec.transform.position, _playership.transform.position, Color.red); DeactivateAllinGO(sec); }

                    else
                    { Debug.DrawLine(sec.transform.position, _playership.transform.position, Color.blue); AcctivateAllinGO(sec); }
                }
            }
        }

        void DeactivateAllinGO(GameObject go) {

            foreach (Transform t in go.transform) {
                t.gameObject.SetActive(false);
            }
        }

        void AcctivateAllinGO(GameObject go)
        {

            foreach (Transform t in go.transform)
            {
                t.gameObject.SetActive(true);
            }
        }



        void SetInitialReferences()
        {
            _playership = GameObject.Find("rocketprefab");
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
        }

    }
}
