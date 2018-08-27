using IllusionPlugin;
using HMUI;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using VRUI;
using System.Media;

namespace SaberToggle {
    public class Plugin : IPlugin {

        private static int[] targetGameSceneIndex = new int[] { 9, 10, 11 };

        public static bool isTargetSceneIndex(int a) {
            for (int i = 0; i < targetGameSceneIndex.Length; i++) {
                if (targetGameSceneIndex[i] == a) return true;
            }
            return false;
        }

        //These variables can be edited in the ModPrefs ini file.
        //While in-game, press Backslash while in the main menu to reload the config to apply any changes.
        //You will hear a sound upon pressing Backslash to verify that the load was successful.

        //ALL THESE FEATURES ONLY WORK IN PARTY MODE

        //This is ChromaToggle's main feature.
        //With this enabled, you can switch the colour of your sabers by holding the key.
        public static bool enableSaberToggle = false;

        //Alternate toggle makes your left saber default to blue, and toggle red while holding the trigger.
        //This makes both sabers act the same.  This is generally easier to comprehend, and easier to play.
        public static bool alternateToggle = true;

        //If enabled, pressing the trigger will permanently toggle the saber, and releasing the trigger will do nothing.
        //This means you must press the trigger a second time to return the saber back to its original state.
        public static bool permanentToggle = false;

        //Forces all blocks to the same colour.  This is useful for one saber mode.
        public static bool enableOneColorMode = false;

        //If this is disabled, double hits detected will have blocks removed until they are made into single hits.
        //THIS IS NOT CURRENTLY IMPLEMENTED
        public static bool enableDoubleHits = true;

        //If enabled, double hits are forced into being the same colour.
        //This solves randomization problems on maps with, for example, three-long double wide hits, or four-long single wide hits.
        public static bool enableMonoDoubles = false;

        //If enabled, all blocks will be turned to dots!
        public static bool enableAllDots = false;

        //If enabled, this forces all double hits to be replaced with dots.
        public static bool enableDotDoubles = false;

        //This is the randomization feature of no-arrows mode, but you can force enable it on arrow maps.
        public static bool enableColourRand = false;

        public static bool enableDarthMaul = false;
        public static bool doubleDarthMaul = false;

        public static bool enableMantisStyle = false;

        //This makes it use the oculus X/Y buttons instead of the trigger
        public static bool useOculusButton = false;

        /* CURRENT BUGS
        - No matter which hand each saber is in, hits with a blue saber will trigger haptics in the right hand, and hits with red saber will trigger left haptics.
        - enableDoubleHits does NUSSING no matter which mode it's in
        */

        public static bool ScoreSubmissionAllowed {
            get {
                if (enableOneColorMode || enableSaberToggle || !enableDoubleHits || enableColourRand) return false;
                return true;
            }
        }

        public void OnUpdate() {
            if (Input.GetKeyDown(KeyCode.KeypadMultiply)) WriteConsoleMessage("Scene Index: "+sceneIndex+" Scene Title:"+SceneManager.GetActiveScene().name);
            if (Input.GetKeyDown(KeyCode.Backslash) && !isTargetSceneIndex(sceneIndex)) { LoadSettings(); Plugin.PlayAudio(); }
            /*if (Input.GetKeyDown(KeyCode.O) && sceneIndex != 5) { enableOneColorMode    = !enableOneColorMode; SaveSettings(); }
            if (Input.GetKeyDown(KeyCode.T) && sceneIndex != 5) { WriteSettings(); }
            if (Input.GetKeyDown(KeyCode.A) && sceneIndex != 5) { alternateToggle       = !alternateToggle; SaveSettings(); }
            if (Input.GetKeyDown(KeyCode.H) && sceneIndex != 5) { enableHeldToggle      = !enableHeldToggle; SaveSettings(); }
            if (Input.GetKeyDown(KeyCode.D) && sceneIndex != 5) { enableDoubleHits      = !enableDoubleHits; SaveSettings(); }
            if (Input.GetKeyDown(KeyCode.V) && sceneIndex != 5) { enableMonoDoubles     = !enableMonoDoubles; SaveSettings(); }
            if (Input.GetKeyDown(KeyCode.J) && sceneIndex != 5) { enableDotDoubles      = !enableDotDoubles; SaveSettings(); }
            if (Input.GetKeyDown(KeyCode.C) && sceneIndex != 5) { enableColourRand      = !enableColourRand; SaveSettings(); }*/
        }

        public string Name => "ChromaToggle";
        public string Version => "0.0.1";

        private bool _init = false;
        private int sceneIndex = -1;

        private ChromaToggleBehaviour behaviour;

