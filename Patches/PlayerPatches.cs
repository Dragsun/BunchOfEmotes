﻿using HarmonyLib;
using Reptile;
using System.IO;
using UnityEngine;
using static Reptile.Player;

namespace BunchOfEmotes.Patches
{
    // TODO Review __instance file and update to your own requirements, or remove it altogether if not required

    /// <summary>
    /// Sample Harmony Patch class. Suggestion is to use one file per patched class
    /// though you can include multiple patch classes in one file.
    /// Below is included as an example, and should be replaced by classes and methods
    /// for your mod.
    /// </summary>
    [HarmonyPatch(typeof(Player))]
    internal class PlayerPatches
    {
        [HarmonyPatch(nameof(Player.Init))]
        [HarmonyPrefix]
        public static bool Awake_Prefix(Player __instance)
        {
            if (BunchOfEmotesPlugin.player == null)
            {
                BunchOfEmotesPlugin.player = __instance;
            }
            return true;
        }

        [HarmonyPatch(nameof(Player.PlayAnim))]
        [HarmonyPostfix]
        public static void PlayAnim(Player __instance, bool instant)
        {
            int childcount = __instance.transform.GetChild(0).childCount;
            //BunchOfEmotesPlugin.Log.LogMessage("i am in init play anim");
            //if (__instance.moveStyle.ToString() == "ON_FOOT" && __instance.transform.GetChild(0).GetChild(childcount - 1).GetChild(0).GetComponent<Animator>().runtimeAnimatorController != BunchOfEmotesPlugin.myAnim2 && !BunchOfEmotesPlugin.inAnimation)
            //{
            //    //BunchOfEmotesPlugin.Log.LogMessage(__instance.moveStyle);
            //    //BunchOfEmotesPlugin.initEmotes();
            //    //__instance.transform.GetChild(0).GetChild(childcount - 1).GetChild(0).GetComponent<Animator>().runtimeAnimatorController = BunchOfEmotesPlugin.myAnim2;
            //}
            if (true)
            {
                
            }


            if (__instance.name != "Player_HUMAN0" && __instance.moveStyle.ToString() == "ON_FOOT" && __instance.transform.GetChild(0).GetChild(childcount - 1).GetChild(0).GetComponent<Animator>().runtimeAnimatorController != BunchOfEmotesPlugin.myAnim)
            {
                __instance.transform.GetChild(0).GetChild(childcount - 1).GetChild(0).GetComponent<Animator>().runtimeAnimatorController = BunchOfEmotesPlugin.myAnim;
                //__instance.InitAnimation();
                //__instance.InitAnimInfosTricking();
            }
        }
    }
}