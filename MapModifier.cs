using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SaberToggle {
    public class MapModifier {

        public static BeatmapData CreateTransformedData(BeatmapData beatmapData) {

            beatmapData = beatmapData.GetCopy();
            BeatmapLineData[] beatmapLinesData = beatmapData.beatmapLinesData;
            int[] array = new int[beatmapLinesData.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = 0;
            }
            UnityEngine.Random.InitState(0);
            bool flag;
            do {
                flag = false;
                float num = 999999f;
                int num2 = 0;
                for (int j = 0; j < beatmapLinesData.Length; j++) {
                    BeatmapObjectData[] beatmapObjectsData = beatmapLinesData[j].beatmapObjectsData;
                    int num3 = array[j];
                    while (num3 < beatmapObjectsData.Length && beatmapObjectsData[num3].time < num + 0.001f) {
                        flag = true;
                        BeatmapObjectData beatmapObjectData = beatmapObjectsData[num3];
                        float time = beatmapObjectData.time;
                        if (Mathf.Abs(time - num) < 0.001f) {
                            if (beatmapObjectData.beatmapObjectType == BeatmapObjectType.Note) {
                                num2++;
                            }
                        } else if (time < num) {
                            num = time;
                            if (beatmapObjectData.beatmapObjectType == BeatmapObjectType.Note) {
                                num2 = 1;
                            } else {
                                num2 = 0;
                            }
                        }
                        num3++;
                    }
                }

                Dictionary<int, NoteData> doubleHits = new Dictionary<int, NoteData>();

                for (int k = 0; k < beatmapLinesData.Length; k++) {
                    BeatmapObjectData[] beatmapObjectsData2 = beatmapLinesData[k].beatmapObjectsData;
                    int num4 = array[k];
                    while (num4 < beatmapObjectsData2.Length && beatmapObjectsData2[num4].time < num + 0.001f) {
                        BeatmapObjectData beatmapObjectData2 = beatmapObjectsData2[num4];
                        if (beatmapObjectData2.beatmapObjectType == BeatmapObjectType.Note) {
                            NoteData noteData = beatmapObjectData2 as NoteData;
                            if (noteData != null) {
                                if (Plugin.enableAllDots) noteData.SetNoteToAnyCutDirection();

                                if (Plugin.enableOneColorMode) {
                                    NoteType targetType = NoteType.NoteB;
                                    if (noteData.noteType != targetType) {
                                        noteData.SwitchNoteType();
                                    }
                                } else {
                                    if (Plugin.enableColourRand && (noteData.noteType == NoteType.NoteA || noteData.noteType == NoteType.NoteB)) {
                                        noteData.TransformNoteAOrBToRandomType();
                                    }
                                }

                                if (noteData.noteType == NoteType.NoteA || noteData.noteType == NoteType.NoteB) {
                                    
                                    int nt = Mathf.FloorToInt(noteData.time * 10000);
                                    if (doubleHits.ContainsKey(nt)) {
                                        if (doubleHits.TryGetValue(nt, out NoteData oldNote)) {
                                            if (!Plugin.enableDoubleHits) {
                                                //WHAT DO
                                            } else {
                                                if (Plugin.enableMonoDoubles) {
                                                    if (oldNote.noteType != noteData.noteType) noteData.SwitchNoteType();
                                                }
                                                if (Plugin.enableDotDoubles) {
                                                    oldNote.SetNoteToAnyCutDirection();
                                                    noteData.SetNoteToAnyCutDirection();
                                                }
                                            }
                                        }
                                    } else {
                                        doubleHits.Add(nt, noteData);
                                    }

                                }

                            }
                        }
                        array[k]++;
                        num4++;
                    }

                }
            }
            while (flag);
            return beatmapData;
        }
    }
}
