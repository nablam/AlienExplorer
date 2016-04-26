using UnityEngine;
using System.Collections;

namespace nabspace {
    public class SpaceMaster : MonoBehaviour
    {

        public delegate void EventManagerWhatSector(GameObject thissector);
        public event EventManagerWhatSector Iaminthissector;

        public void CAllHeyManIamCurr(GameObject thissector)
        {
            if (Iaminthissector != null)
            {
                Iaminthissector(thissector);
            }
        }
    }
}
