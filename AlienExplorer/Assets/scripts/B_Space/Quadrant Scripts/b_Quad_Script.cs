using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace nabspace
{
    public class b_Quad_Script : MonoBehaviour
    {

        public bool iscentertile;

        public float curMinX;
        public float curmaxX;
        public float curMinY;
        public float curmaxY;

        private int _HowmanyRows;
        private int _distanceBetweenRows;
        private float[] _planetLineY;
        private string[] _planetPaths;

        private float _SectoreScale = 500;

        //public List<b_planet_DATA> listOfMyPlanets;

        public float GetSectorScale() { return _SectoreScale; }

        void Awake()
        {
          //  listOfMyPlanets = new List<b_planet_DATA>();
            iscentertile = false;
        }

        void OnEnable()
        {


        }

        void Start()
        {
            if (!iscentertile)
            {
                SetInitialReferences();
                coinToss();
            }
        }

        void OnDisable()
        {

        }

        void SetInitialReferences()
        {
            calculateLocalbounds();
            buildArrayOfYvalues(); // array 0 250 500 750
            builsArrayOfPlanetPaths();

        }

        void calculateLocalbounds()
        {
            float _sizeofQuad = _SectoreScale;
            curMinX = transform.position.x - (_sizeofQuad / 2) + 100;
            curmaxX = transform.position.x + (_sizeofQuad / 2);
            curMinY = transform.position.y - (_sizeofQuad / 2);
            curmaxY = transform.position.y + (_sizeofQuad / 2);
        }

        void buildArrayOfYvalues()
        {
            float _sizeofQuad = _SectoreScale;
            _HowmanyRows = ((int)_sizeofQuad / 500) * 3;
            _distanceBetweenRows = (int)_sizeofQuad / _HowmanyRows;
            _planetLineY = new float[_HowmanyRows];

            float baseline = 0;
            for (int cnt = 0; cnt < _HowmanyRows; cnt++)
            {
                _planetLineY[cnt] = curMinY + baseline;
                baseline = baseline + _distanceBetweenRows;
            }
        }




        void builsArrayOfPlanetPaths()
        {
            //small and medium
            _planetPaths = new string[6];
            _planetPaths[0] = "planets/B_Planet_dir/Planet1";
            _planetPaths[1] = "planets/B_Planet_dir/Planet2";
            _planetPaths[2] = "planets/B_Planet_dir/Planet4";
            _planetPaths[3] = "planets/B_Planet_dir/Planet5";
            //Large planets
            _planetPaths[4] = "planets/B_Planet_dir/Planet3";
            _planetPaths[5] = "planets/B_Planet_dir/Planet1";

        }

        float getrandX()
        {
            float x = Random.Range(curMinX, curmaxX);
            return x;
        }


        void Make_Small_and_Medium(int yindex)
        {

            float theyline = _planetLineY[yindex];
            int randomIndex = Random.Range(0, 4);//0 1 2 3  small or medium
            string randompath = _planetPaths[randomIndex];
            Vector3 planetLocation = new Vector3(getrandX(), theyline, 0f);
            GameObject go = Instantiate(Resources.Load(randompath), planetLocation, Quaternion.identity) as GameObject;
            go.transform.parent = this.transform;

         //   Color32 planetcolor = go.GetComponent<b_planet_Gravity>().planetColor;
          //  b_planet_DATA planetData = new b_planet_DATA(planetLocation, planetcolor, randompath, false);
          //  listOfMyPlanets.Add(planetData);
        }

        void BuildRightAmountOfSmallAndMedium() {
            int sizeofYlines = _planetLineY.Length;
            for (int cnt = 1; cnt < sizeofYlines; cnt++)
            {
                Make_Small_and_Medium(cnt);
            }
        }

        void Make_One_Large()
        {

            Vector3 centerOfQuad = new Vector3 (this.transform.position.x , this.transform.position.y, 0);

            int randomIndex = Random.Range(4, 6);//4 5  BIG 
            string randompath = _planetPaths[randomIndex];
            GameObject go = Instantiate(Resources.Load(randompath), centerOfQuad, Quaternion.identity) as GameObject;
            go.transform.parent = this.transform;

         //   Color32 planetcolor = go.GetComponent<b_planet_Gravity>().planetColor;
          //  b_planet_DATA planetData = new b_planet_DATA(centerOfQuad, planetcolor, randompath, false);
          //  listOfMyPlanets.Add(planetData);
        }


        void coinToss() {
            int buildBigInt = 50;
            int randomeCointoss = Random.Range(0, 100);

            if (buildBigInt == randomeCointoss) { Make_One_Large(); }
            else
                BuildRightAmountOfSmallAndMedium();

        }
    }
}
