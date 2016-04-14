using UnityEngine;
using System.Collections;


namespace nabspace {
    public class Player_Master : MonoBehaviour
    {

        public delegate void GeneralEventHandeler();
        public event GeneralEventHandeler EventInventoryChanged;
        public event GeneralEventHandeler EventAmmoChanged;

        public delegate void AmmoPickedupEventHandler(string ammoname, int quantity);
        public event AmmoPickedupEventHandler EventPickedupAmmo;

        public delegate void PlayerHealthEventHAndler(int healthChange);
        public event PlayerHealthEventHAndler EventPlayerHEalthDown;
        public event PlayerHealthEventHAndler EventPlayerHEalthUp;


        public delegate void PlayerRoversEventHandler();
        public event PlayerRoversEventHandler EventPlayerLostaRover;
        public event PlayerRoversEventHandler EventPlayerGainedaRover;
        public event PlayerRoversEventHandler EventCreateRover;
        public event PlayerRoversEventHandler EventGarageRover;




        //methods to call
        public void CALLEventInventoryChanged() { if (EventInventoryChanged != null) { EventInventoryChanged(); } }

        public void CALLEventAmmoChanged() { if (EventAmmoChanged != null) { EventAmmoChanged(); } }

        public void CALLEventPickedupAmmo(string ammoname, int quantity) { if (EventPickedupAmmo != null) { EventPickedupAmmo(ammoname, quantity); } }

        public void CALLEventPlayerHealthDown(int x) { if (EventPlayerHEalthDown != null) { EventPlayerHEalthDown(x); } }
        public void CALLEventPlayerHealthup(int x) { if (EventPlayerHEalthUp != null) { EventPlayerHEalthUp(x); } }


        public void CALLEventPlayerLostRover() { if (EventPlayerLostaRover != null) { EventPlayerLostaRover(); } }
        public void CALLEventPlayerGainedRover() { if (EventPlayerGainedaRover != null) { EventPlayerGainedaRover(); } }
        public void CALLEventCreateRover() { if (EventCreateRover != null) { EventCreateRover(); } }
        public void CALLEventGarageRover() { if (EventGarageRover != null) { EventGarageRover(); } }
    }
}
