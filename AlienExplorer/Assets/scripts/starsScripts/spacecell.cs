using UnityEngine;
using System.Collections;
namespace nabspace {
    public class spacecell : MonoBehaviour
    {
        public float farleft;
        public float farright;
        public float fartop;
        public float farbot;
        public float centerx;
        public float centery;
        public bool visited;

        public spacecell right;
        public spacecell left;
        public spacecell up;
        public spacecell down;

        public void initSpaceCell(float l, float r, float t, float b, float x, float y, bool v) { farleft = l; farright = r; fartop = t; farbot = b; visited = v; centerx = x; centery = y; }

        Transform quad;


        SpaceMaster spm;

      


        private GameManager_Master _gameManager;
        void Awake()
        {

        }

        void OnEnable()
        {
            SetInitialReferences();


        }

        void Start()
        {

        }

        void OnDisable()
        {

        }
        void SetInitialReferences()
        {
            spm = transform.GetComponent<SpaceMaster>();
        }

      

        void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "playerTAG") {
           //s     spm.CAllHeyManIamCurr(this.gameObject);
            }            
        }


    }
}
