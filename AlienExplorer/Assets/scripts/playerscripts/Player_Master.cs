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

        public delegate void PlayerHealthEventHandler(int healthChange);
        public event PlayerHealthEventHandler EventPlayerHealthDown;
        public event PlayerHealthEventHandler EventPlayerHealthUp;


        public delegate void PlayerRoversEventHandler();
        public event PlayerRoversEventHandler EventPlayerLostaRover;
        public event PlayerRoversEventHandler EventPlayerGainedaRover;
        public event PlayerRoversEventHandler EventCreateRover;
        public event PlayerRoversEventHandler EventGarageRover;


        public delegate void PlayerFuelEventHandler(int fuelDelta);
        public event PlayerFuelEventHandler EventPlayerFuelDown;
        public event PlayerFuelEventHandler EventPlayerFuelhUp;


        public bool isBeingPulled;

        //methods to call
        public void CALLEventInventoryChanged() { if (EventInventoryChanged != null) { EventInventoryChanged(); } }

        public void CALLEventAmmoChanged() { if (EventAmmoChanged != null) { EventAmmoChanged(); } }

        public void CALLEventPickedupAmmo(string ammoname, int quantity) { if (EventPickedupAmmo != null) { EventPickedupAmmo(ammoname, quantity); } }

        public void CALLEventPlayerHealthDown(int x) { if (EventPlayerHealthDown != null) { EventPlayerHealthDown(x); } }
        public void CALLEventPlayerHealthup(int x) { if (EventPlayerHealthUp != null) { EventPlayerHealthUp(x); } }


        public void CALLEventPlayerLostRover() { if (EventPlayerLostaRover != null) { EventPlayerLostaRover(); } }
        public void CALLEventPlayerGainedRover() { if (EventPlayerGainedaRover != null) { EventPlayerGainedaRover(); } }
        public void CALLEventCreateRover() { if (EventCreateRover != null) { EventCreateRover(); } }
        public void CALLEventGarageRover() { if (EventGarageRover != null) { EventGarageRover(); } }


        public void CALLEventPlayerFuelthDown(int x) { if (EventPlayerFuelDown != null) { EventPlayerFuelDown(x); } }
        public void CALLEventPlayerFuelthup(int x) { if (EventPlayerFuelhUp != null) { EventPlayerFuelhUp(x); } }

    }
}
