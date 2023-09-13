﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using IVSDKDotNet;

using CCL.GTAIV;
using IVSDKDotNet.Native;
using static IVSDKDotNet.Native.Natives;
using LibertyTweaks;

// Speech IDs to utilize:
// SHOOT, KILLED_ALL, STAY_DOWN, ATTACK_ANY_GANGSTER, CHASED, CRASH_GENERIC, GENERIC_CURSE, GENERIC_INSULT, HURRY_UP, IN_COVER_DODGE_BULLETS, JACKED_CAR
// 
// During specific scenarios:
// IN CAR: TAXI_STEP_ON_IT, CAR_HIT_PED, CRASH_CAR, CRASH_GENERIC, HURRY_UP
// NEAR CORPSES: SEARCH_BODY_TAKE_ITEM  
// HIGH WANTED: ARRESTED, JACKED_CAR
// HIT: FUCK_FALL

namespace ImprovedDialogue.CombatVoices
{
    internal class MoreCombatLines
    {

        private static bool enableFix;
        public static void Init(SettingsFile settings)
        {
            enableFix = settings.GetBoolean("Main", "More Combat Lines", true);
        }
        public static void Tick()
        {
            int playerId;
            bool pCombat;
            uint pHealth;

            CPed playerPed = CPed.FromPointer(CPlayerInfo.FindPlayerPed());
            playerId = CPedExtensions.GetHandle(playerPed);

            pCombat = Natives.IS_CHAR_SHOOTING(playerPed.GetHandle());
            if (pCombat == true)
            {
                switch (Main.GenerateRandomNumber(0, 150))
                {
                    case 0:
                        playerPed.SayAmbientSpeech("IN_COVER_DODGE_BULLETS");
                        //CGame.ShowSubtitleMessage("IN COVER DODGE BULLET", 3000);
                        break;

                    case 1:
                        playerPed.SayAmbientSpeech("SHOOT");
                        //CGame.ShowSubtitleMessage("SHOOT", 3000);
                        break;

                    case 2:
                        playerPed.SayAmbientSpeech("KILLED_ALL");
                        //CGame.ShowSubtitleMessage("KILLED_ALL", 3000);
                        break;

                    case 3:
                        playerPed.SayAmbientSpeech("CHASED");
                        //CGame.ShowSubtitleMessage("CHASED", 3000);
                        break;

                    case 4:
                        playerPed.SayAmbientSpeech("GENERIC_INSULT");
                        //CGame.ShowSubtitleMessage("GENERIC_INSULT", 3000);
                        break;

                    case 5:
                        playerPed.SayAmbientSpeech("FIGHT");
                        //CGame.ShowSubtitleMessage("FIGHT", 3000);
                        break;

                    case 6:
                        playerPed.SayAmbientSpeech("STAY_DOWN");
                        //CGame.ShowSubtitleMessage("STAY_DOWN", 3000);
                        break;

                    case 7:
                        playerPed.SayAmbientSpeech("PULL_GUN");
                        //CGame.ShowSubtitleMessage("PULL GUN");
                        break;

                    default:
                        break;
                }
                //ShowSubtitleMessage("True");
            }
            else
            {
                //ShowSubtitleMessage("False");
            }
        }
    }
}