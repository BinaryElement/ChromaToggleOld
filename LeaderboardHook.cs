using PlayHooky;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ChromaToggle {

    class LeaderboardHook : MonoBehaviour {

        public class LeaderboardModelDetours {

            public static string GetLeaderboardID(IStandardLevelDifficultyBeatmap difficultyLevel, GameplayMode gameplayMode) {
                string text = "Unknown";
                switch (difficultyLevel.difficultyRank) {
                    case 0:
                        text = "Easy";
                        break;
                    case 1:
                        text = "Normal";
                        break;
                    case 2:
                        text = "Hard";
                        break;
                    case 3:
                        text = "Expert";
                        break;
                    case 4:
                        text = "ExpertPlus";
                        break;
                }
                string text2 = "Unknown";
                switch ((int)gameplayMode) {
                    case 0:
                        text2 = "SoloStandard";
                        break;
                    case 1:
                        text2 = "SoloOneSaber";
                        break;
                    case 2:
                        text2 = "SoloNoArrows";
                        break;
                    case 3:
                        text2 = "PartyStandard";
                        break;
                }
                String s = ChromaBehaviour.GetCustomBoardName();
                if (s != "")
                    return difficultyLevel.level.levelID + "_" + text + "_" + text2 + s;
                return difficultyLevel.level.levelID + "_" + text + "_" + text2;
            }
        };

        private HookManager hookManager;
        private Dictionary<string, MethodInfo> hooks;

        private void Awake() {
            DontDestroyOnLoad(gameObject);

            hookManager = new HookManager();
            this.hooks = new Dictionary<string, MethodInfo>();

            this.Hook("Leaderboard", typeof(LeaderboardsModel).GetMethod("GetLeaderboardID"), typeof(LeaderboardModelDetours).GetMethod("GetLeaderboardID"));
        }
        private void OnDestroy() {
            foreach (string key in this.hooks.Keys)
                this.UnHook(key);
        }

        private bool Hook(string key, MethodInfo target, MethodInfo hook) {
            if (this.hooks.ContainsKey(key))
                return false;
            try {
                this.hooks.Add(key, target);
                if (target == null) Plugin.Log("Null hook target!");
                if (hook == null) Plugin.Log("Null hook hook!");
                this.hookManager.Hook(target, hook);
                Plugin.Log($"{key} hooked!");
                return true;
            } catch (Win32Exception ex) {
                Plugin.Log($"Unrecoverable Windows API error: {(object)ex}");
                return false;
            } catch (Exception ex) {
                Plugin.Log($"Unable to hook method, : {(object)ex}");
                return false;
            }
        }

        private bool UnHook(string key) {
            MethodInfo original;
            if (!this.hooks.TryGetValue(key, out original))
                return false;
            this.hookManager.Unhook(original);
            return true;
        }

    }

}
