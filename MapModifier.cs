using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ChromaToggle {
    public class MapModifier {

        public static BeatmapData CreateTransformedData(BeatmapData beatmapData, ChromaMode[] modes) {

            System.Random intenseRandom = new System.Random(beatmapData.notesCount);
            System.Random dotsRandom = new System.Random(beatmapData.notesCount);
            System.Random mirrorDirectionRandom = new System.Random(beatmapData.notesCount);
            System.Random trueRandom = new System.Random(System.DateTime.Now.Millisecond);

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
                                if (ModeActive(modes, ChromaMode.NO_ARROWS)) noteData.SetNoteToAnyCutDirection();

                                if (ModeActive(modes, ChromaMode.MONOCHROME)) {
                                    NoteType targetType = ModeActive(modes, ChromaMode.INVERT_COLOUR) ? NoteType.NoteA : NoteType.NoteB;
                                    if (noteData.noteType != targetType) {
                                        noteData.SwitchNoteType();
                                    }
                                } else {
                                    if (noteData.noteType == NoteType.NoteA || noteData.noteType == NoteType.NoteB) {

                                        if (ModeActive(modes, ChromaMode.RANDOM_COLOURS_CHROMA)) {
                                            noteData.TransformNoteAOrBToRandomType(); //TODO control this
                                        } else if (ModeActive(modes, ChromaMode.RANDOM_COLOURS_ORIGINAL)) {
                                            noteData.TransformNoteAOrBToRandomType();
                                        } else if (ModeActive(modes, ChromaMode.RANDOM_COLOURS_INTENSE)) {
                                            NoteType targetType = intenseRandom.NextDouble() < 0.5f ? NoteType.NoteA : NoteType.NoteB;
                                            if (noteData.noteType != targetType) noteData.SwitchNoteType();
                                        } else if (ModeActive(modes, ChromaMode.RANDOM_COLOURS_TRUE)) {
                                            NoteType targetType = trueRandom.NextDouble() < 0.5f ? NoteType.NoteA : NoteType.NoteB;
                                            if (noteData.noteType != targetType) noteData.SwitchNoteType();
                                        }
                                    }
                                }

                                if (noteData.noteType == NoteType.NoteA || noteData.noteType == NoteType.NoteB) {

                                    if (ModeActive(modes, ChromaMode.INVERT_COLOUR)) noteData.SwitchNoteType();
                                    if (ModeActive(modes, ChromaMode.MIRROR_DIRECTION)) noteData.MirrorTransformCutDirection();
                                    if (ModeActive(modes, ChromaMode.MIRROR_POSITION)) noteData.MirrorLineIndex(beatmapData.beatmapLinesData.Length);

                                    if (ModeActive(modes, ChromaMode.RANDOM_DOTS)) {
                                        if (dotsRandom.NextDouble() < 0.3f) noteData.SetNoteToAnyCutDirection();
                                    }

                                    int nt = Mathf.FloorToInt(noteData.time * 10000);
                                    System.Random mirrorRandom = new System.Random(nt);
                                    System.Random mirrorPositionRandom = new System.Random(nt + 1);

                                    if (ModeActive(modes, ChromaMode.RANDOM_MIRROR)) {
                                        if (mirrorRandom.NextDouble() < 0.3f) {
                                            noteData.SwitchNoteType();
                                            noteData.MirrorLineIndex(beatmapData.beatmapLinesData.Length);
                                            noteData.MirrorTransformCutDirection();
                                        }
                                    }
                                    if (ModeActive(modes, ChromaMode.RANDOM_MIRROR_POSITION)) {
                                        if (mirrorPositionRandom.NextDouble() < 0.3f) noteData.MirrorLineIndex(beatmapData.beatmapLinesData.Length);
                                    }
                                    if (ModeActive(modes, ChromaMode.RANDOM_MIRROR_DIRECTION)) {
                                        if (mirrorDirectionRandom.NextDouble() < 0.3f) noteData.MirrorTransformCutDirection();
                                    }
                                    
                                    if (doubleHits.ContainsKey(nt)) {
                                        if (doubleHits.TryGetValue(nt, out NoteData oldNote)) {
                                            if (ModeActive(modes, ChromaMode.DOUBLES_REMOVED)) {
                                                //WHAT DO
                                            } else {
                                                if (ModeActive(modes, ChromaMode.DOUBLES_MONO)) {
                                                    if (oldNote.noteType != noteData.noteType) noteData.SwitchNoteType();
                                                }
                                                if (ModeActive(modes, ChromaMode.DOUBLES_DOTS)) {
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

        public static bool ModeActive(ChromaMode[] modes, ChromaMode mode) {
            for (int i = 0; i < modes.Length; i++) {
                if (modes[i] == mode) return true;
            }
            return false;
        }

    }
}
