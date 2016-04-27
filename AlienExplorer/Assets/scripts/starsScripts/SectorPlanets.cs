using UnityEngine;
using System.Collections;

public class SectorPlanets : MonoBehaviour {

    public bool iscentertile;

    public float curMinX;
    public float curmaxX;
    public float curMinY;
    public float curmaxY;

    int HowmanyRows;
    int distanceBetweenRows;

    float[] planetLineY;

    string[] planetPaths;
    void Awake()
    {
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
            int sizeofYlines = planetLineY.Length;
            for (int cnt = 0; cnt < sizeofYlines; cnt++)
            {
                makerandStarHere(cnt);
            }
        }

    }

    void OnDisable()
    {

    }

    void SetInitialReferences()
    {
        calculateLocalbounds();
        buildArrayOfYvalues();
        builsArrayOfPlanetPaths();
        //for (int x = 0; x < howmanystars; x++)
        //{

        //    makerandStarHere(getrandX(), getrandY());
        //}
    }



    void calculateLocalbounds()
    {
        float _sizeofQuad = transform.localScale.x;
        curMinX = transform.position.x - (_sizeofQuad / 2) + 100;
        curmaxX = transform.position.x + (_sizeofQuad / 2);
        curMinY = transform.position.y - (_sizeofQuad / 2);
        curmaxY = transform.position.y + (_sizeofQuad / 2);        
    }

    void buildArrayOfYvalues() {
        float _sizeofQuad = transform.localScale.x;
        HowmanyRows = ((int)_sizeofQuad / 1000) * 4;
        distanceBetweenRows = (int)_sizeofQuad / HowmanyRows;
        planetLineY = new float[HowmanyRows];

        float baseline = 0;
        for (int cnt = 0; cnt < HowmanyRows; cnt++) {
            planetLineY[cnt] = curMinY + baseline;
            baseline = baseline + distanceBetweenRows;
        }
    }

    void builsArrayOfPlanetPaths() {
        //mars20_128_64
        planetPaths = new string[6];
        planetPaths[0] = "planets/mars20_128_64";
        planetPaths[1] = "planets/mars100_128_64";
        planetPaths[2] = "planets/mars200_128_64";
        planetPaths[3] = "planets/moon20_128_64";
        planetPaths[4] = "planets/moon100_128_64";
        planetPaths[5] = "planets/moon100_128_64";

    }

    float getrandX()
    {
        float x = Random.Range(curMinX, curmaxX);
        return x;
    }
 

    void makerandStarHere(  int yindex)
    {

        float theyline = planetLineY[yindex];
        int randomIndex = Random.Range(0, 6);//0 1 2 3 4 5 
        string randompath = planetPaths[randomIndex];
        Instantiate(Resources.Load(randompath), new Vector3(getrandX(), theyline, 0f), Quaternion.identity);
    }


}
