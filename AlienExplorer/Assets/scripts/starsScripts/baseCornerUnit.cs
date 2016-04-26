using UnityEngine;
using System.Collections;


namespace nabspace {
    public class baseCornerUnitc
    {
        public float farleft;
        public float farright;
        public float fartop;
        public float farbot;
        public float centerx;
        public float centery;
        public bool visited;

        public baseCornerUnitc right;
        public baseCornerUnitc left;
        public baseCornerUnitc up;
        public baseCornerUnitc down;

        public baseCornerUnitc(float l, float r, float t, float b,float x, float y, bool v) { farleft = l;  farright = r;  fartop = t; farbot = b; visited = v; centerx = x;  centery = y; }

    }
}
