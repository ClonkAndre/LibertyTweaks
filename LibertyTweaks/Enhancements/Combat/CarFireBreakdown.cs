﻿using CCL.GTAIV;
using IVSDKDotNet;
using static IVSDKDotNet.Native.Natives;

// Credit: catsmackaroo

namespace LibertyTweaks
{
    internal class CarFireBreakdown
    {
        private static bool enable;

        public static void Init(SettingsFile settings)
        {
            enable = settings.GetBoolean("Vehicles Break on Fire", "Enable", true);

            if (enable)
                Main.Log("script initialized...");
        }

        public static void Tick()
        {
            if (!enable)
                return;

            if (IS_CHAR_IN_ANY_CAR(Main.PlayerPed.GetHandle()))
            {
                GET_CAR_CHAR_IS_USING(Main.PlayerPed.GetHandle(), out int pVeh); 

                if (IS_CAR_ON_FIRE(pVeh))
                {
                    SET_CAR_ENGINE_ON(pVeh, false, false);
                }
            }

        }
    }
}

