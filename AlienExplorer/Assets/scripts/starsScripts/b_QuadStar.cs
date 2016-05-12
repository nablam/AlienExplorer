using UnityEngine;
using System.Collections;
namespace nabspace
{
    public class b_QuadStar : MonoBehaviour
    {


        public float curMinX;
        public float curmaxX;
        public float curMinY;
        public float curmaxY;

        int howmanystars;
        void Awake()
        {

        }

        void OnEnable()
        {


        }

        void Start()
        {


            SetInitialReferences();
        }

        void OnDisable()
        {

        }

        void SetInitialReferences()
        {
            calculateLocalbounds();

            for (int x = 0; x < howmanystars; x++)
            {

                makerandStarHere(getrandX(), getrandY());
            }
        }



        void calculateLocalbounds()
        {
            float _sizeofQuad = transform.GetComponent<b_Quad_Script>().GetSectorScale();
            curMinX = transform.position.x - (_sizeofQuad / 2);
            curmaxX = transform.position.x + (_sizeofQuad / 2);
            curMinY = transform.position.y - (_sizeofQuad / 2);
            curmaxY = transform.position.y + (_sizeofQuad / 2);

            howmanystars = (int)_sizeofQuad / 10;
        }

        float getrandX()
        {
            float x = Random.Range(curMinX, curmaxX);
            return x;
        }
        float getrandY()
        {
            float y = Random.Range(curMinY, curmaxY);
            return y;
        }

        void makerandStarHere(float x, float y)
        {
            string basepath = "flatStars/star";
            int number = Random.Range(1, 4);//1 2 3
            string nstr = number.ToString();
            string randompath = basepath + nstr;
            GameObject stargo = Instantiate(Resources.Load(randompath), new Vector3(x, y, 15f), Quaternion.identity) as GameObject;
            stargo.transform.parent = this.transform;
        }

    }
}