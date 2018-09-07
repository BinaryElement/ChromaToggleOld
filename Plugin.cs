using IllusionPlugin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChromaToggle {

    public class Plugin : IPlugin {

        private static int[] targetGameSceneIndexes = new int[] { 8, 9, 10, 11 };

        public static bool IsTargetGameScene(Scene scene) {
            return IsTargetGameScene(scene.buildIndex);
        }

        public static bool IsTargetGameScene(int a) {
            for (int i = 0; i < targetGameSceneIndexes.Length; i++) {
                if (targetGameSceneIndexes[i] == a) return true;
            }
            return false;
        }

        public string Name => "ChromaToggle";
        public string Version => "0.2.0";

        #region CONFIG
        //************************
        //**** CONFIG OPTIONS ****
        //************************

        public static bool enableSaberToggle = false;
        public static bool alternateToggle = false;
        public static bool permanentToggle = false;

        public static bool enableOneColorMode = false;
        public static bool invertColorMode = false;
        public static bool mirrorPosition = false;
        public static bool mirrorDirection = false;

        public static bool removeDoubleHits = false;
        public static bool enableMonoDoubles = false;
        public static bool enableDotDoubles = false;

        public static bool enableAllDots = false;
        public static int randomizationStyle = 0; //0 = None, 1 = Original, 2 = Chroma, 3 = Intense, 4 = True

        public static bool randomDots = false;
        public static bool randomMirror = false;
        public static bool randomMirrorDirection = false;
        public static bool randomMirrorPosition = false;

        public static bool randomSabers = false; //SECRET OPTION
        public static bool nightmare = false; //SECRET OPTION

        public static bool enableDarthMaul = false;
        public static bool alternateLeftMaul = false;

        public static bool forceSingleSaber = false;

        public static bool enableMantisStyle = false;
        public static float darthMantisOffset = 0.25f;

        public static bool isOculus = false;

        public static bool debugMode = false;

        public static void LoadSettings() {
            enableSaberToggle = ModPrefs.GetBool("ChromaToggle", "enableSaberToggle", false);
            alternateToggle = ModPrefs.GetBool("ChromaToggle", "alternateToggle", false);
            permanentToggle = ModPrefs.GetBool("ChromaToggle", "permanentToggle", false);

            enableOneColorMode = ModPrefs.GetBool("ChromaToggle", "enableOneColorMode", false);
            invertColorMode = ModPrefs.GetBool("ChromaToggle", "invertColorMode", false);
            mirrorPosition = ModPrefs.GetBool("ChromaToggle", "mirrorPosition", false);
            mirrorDirection = ModPrefs.GetBool("ChromaToggle", "mirrorDirection", false);

            removeDoubleHits = ModPrefs.GetBool("ChromaToggle", "removeDoubleHits", false);
            enableMonoDoubles = ModPrefs.GetBool("ChromaToggle", "enableMonoDoubles", false);
            enableDotDoubles = ModPrefs.GetBool("ChromaToggle", "enableDotDoubles", false);

            enableAllDots = ModPrefs.GetBool("ChromaToggle", "enableAllDots", false);
            randomizationStyle = ModPrefs.GetInt("ChromaToggle", "randomizationStyle", randomizationStyle);

            randomDots = ModPrefs.GetBool("ChromaToggle", "randomDots", false);
            randomMirror = ModPrefs.GetBool("ChromaToggle", "randomMirror", false);
            randomMirrorDirection = ModPrefs.GetBool("ChromaToggle", "randomMirrorDirection", false);
            randomMirrorPosition = ModPrefs.GetBool("ChromaToggle", "randomMirrorPosition", false);
            randomSabers = ModPrefs.GetBool("ChromaToggle", "randomSabers", false);

            enableDarthMaul = ModPrefs.GetBool("ChromaToggle", "enableDarthMaul", false);
            alternateLeftMaul = ModPrefs.GetBool("ChromaToggle", "alternateLeftMaul", false);

            forceSingleSaber = ModPrefs.GetBool("ChromaToggle", "forceSingleSaber", false);

            enableMantisStyle = ModPrefs.GetBool("ChromaToggle", "enableMantisStyle", false);
            darthMantisOffset = ModPrefs.GetFloat("ChromaToggle", "darthMantisOffset", 0.25f);

            debugMode = ModPrefs.GetBool("ChromaToggle", "debugMode", false);

            Log("ChromaToggle settings successfully loaded!");
            if (Plugin.debugMode) Plugin.PlayOtherSound(Resources.AudioResources.ChromaToggle_Loaded);
        }

        public static void SaveSettings() {
            ModPrefs.SetBool("ChromaToggle", "enableSaberToggle", enableSaberToggle);
            ModPrefs.SetBool("ChromaToggle", "alternateToggle", alternateToggle);
            ModPrefs.SetBool("ChromaToggle", "permanentToggle", permanentToggle);

            ModPrefs.SetBool("ChromaToggle", "enableOneColorMode", enableOneColorMode);
            ModPrefs.SetBool("ChromaToggle", "invertColorMode", invertColorMode);
            ModPrefs.SetBool("ChromaToggle", "mirrorPosition", mirrorPosition);
            ModPrefs.SetBool("ChromaToggle", "mirrorDirection", mirrorDirection);

            //ModPrefs.SetBool("ChromaToggle", "removeDoubleHits", removeDoubleHits);
            ModPrefs.SetBool("ChromaToggle", "enableMonoDoubles", enableMonoDoubles);
            ModPrefs.SetBool("ChromaToggle", "enableDotDoubles", enableDotDoubles);

            ModPrefs.SetBool("ChromaToggle", "enableAllDots", enableAllDots);
            ModPrefs.SetFloat("ChromaToggle", "randomizationStyle", randomizationStyle);

            ModPrefs.SetBool("ChromaToggle", "randomDots", randomDots);
            ModPrefs.SetBool("ChromaToggle", "randomMirror", randomMirror);
            ModPrefs.SetBool("ChromaToggle", "randomMirrorDirection", randomMirrorDirection);
            ModPrefs.SetBool("ChromaToggle", "randomMirrorPosition", randomMirrorPosition);

            ModPrefs.SetBool("ChromaToggle", "enableDarthMaul", enableDarthMaul);
            ModPrefs.SetBool("ChromaToggle", "alternateLeftMaul", alternateLeftMaul);

            ModPrefs.SetBool("ChromaToggle", "forceSingleSaber", forceSingleSaber);

            ModPrefs.SetBool("ChromaToggle", "enableMantisStyle", enableMantisStyle);
            ModPrefs.SetFloat("ChromaToggle", "darthMantisOffset", darthMantisOffset);

            ModPrefs.SetBool("ChromaToggle", "debugMode", debugMode);
        }

        #endregion

        //***************
        //**** LOGIC ****
        //***************

        private AsyncScenesLoader loader;
        LeaderboardHook lHook;

        public void OnApplicationStart() {
            LoadSettings();
            SaveSettings();

            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;

            //lHook = new GameObject("LeaderboardHook").AddComponent<LeaderboardHook>();
        }

        private void SceneManagerOnActiveSceneChanged(Scene current, Scene next) {
            ChromaBehaviour.ClearInstance();
        }

        private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode mode) {

            if (scene.name == "Menu") {
                ChromaBehaviour.ClearInstance();
            } else if (scene.name == "StandardLevelLoader") {
                if (!loader) loader = UnityEngine.Resources.FindObjectsOfTypeAll<AsyncScenesLoader>().FirstOrDefault();
                loader.loadingDidFinishEvent += OnLoadingDidFinishGame;
            }
        }

        private void OnLoadingDidFinishGame() {

            List<ChromaMode> modes = new List<ChromaMode>();
            if (enableSaberToggle) modes.Add(ChromaMode.CHROMATOGGLE);
            if (alternateToggle) modes.Add(ChromaMode.CHROMATOGGLE_ALT);
            if (permanentToggle) modes.Add(ChromaMode.CHROMATOGGLE_PERM);
            if (enableOneColorMode) modes.Add(ChromaMode.MONOCHROME);
            if (invertColorMode) modes.Add(ChromaMode.INVERT_COLOUR);
            if (mirrorDirection) modes.Add(ChromaMode.MIRROR_DIRECTION);
            if (mirrorPosition) modes.Add(ChromaMode.MIRROR_POSITION);
            if (removeDoubleHits) modes.Add(ChromaMode.DOUBLES_REMOVED);
            if (enableMonoDoubles) modes.Add(ChromaMode.DOUBLES_MONO);
            if (enableDotDoubles) modes.Add(ChromaMode.DOUBLES_DOTS);
            if (enableAllDots) modes.Add(ChromaMode.NO_ARROWS);
            if (enableDarthMaul) modes.Add(ChromaMode.DARTH_MAUL);
            if (alternateLeftMaul) modes.Add(ChromaMode.DARTH_ALT_LEFT);
            if (forceSingleSaber) modes.Add(ChromaMode.SINGLE_SABER);

            if (randomizationStyle == 1) modes.Add(ChromaMode.RANDOM_COLOURS_ORIGINAL);
            else if (randomizationStyle == 2) modes.Add(ChromaMode.RANDOM_COLOURS_CHROMA);
            else if (randomizationStyle == 3) modes.Add(ChromaMode.RANDOM_COLOURS_INTENSE);
            else if (randomizationStyle == 4) modes.Add(ChromaMode.RANDOM_COLOURS_TRUE);

            if (randomDots) modes.Add(ChromaMode.RANDOM_DOTS);
            if (randomMirror) modes.Add(ChromaMode.RANDOM_DOTS);
            if (randomMirrorDirection) modes.Add(ChromaMode.RANDOM_MIRROR_DIRECTION);
            if (randomMirrorPosition) modes.Add(ChromaMode.RANDOM_MIRROR_POSITION);

            if (randomSabers) modes.Add(ChromaMode.RANDOM_SABERS); //Numpad divide

            if (nightmare) { //numpad multiply
                modes = new List<ChromaMode>() { ChromaMode.CHROMATOGGLE, ChromaMode.RANDOM_DOTS, ChromaMode.RANDOM_MIRROR, ChromaMode.RANDOM_MIRROR_DIRECTION, ChromaMode.RANDOM_MIRROR_POSITION, ChromaMode.RANDOM_SABERS };
            }

            if (enableMantisStyle) modes.Add(ChromaMode.MANTIS);

            ChromaBehaviour.CreateNewInstance(modes.ToArray());
        }

        public void OnApplicationQuit() {
            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }

        public void OnLevelWasLoaded(int level) {
            //Donut use
        }

        public void OnLevelWasInitialized(int level) {
            //Donut use
        }

        public void OnUpdate() {
            if ((Input.GetKeyDown(KeyCode.Backslash) || Input.GetKeyUp(KeyCode.JoystickButton0)) && !IsTargetGameScene(SceneManager.GetActiveScene())) {
                PlayReloadSound();
                LoadSettings();
            }

            if (Input.GetKeyDown(KeyCode.KeypadPlus)) {
                Plugin.Log("Leaderboard: " + ChromaBehaviour.customBoard + " ("+ChromaBehaviour.GetCustomBoardName()+")");
            }

            if (Input.GetKeyDown(KeyCode.KeypadMultiply)) ToggleNightmare();
            if (Input.GetKeyDown(KeyCode.KeypadDivide)) ToggleRandomSabers();
        }

        private void ToggleNightmare() {
            nightmare = !nightmare;
            PlayOtherSound(nightmare ? Resources.AudioResources.NightmareMode : Resources.AudioResources.NormalWeaklingMode);
        }

        private void ToggleRandomSabers() {
            randomSabers = !randomSabers;
            PlayOtherSound(randomSabers ? Resources.AudioResources.RandomSabersEnabled : Resources.AudioResources.RandomSabersDisabled);
        }

        public void OnFixedUpdate() {

        }

        //*****************
        //**** CONSOLE ****
        //*****************

        public static void Log(string message) {
            Log(message, debugMode);
        }

        public static void Log(string message, bool writtenLog) {
            Console.WriteLine("[ChromaToggle] " + message);
        }

        //**********************
        //*** SOUND EFFECTS ****
        //**********************

        private static SoundPlayer reloadBeep = new SoundPlayer(ChromaToggle.Resources.AudioResources.config_reload);

        public static void PlayReloadSound() {
            reloadBeep.Play();
        }

        public static void PlayOtherSound(System.IO.Stream stream) {
            SoundPlayer player = new SoundPlayer(stream);
            player.Play();
        }
        /*    player.LoadCompleted += OtherPlayerLoaded;
            player.LoadAsync();
        }

        private static void OtherPlayerLoaded(object sender, AsyncCompletedEventArgs args) {
            SoundPlayer player = (SoundPlayer)sender;
            player.Play();
            player.LoadCompleted -= OtherPlayerLoaded;
            player.Dispose();
        }*/

    }

}
