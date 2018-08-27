using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SaberToggle {

    class ChromaToggleBehaviour : MonoBehaviour {
        
        private PlayerController _playerController;

        private Saber[] _sabers = null;
        private Saber[] _altSabers = null;

        private bool toggleValid = false;
        private bool singleSaber = false;
        private bool resetNoFail = false;

        //private MainGameSceneSetupData mgData = null;

        private void Awake() {
            //SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
            DontDestroyOnLoad(gameObject);
            Console.WriteLine("Saber Toggle loaded");
        }

        private void OnDestroy() {
            //SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }

        private KeyCode GetKeyCode(bool leftController) {
            if (leftController) return Plugin.useOculusButton ? KeyCode.JoystickButton3 : KeyCode.JoystickButton15;
            else return Plugin.useOculusButton ? KeyCode.JoystickButton2 : KeyCode.JoystickButton14;
        }

        private void Update() {
            if (Input.GetKeyDown(GetKeyCode(true)) && toggleValid) {
                if (Plugin.permanentToggle) ToggleSabers(0);
                else ToggleSabers(0, true);
            }
            if (Input.GetKeyUp(GetKeyCode(true)) && toggleValid) {
                if (!Plugin.permanentToggle) ToggleSabers(0, false);
            }
            if (Input.GetKeyDown(GetKeyCode(false)) && toggleValid && !singleSaber) {
                if (Plugin.permanentToggle) ToggleSabers(1);
                else ToggleSabers(1, true);
            }
            if (Input.GetKeyUp(GetKeyCode(false)) && toggleValid && !singleSaber) {
                if (!Plugin.permanentToggle) ToggleSabers(1, false);
            }
            /*if (Input.GetKeyDown(KeyCode.JoystickButton15) && toggleValid) {
                _sabers[0].gameObject.SetActive(false);
                _altSabers[0].gameObject.SetActive(true);
                ReassignSabers();
                //_sabers[1].gameObject.SetActive(!_sabers[1].gameObject.activeSelf);
                //_altSabers[1].gameObject.SetActive(!_sabers[1].gameObject.activeSelf);
            }
            if (Input.GetKeyUp(KeyCode.JoystickButton15) && toggleValid) {
                _sabers[0].gameObject.SetActive(true);
                _altSabers[0].gameObject.SetActive(false);
                ReassignSabers();
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton14) && toggleValid && !singleSaber) {
                _sabers[1].gameObject.SetActive(false);
                _altSabers[1].gameObject.SetActive(true);
                ReassignSabers();
            }
            if (Input.GetKeyUp(KeyCode.JoystickButton14) && toggleValid && !singleSaber) {
                _sabers[1].gameObject.SetActive(true);
                _altSabers[1].gameObject.SetActive(false);
                ReassignSabers();
            }*/
        }

        private void ToggleSabers(int i) {
            _sabers[i].gameObject.SetActive(!_sabers[i].gameObject.activeSelf);
            _altSabers[i].gameObject.SetActive(!_sabers[i].gameObject.activeSelf);
            ReassignSabers();
        }

        private void ToggleSabers(int i, bool alt) {
            _sabers[i].gameObject.SetActive(!alt);
            _altSabers[i].gameObject.SetActive(alt);
            ReassignSabers();
        }

        private void ReassignSabers() {
            ReflectionUtil.SetPrivateField(_playerController, "_rightSaber", _sabers[0].gameObject.activeSelf ? _sabers[0] : _altSabers[0]);
            ReflectionUtil.SetPrivateField(_playerController, "_leftSaber", _sabers[1].gameObject.activeSelf ? _sabers[1] : _altSabers[1]);
        }

        //private void SceneManagerOnActiveSceneChanged(Scene from, Scene scene) {
        private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode arg1) {
            this.StartCoroutine(DelayedSceneStart(scene));
        }

        IEnumerator DelayedSceneStart(Scene scene) {
            MainGameSceneSetup mainGameSceneSetup = null;
            int i = 0;
            while (i < 20) {
                yield return new WaitForSeconds(0.1f);
                if (mainGameSceneSetup == null) {
                    mainGameSceneSetup = Resources.FindObjectsOfTypeAll<MainGameSceneSetup>().FirstOrDefault();
                }
                if (mainGameSceneSetup != null) {
                    MGSFound(scene, mainGameSceneSetup);
                    yield break;
                }
            }
        }

        private void MGSFound(Scene scene, MainGameSceneSetup mainGameSceneSetup){

            try {

                /*if (mgData != null && resetNoFail) {
                    mgData.gameplayOptions.noEnergy = false;
                    resetNoFail = false;
                }*/

                toggleValid = false;
                singleSaber = false;
                this._playerController = FindObjectOfType<PlayerController>();

                Plugin.WriteConsoleMessage("Debug 1");

                if (Plugin.isTargetSceneIndex(scene.buildIndex)) {
                    Plugin.WriteConsoleMessage("Scene "+scene.name+" ("+scene.buildIndex+") found");

                    //MainGameSceneSetup mainGameSceneSetup = FindObjectOfType<MainGameSceneSetup>();
                    if (mainGameSceneSetup == null) {
                        mainGameSceneSetup = Resources.FindObjectsOfTypeAll<MainGameSceneSetup>().FirstOrDefault();
                        if (mainGameSceneSetup == null) {
                            Plugin.WriteConsoleMessage("Main Game Scene Setup not found!");
                            return;
                        }
                    }
                    MainGameSceneSetupData mgData = ReflectionUtil.GetPrivateField<MainGameSceneSetupData>(mainGameSceneSetup, "_mainGameSceneSetupData");

                    Plugin.WriteConsoleMessage("Debug 2");

                    if (mgData.gameplayMode != GameplayMode.PartyStandard) return;

                    Plugin.WriteConsoleMessage("Debug 3");

                    //if (mgData == null) return;
                    //mgData.didFinishEvent += MainGameSceneSetupDataOnDidFinishEvent;

                    if (mgData.gameplayMode == GameplayMode.SoloOneSaber) {
                        singleSaber = true;
                        Plugin.WriteConsoleMessage("Single saber - nevermind");
                        return;
                    }

                    if (true) {

                        //Map modification
                        BeatmapDataModel _beatmapDataModel = ReflectionUtil.GetPrivateField<BeatmapDataModel>(mainGameSceneSetup, "_beatmapDataModel");
                        BeatmapData beatmapData = CreateTransformedBeatmapData(mgData.difficultyLevel.beatmapData, mgData.gameplayOptions, mgData.gameplayMode);
                        if (beatmapData != null) {
                            _beatmapDataModel.beatmapData = beatmapData;
                            ReflectionUtil.SetPrivateField(mainGameSceneSetup, "_beatmapDataModel", _beatmapDataModel);
                        }

                        _sabers = FindObjectsOfType<Saber>();

                        if (_sabers.Length == 2) {
                            _altSabers = new Saber[_sabers.Length];
                            if (Plugin.enableOneColorMode) {
                                Plugin.WriteConsoleMessage("One Colorifying...");
                                for (int i = 0; i <= _sabers.Length; i++) {
                                    GameObject saberCopy = Instantiate(_sabers[0].gameObject);
                                    Saber newSaber = saberCopy.GetComponent<Saber>();
                                    saberCopy.transform.parent = _sabers[i == 0 || i == _sabers.Length ? 1 : 0].transform.parent;
                                    saberCopy.transform.localPosition = Vector3.zero;
                                    saberCopy.transform.localRotation = Quaternion.identity;
                                    if (i == _sabers.Length) {
                                        _sabers[1].gameObject.SetActive(false);
                                        _sabers[1] = newSaber;
                                        _sabers[1].gameObject.SetActive(true);
                                    } else {
                                        saberCopy.SetActive(false);
                                        _altSabers[i == 0 ? 1 : 0] = newSaber;
                                    }
                                }
                            } else {
                                Plugin.WriteConsoleMessage("Multicolor cloning...");
                                for (int i = 0; i < _sabers.Length; i++) {
                                    GameObject saberCopy = Instantiate(_sabers[i].gameObject);
                                    Saber newSaber = saberCopy.GetComponent<Saber>();
                                    saberCopy.transform.parent = _sabers[i == 0 ? 1 : 0].transform.parent;
                                    saberCopy.transform.localPosition = Vector3.zero;
                                    saberCopy.transform.localRotation = Quaternion.identity;
                                    saberCopy.SetActive(false);
                                    _altSabers[i == 0 ? 1 : 0] = newSaber;
                                }
                                if (!Plugin.alternateToggle) {
                                    Plugin.WriteConsoleMessage("Alternate Toggle enabled");
                                    Saber temp = _altSabers[1];
                                    _altSabers[1] = _sabers[1];
                                    _sabers[1] = temp;
                                }
                            }
                        } else {
                            if (_altSabers == null) return;
                        }


                        if (Plugin.enableSaberToggle && !Plugin.enableDarthMaul && !Plugin.enableOneColorMode) {
                            Plugin.WriteConsoleMessage("Toggling enabled!");
                            toggleValid = true;
                            ToggleSabers(0, false);
                            ToggleSabers(1, false);
                        } else if (Plugin.enableDarthMaul) {
                            Plugin.WriteConsoleMessage("Maul enabled!");
                            _altSabers[0].transform.Rotate(new Vector3(180, 0, 0));
                            _altSabers[1].transform.Rotate(new Vector3(180, 0, 0));
                            _sabers[0].gameObject.SetActive(true);
                            _altSabers[0].gameObject.SetActive(true);
                            _sabers[1].gameObject.SetActive(Plugin.doubleDarthMaul);
                            _altSabers[1].gameObject.SetActive(Plugin.doubleDarthMaul);
                            if (Plugin.doubleDarthMaul) Plugin.WriteConsoleMessage("Double maul is a go!");
                            for (int i = 0; i < _altSabers.Length; i++) {
                                //_altSabers[i].transform.Translate(_altSabers[i].transform.forward * Plugin.darthMantisOffset);
                                _altSabers[i].transform.localPosition = _altSabers[i].transform.localPosition + new Vector3(0, 0, -Plugin.darthMantisOffset);
                            }
                        }

                        if (Plugin.enableMantisStyle) {
                            Plugin.WriteConsoleMessage("MANTIS MODE");
                            for (int i = 0; i < _sabers.Length; i++) {
                                //_sabers[i].transform.Translate(_sabers[i].transform.forward * (Plugin.darthMantisOffset / 2));
                                _sabers[i].transform.localPosition = _sabers[i].transform.localPosition + new Vector3(0, 0, -Plugin.darthMantisOffset);
                                _sabers[i].transform.Rotate(new Vector3(180, 0, 0));
                            }
                            for (int i = 0; i < _altSabers.Length; i++) {
                                //_altSabers[i].transform.Translate(_altSabers[i].transform.forward * (Plugin.darthMantisOffset / 2));
                                _altSabers[i].transform.localPosition = _altSabers[i].transform.localPosition + new Vector3(0, 0, -Plugin.darthMantisOffset);
                                _altSabers[i].transform.Rotate(new Vector3(180, 0, 0));
                            }
                        }

                        ApplyDebugObjects(_sabers[0].gameObject);
                    }
                } else {
                    Plugin.WriteConsoleMessage("Loaded scene "+scene.buildIndex);
                }

            } catch (Exception ex) {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }

        }

        private void ApplyDebugObjects(GameObject host) {
            float globalScale = 0.05f;

            GameObject forward = GameObject.CreatePrimitive(PrimitiveType.Cube);
            forward.transform.SetParent(host.transform);
            forward.transform.localPosition = new Vector3(0, 0, 1) * globalScale * 2;
            forward.transform.localRotation = Quaternion.identity;
            forward.transform.localScale = new Vector3(globalScale / forward.transform.lossyScale.x, globalScale / forward.transform.lossyScale.y, globalScale / forward.transform.lossyScale.z);
            forward.GetComponent<Renderer>().material.color = Color.blue;

            GameObject right = GameObject.CreatePrimitive(PrimitiveType.Cube);
            right.transform.SetParent(host.transform);
            right.transform.localPosition = new Vector3(1, 0, 0) * globalScale * 2;
            right.transform.localRotation = Quaternion.identity;
            right.transform.localScale = new Vector3(globalScale / right.transform.lossyScale.x, globalScale / right.transform.lossyScale.y, globalScale / right.transform.lossyScale.z);
            forward.GetComponent<Renderer>().material.color = Color.red;

            GameObject up = GameObject.CreatePrimitive(PrimitiveType.Cube);
            up.transform.SetParent(host.transform);
            up.transform.localPosition = new Vector3(0, 1, 0) * globalScale * 2;
            up.transform.localRotation = Quaternion.identity;
            up.transform.localScale = new Vector3(globalScale / up.transform.lossyScale.x, globalScale / up.transform.lossyScale.y, globalScale / up.transform.lossyScale.z);
            forward.GetComponent<Renderer>().material.color = Color.green;
        }

        private void MainGameSceneSetupDataOnDidFinishEvent(MainGameSceneSetupData arg1, LevelCompletionResults results) {
            if (arg1.gameplayMode == GameplayMode.PartyStandard) return;
            if (results.levelEndStateType == LevelCompletionResults.LevelEndStateType.Cleared && !Plugin.ScoreSubmissionAllowed) {
                if (!arg1.gameplayOptions.noEnergy) resetNoFail = true;
                arg1.gameplayOptions.noEnergy = true;
            }
        }

        public static BeatmapData CreateTransformedBeatmapData(BeatmapData beatmapData, GameplayOptions gameplayOptions, GameplayMode gameplayMode) {
            /*BeatmapData beatmapData2 = beatmapData;
            if (gameplayOptions.mirror) {
                beatmapData2 = BeatDataMirrorTransform.CreateTransformedData(beatmapData2);
            }
            if (gameplayMode == GameplayMode.SoloNoArrows) {
                beatmapData2 = BeatmapDataNoArrowsTransform.CreateTransformedData(beatmapData2);
            }
            if (gameplayOptions.obstaclesOption != GameplayOptions.ObstaclesOption.All) {
                beatmapData2 = BeatmapDataObstaclesTransform.CreateTransformedData(beatmapData2, gameplayOptions.obstaclesOption);
            }
            if (beatmapData2 == beatmapData) {
                beatmapData2 = beatmapData.GetCopy();
            }
            if (gameplayOptions.staticLights) {
                BeatmapEventData[] beatmapEventData = new BeatmapEventData[]
                {
                new BeatmapEventData(0f, BeatmapEventType.Event0, 1),
                new BeatmapEventData(0f, BeatmapEventType.Event4, 1)
                };
                beatmapData2 = new BeatmapData(beatmapData2.beatmapLinesData, beatmapEventData);
            }
            return beatmapData2;*/
            if (Plugin.enableColourRand || Plugin.enableDotDoubles || !Plugin.enableDoubleHits || Plugin.enableMonoDoubles || Plugin.enableOneColorMode || Plugin.enableAllDots) {
                Plugin.WriteConsoleMessage("Attempting map modification...");
                return MapModifier.CreateTransformedData(beatmapData);
            }
            return beatmapData;
        }

    }

}
