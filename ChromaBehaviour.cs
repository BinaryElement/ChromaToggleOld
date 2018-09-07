using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChromaToggle {

    class ChromaBehaviour : MonoBehaviour {

        public enum CustomBoard {
            NONE,
            CHROMATOGGLE,
            FORCED_SINGLE_SABER,
            NIGHTMARE,
            RANDOM_ARROWS,
            SINGLE_SABER_CHROMATOGGLE,
        }

        private static ChromaBehaviour _instance = null;

        public static void ClearInstance() {
            if (_instance != null) {
                Destroy(_instance.gameObject);
                _instance = null;
            }
        }

        public static ChromaBehaviour CreateNewInstance(params ChromaMode[] modes) {
            ClearInstance();
            if (Plugin.IsTargetGameScene(SceneManager.GetActiveScene().buildIndex)) {
                GameObject instanceObject = new GameObject("ChromaBehaviour");
                ChromaBehaviour behaviour = instanceObject.AddComponent<ChromaBehaviour>();
                behaviour.modes = modes;
                return behaviour;
            } else return null;
        }

        public static string GetCustomBoardName() {
            switch (customBoard) {
                case CustomBoard.CHROMATOGGLE:
                    return "ChromaToggle";
                case CustomBoard.FORCED_SINGLE_SABER:
                    return "Forced Single Saber";
                case CustomBoard.NIGHTMARE:
                    return "Chroma Nightmare";
                case CustomBoard.RANDOM_ARROWS:
                    return "Chroma Random Arrows";
                case CustomBoard.SINGLE_SABER_CHROMATOGGLE:
                    return "Chroma Single Saber";
            }
            return "";
        }

        private bool toggleActive = false;

        private PlayerController _playerController;

        private ChromaMode[] modes = new ChromaMode[0];
        public static CustomBoard customBoard = CustomBoard.NONE;

        ChromaMode[] GetModes(bool partyMode, bool chromaSong) {
            if (partyMode) return modes;
            
            else {
                if (modes.Contains(ChromaMode.NIGHTMARE)) {
                    customBoard = CustomBoard.NIGHTMARE;
                    return modes;
                } if (modes.Contains(ChromaMode.CHROMATOGGLE)) {
                    List<ChromaMode> newModes = new List<ChromaMode>() { ChromaMode.CHROMATOGGLE, ChromaMode.DOUBLES_DOTS, ChromaMode.RANDOM_COLOURS_CHROMA };
                    if (modes.Contains(ChromaMode.MANTIS)) newModes.Add(ChromaMode.MANTIS);
                    if (modes.Contains(ChromaMode.CHROMATOGGLE_ALT)) newModes.Add(ChromaMode.CHROMATOGGLE_ALT);
                    if (modes.Contains(ChromaMode.CHROMATOGGLE_PERM)) newModes.Add(ChromaMode.CHROMATOGGLE_PERM);
                    if (modes.Contains(ChromaMode.SINGLE_SABER)) {
                        newModes.Add(ChromaMode.SINGLE_SABER);
                        newModes.Add(ChromaMode.DOUBLES_MONO);
                        customBoard = CustomBoard.SINGLE_SABER_CHROMATOGGLE;
                    } else customBoard = CustomBoard.CHROMATOGGLE;
                    return newModes.ToArray();
                } else if (modes.Contains(ChromaMode.SINGLE_SABER)) {
                    List<ChromaMode> newModes = new List<ChromaMode>() { ChromaMode.SINGLE_SABER, ChromaMode.DOUBLES_DOTS, ChromaMode.MONOCHROME };
                    if (modes.Contains(ChromaMode.MANTIS)) newModes.Add(ChromaMode.MANTIS);
                    if (modes.Contains(ChromaMode.DOUBLES_MONO)) newModes.Add(ChromaMode.DOUBLES_MONO);
                    if (modes.Contains(ChromaMode.INVERT_COLOUR)) newModes.Add(ChromaMode.INVERT_COLOUR);
                    customBoard = CustomBoard.FORCED_SINGLE_SABER;
                    return newModes.ToArray();
                } else if (modes.Contains(ChromaMode.RANDOM_COLOURS_ORIGINAL)) {
                    List<ChromaMode> newModes = new List<ChromaMode>() { ChromaMode.RANDOM_COLOURS_ORIGINAL };
                    if (modes.Contains(ChromaMode.MANTIS)) newModes.Add(ChromaMode.MANTIS);
                    customBoard = CustomBoard.RANDOM_ARROWS;
                    return newModes.ToArray();
                }

                /*if (modes.Length == 1) {
                    if (modes[0] == ChromaMode.CHROMATOGGLE) {
                        board = CustomBoard.CHROMATOGGLE;
                        return chromaSong ? new ChromaMode[] { ChromaMode.CHROMATOGGLE, ChromaMode.DOUBLES_DOTS, ChromaMode.RANDOM_COLOURS_CHROMA } : new ChromaMode[0];
                    } else if (modes[0] == ChromaMode.SINGLE_SABER) {
                        board = CustomBoard.FORCED_SINGLE_SABER;
                        return new ChromaMode[] { ChromaMode.SINGLE_SABER, ChromaMode.DOUBLES_DOTS, ChromaMode.MONOCHROME };
                    }
                }*/
            }
            return StandardModes();
        }

        ChromaMode[] StandardModes() {
            customBoard = CustomBoard.NONE;
            return new ChromaMode[0];
        }


        void Awake() {
            Plugin.Log("ChromaBehaviour instantiated.");
        }

        void OnDestroy() {
            Plugin.Log("ChromaBehaviour destroyed.");
            StopCoroutine(RandomSabers());
        }

        void Start() {
            MainGameSceneSetup s = GetGameSceneSetup();
            if (s != null) {
                Plugin.Log("Found MGS properly!");
                if (Plugin.debugMode) Plugin.PlayOtherSound(Resources.AudioResources.MGS_Found);
                MGSFound(SceneManager.GetActiveScene(), s);
            }
        }

        void Update() {
            if (Plugin.isOculus) {

            } else {
                ViveControllerUpdate();
            }
        }
        
        private void ViveControllerUpdate() {
            if (Input.GetKeyDown(KeyCode.JoystickButton15) && toggleActive) {
                SaberPos.SwapSabers(positions[0], positions[2]);
                ReassignSabers(positions[0].saber, positions[2].saber);
            }
            if (Input.GetKeyUp(KeyCode.JoystickButton15) && toggleActive) {
                if (!Plugin.permanentToggle) {
                    SaberPos.SwapSabers(positions[0], positions[2]);
                    ReassignSabers(positions[0].saber, positions[2].saber);
                }
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton14) && toggleActive) {
                SaberPos.SwapSabers(positions[1], positions[3]);
                ReassignSabers(positions[1].saber, positions[3].saber);
            }
            if (Input.GetKeyUp(KeyCode.JoystickButton14) && toggleActive) {
                if (!Plugin.permanentToggle) {
                    SaberPos.SwapSabers(positions[1], positions[3]);
                    ReassignSabers(positions[1].saber, positions[3].saber);
                }
            }
        }

        MainGameSceneSetup GetGameSceneSetup() {
            MainGameSceneSetup s = GameObject.FindObjectOfType<MainGameSceneSetup>();
            if (s == null) {
                s = UnityEngine.Resources.FindObjectsOfTypeAll<MainGameSceneSetup>().FirstOrDefault();
            }
            return s;
        }

        private void ReassignSabers(Saber left, Saber right) {
            if (right != null) ReflectionUtil.SetPrivateField(_playerController, "_rightSaber", right);
            if (left != null) ReflectionUtil.SetPrivateField(_playerController, "_leftSaber", left);
        }

        Saber leftSaberBase;
        Saber rightSaberBase;
        SaberPos[] positions;

        //   |[1]   |[0]
        //   *      *
        //   |[3]   |[2]

        private void MGSFound(Scene scene, MainGameSceneSetup mgs) {
            Plugin.Log("Found MGS!");
            Plugin.PlayReloadSound();

            _playerController = FindObjectOfType<PlayerController>();
            if (_playerController == null) Plugin.Log("Player Controller not found!");

            if (!Plugin.IsTargetGameScene(scene.buildIndex)) {
                Plugin.Log("Somehow we got to the point where we override a map, while not playing a map.  How did this happen?", true);
                return;
            }

            if (mgs == null) {
                Plugin.Log("Failed to obtain MainGameSceneSetup", true);
                return;
            }

            MainGameSceneSetupData mgData = ReflectionUtil.GetPrivateField<MainGameSceneSetupData>(mgs, "_mainGameSceneSetupData");
            if (mgData == null) {
                Plugin.Log("Failed to obtain MainGameSceneSetupData from MainGameSceneSetup", true);
                return;
            }

            bool partyMode = mgData.gameplayMode == GameplayMode.PartyStandard;
            bool chromaSong = false;

            modes = GetModes(partyMode, chromaSong);

            if (Plugin.debugMode) {
                Console.WriteLine();
                Console.WriteLine();
                Plugin.Log("Gamemode: "+mgData.gameplayMode.ToString());
                Plugin.Log("Leaderboard: " + customBoard.ToString());
                if (modes.Length > 0) {
                    Plugin.Log("Modes: ");
                    for (int i = 0; i < modes.Length; i++) Plugin.Log("-    " + modes[i].ToString());
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            //Sabers
            Saber[] sabers = FindObjectsOfType<Saber>();
            if (sabers.Length == 1) {
                leftSaberBase = mgData.gameplayOptions.mirror ? sabers[0] : null;
                rightSaberBase = mgData.gameplayOptions.mirror ? null : sabers[0];
            } else {
                leftSaberBase = sabers[0];
                rightSaberBase = sabers[1];
            }

            positions = new SaberPos[4];

            try {

                //Right saber main
                if (leftSaberBase == null) positions[0] = new SaberPos(null, null, Vector3.zero, Quaternion.identity, true);
                else positions[0] = new SaberPos(leftSaberBase, leftSaberBase.transform.parent, leftSaberBase.transform.localPosition, leftSaberBase.transform.localRotation, ModeActive(ChromaMode.SINGLE_SABER) ? mgData.gameplayOptions.mirror : false);

                //Left saber main
                if (rightSaberBase == null) positions[1] = new SaberPos(null, null, Vector3.zero, Quaternion.identity, true);
                else positions[1] = new SaberPos(rightSaberBase, rightSaberBase.transform.parent, rightSaberBase.transform.localPosition, rightSaberBase.transform.localRotation, ModeActive(ChromaMode.SINGLE_SABER) ? !mgData.gameplayOptions.mirror : false);

                //Right saber alt
                if (rightSaberBase != null && (ModeActive(ChromaMode.DARTH_MAUL) || ModeActive(ChromaMode.CHROMATOGGLE))) {
                    positions[2] = new SaberPos(CloneSaber(rightSaberBase), leftSaberBase.transform.parent, leftSaberBase.transform.localPosition, leftSaberBase.transform.localRotation, ModeActive(ChromaMode.DARTH_MAUL) ? positions[0].isDisabled : true);
                    if (ModeActive(ChromaMode.DARTH_MAUL)) positions[2].FlipPosition();
                } else positions[2] = new SaberPos(null, null, Vector3.zero, Quaternion.identity, true);

                //Left saber alt
                if (leftSaberBase != null && (ModeActive(ChromaMode.DARTH_MAUL) || ModeActive(ChromaMode.CHROMATOGGLE))) {
                    positions[3] = new SaberPos(CloneSaber(leftSaberBase), rightSaberBase.transform.parent, rightSaberBase.transform.localPosition, rightSaberBase.transform.localRotation, ModeActive(ChromaMode.DARTH_MAUL) ? positions[1].isDisabled : true);
                    if (ModeActive(ChromaMode.DARTH_MAUL)) positions[3].FlipPosition();
                } else positions[3] = new SaberPos(null, null, Vector3.zero, Quaternion.identity, true);

                if (ModeActive(ChromaMode.DARTH_MAUL)){
                    if (!ModeActive(ChromaMode.DARTH_ALT_LEFT) && !ModeActive(ChromaMode.SINGLE_SABER)) {
                        SaberPos.SwapSabers(positions[1], positions[3]);
                    }
                }

                //positions[2].isDisabled = true; positions[2].localPosition = positions[2].localPosition + new Vector3(0, 0.1f, 0);
                //positions[3].isDisabled = true; positions[3].localPosition = positions[3].localPosition + new Vector3(0, 0.1f, 0);

                if (ModeActive(ChromaMode.CHROMATOGGLE)) {
                    if (!ModeActive(ChromaMode.CHROMATOGGLE_ALT) && !ModeActive(ChromaMode.DARTH_MAUL)) SaberPos.SwapSabers(positions[1], positions[3]);
                    toggleActive = true;
                }

                for (int i = 0; i < positions.Length; i++) {
                    positions[i].saber.name = "Saber " + positions[i].saber.saberType + " " + i;
                    if (ModeActive(ChromaMode.MANTIS)) positions[i].FlipPosition();
                    positions[i].SetSaber(positions[i].saber);
                }

            } catch (Exception e) {
                Console.Write(e);
            }

            //Map

            BeatmapDataModel _beatmapDataModel = ReflectionUtil.GetPrivateField<BeatmapDataModel>(mgs, "_beatmapDataModel");
            BeatmapData beatmapData = CreateTransformedBeatmapData(mgData.difficultyLevel.beatmapData, mgData.gameplayOptions);
            if (beatmapData != null) {
                _beatmapDataModel.beatmapData = beatmapData;
                ReflectionUtil.SetPrivateField(mgs, "_beatmapDataModel", _beatmapDataModel);
            }

            if (ModeActive(ChromaMode.RANDOM_SABERS)) {
                rand = new System.Random(beatmapData.beatmapLinesData.Length);
                StartCoroutine(RandomSabers());
            }
        }

        public Saber CloneSaber(Saber original) {
            GameObject copyObject = Instantiate(original.gameObject);
            Saber copySaber = copyObject.GetComponent<Saber>();
            return copySaber;
        }

        public bool ModeActive(ChromaMode mode) {
            for (int i = 0; i < modes.Length; i++) {
                if (modes[i] == mode) return true;
            }
            return false;
        }

        public BeatmapData CreateTransformedBeatmapData(BeatmapData beatmapData, GameplayOptions gameplayOptions) {
            if (modes.Length > 0){
            /*if (ModeActive(ChromaMode.DOUBLES_DOTS) || ModeActive(ChromaMode.DOUBLES_MONO) || ModeActive(ChromaMode.DOUBLES_REMOVED) || ModeActive(ChromaMode.INVERT_COLOUR) || ModeActive(ChromaMode.MIRROR_DIRECTION) || ModeActive(ChromaMode.MIRROR_POSITION) || ModeActive(ChromaMode.MONOCHROME) || ModeActive(ChromaMode.NO_ARROWS) || ModeActive(ChromaMode.RANDOM_COLOURS_CHROMA) || ModeActive(ChromaMode.RANDOM_COLOURS_INTENSE) || ModeActive(ChromaMode.RANDOM_COLOURS_ORIGINAL) || ModeActive(ChromaMode.RANDOM_COLOURS_TRUE)) {*/
                Plugin.Log("Attempting map modification...");
                return MapModifier.CreateTransformedData(beatmapData, modes);
            }
            return beatmapData;
        }

        System.Random rand;

        IEnumerator RandomSabers() {

            int i = rand.Next(5, 12);
            
            while (true) {
                yield return new WaitForSeconds(1f);
                i--;
                if (i <= 0) {
                    i = rand.Next(5, 12);
                    if (positions.Length >= 4) {
                        if (ModeActive(ChromaMode.CHROMATOGGLE)) {
                            SaberPos.SwapSabers(positions[0], positions[2]);
                            SaberPos.SwapSabers(positions[1], positions[3]);
                        } else {
                            SaberPos.SwapSabers(positions[0], positions[1]);
                            SaberPos.SwapSabers(positions[2], positions[3]);
                        }
                    }
                }
            }

        }

    }

}
