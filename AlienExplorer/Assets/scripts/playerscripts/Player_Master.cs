﻿using UnityEngine;
using System.Collections;


namespace S3 {
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

        //methods to call
        public void CALLEventInventoryChanged() { if (EventInventoryChanged != null) { EventInventoryChanged(); } }

        public void CALLEventAmmoChanged() { if (EventAmmoChanged != null) { EventAmmoChanged(); } }

        public void CALLEventPickedupAmmo(string ammoname, int quantity) { if (EventPickedupAmmo != null) { EventPickedupAmmo(ammoname, quantity); } }

        public void CALLEventPlayerHealthDown(int x) { if (EventPlayerHEalthDown != null) { EventPlayerHEalthDown(x); } }
        public void CALLEventPlayerHealthup(int x) { if (EventPlayerHEalthUp != null) { EventPlayerHEalthUp(x); } }

    }
}