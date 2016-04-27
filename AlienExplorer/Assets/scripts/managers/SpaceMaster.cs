using UnityEngine;
using System.Collections;

namespace nabspace {
    public class SpaceMaster : MonoBehaviour
    {

        public delegate void EventManagerWhatSector(GameObject thissector);
        public event EventManagerWhatSector IhaveBeenCreated;

        public void CAllThisSectorWasCreated(GameObject thissector)
        {
            if (IhaveBeenCreated != null)
            {
                IhaveBeenCreated(thissector);
            }
        }
    }
}
