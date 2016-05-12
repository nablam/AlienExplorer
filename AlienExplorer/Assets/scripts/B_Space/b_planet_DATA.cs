using UnityEngine;
using System.Collections;

namespace nabspace {
    public class b_planet_DATA
    {
        public Vector3 planetLocation;
        public Color32 planetColor;
        public string planetName_path;
        public bool planetHasBeenExplored;

        public b_planet_DATA(Vector3 pos, Color32 colr, string namep, bool exp) {
            planetLocation= pos;
            planetColor= colr;
            planetName_path = namep;
            planetHasBeenExplored= exp;
         }
    }
}