        public void OnApplicationStart() {
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private void SceneManagerOnActiveSceneChanged(Scene from, Scene scene) {
            this.sceneIndex = scene.buildIndex;
        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1) {

        }

        public void OnApplicationQuit() {
            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }

        public void OnLevelWasLoaded(int level) {
            if (_init) return;
            _init = true;
            /*if (!ModPrefs.HasKey("ChromaToggle", "enableOneColorMode")) {
                Plugin.WriteConsoleMessage("No settings found!  Writing...");
                WriteSettings();
            }*/
            LoadSettings();
            SaveSettings();
            behaviour = new GameObject("SaberTogglePlugin").AddComponent<ChromaToggleBehaviour>();
        }

        public void LoadSettings() {
            enableOneColorMode = ModPrefs.GetBool("ChromaToggle", "enableOneColorMode", false);
            enableSaberToggle = ModPrefs.GetBool("ChromaToggle", "enableSaberToggle", false);
            alternateToggle = ModPrefs.GetBool("ChromaToggle", "alternateToggle", false);
            permanentToggle = ModPrefs.GetBool("ChromaToggle", "permanentToggle", false);
            enableDoubleHits = ModPrefs.GetBool("ChromaToggle", "enableDoubleHits", true);
            enableMonoDoubles = ModPrefs.GetBool("ChromaToggle", "enableMonoDoubles", false);
            enableAllDots = ModPrefs.GetBool("ChromaToggle", "enableAllDots", false);
            enableDotDoubles = ModPrefs.GetBool("ChromaToggle", "enableDotDoubles", false);
            enableColourRand = ModPrefs.GetBool("ChromaToggle", "enableColourRand", false);
            enableDarthMaul = ModPrefs.GetBool("ChromaToggle", "enableDarthMaul", false);
            doubleDarthMaul = ModPrefs.GetBool("ChromaToggle", "doubleDarthMaul", false);
            enableMantisStyle = ModPrefs.GetBool("ChromaToggle", "enableMantisStyle", false);
            useOculusButton = ModPrefs.GetBool("ChromaToggle", "useOculusButton", false);
        }

        public void SaveSettings() {
            ModPrefs.SetBool("ChromaToggle", "enableOneColorMode", enableOneColorMode);
            ModPrefs.SetBool("ChromaToggle", "enableSaberToggle", enableSaberToggle);
            ModPrefs.SetBool("ChromaToggle", "alternateToggle", alternateToggle);
            ModPrefs.SetBool("ChromaToggle", "permanentToggle", permanentToggle);
            ModPrefs.SetBool("ChromaToggle", "enableDoubleHits", enableDoubleHits);
            ModPrefs.SetBool("ChromaToggle", "enableMonoDoubles", enableMonoDoubles);
            ModPrefs.SetBool("ChromaToggle", "enableAllDots", enableAllDots);
            ModPrefs.SetBool("ChromaToggle", "enableDotDoubles", enableDotDoubles);
            ModPrefs.SetBool("ChromaToggle", "enableColourRand", enableColourRand);
            ModPrefs.SetBool("ChromaToggle", "enableDarthMaul", enableDarthMaul);
            ModPrefs.SetBool("ChromaToggle", "doubleDarthMaul", doubleDarthMaul);
            ModPrefs.SetBool("ChromaToggle", "enableMantisStyle", enableMantisStyle);
            ModPrefs.SetBool("ChromaToggle", "useOculusButton", useOculusButton);
        }

        /*public void WriteSettings() {
            Plugin.WriteConsoleMessage("Writing settings...");
            ModPrefs.SetBool("ChromaToggle", "enableOneColorMode", false);
            ModPrefs.SetBool("ChromaToggle", "enableSaberToggle", false);
            ModPrefs.SetBool("ChromaToggle", "alternateToggle", true);
            ModPrefs.SetBool("ChromaToggle", "enableHeldToggle", false);
            ModPrefs.SetBool("ChromaToggle", "enableDoubleHits", true);
            ModPrefs.SetBool("ChromaToggle", "enableMonoDoubles", false);
            ModPrefs.SetBool("ChromaToggle", "enableDotDoubles", false);
            ModPrefs.SetBool("ChromaToggle", "enableColourRand", false);
        }*/

        public static void WriteConsoleMessage(String message) {
            Console.WriteLine("[ChromaToggle] " + message);
        }

        public static void PlayAudio() {
            SoundPlayer audio = new SoundPlayer(SaberToggle.Properties.Resources.ptt_stop);
            audio.Play();
        }

        public void OnLevelWasInitialized(int level) {

        }

        public void OnFixedUpdate() {

        }
    }
}
