using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ChromaToggle {

    class SaberPos {

        public Saber saber;
        public Transform parent;
        public Vector3 localPosition;
        public Quaternion localRotation;
        public bool isDisabled; //When true, the sabers will be disabled when at this location.
        public bool isFlipped;

        public SaberPos(Saber saber, Transform parent, Vector3 localPos, Quaternion localRot, bool isDisabled) {
            this.saber = saber;
            this.parent = parent;
            this.localPosition = localPos;
            this.localRotation = localRot;
            this.isDisabled = isDisabled;
            this.isFlipped = false;
            SetSaber(saber);
        }

        public void FlipPosition() {
            isFlipped = !isFlipped;
            //localRotation = Quaternion.Euler(-localRotation.eulerAngles);
            //localPosition = localPosition + new Vector3(0, 0, -Plugin.darthMantisOffset * -1);
        }

        public void SetSaber(Saber saber) {
            if (saber != null) {
                saber.transform.SetParent(parent);
                saber.transform.localPosition = localPosition;
                saber.transform.localRotation = localRotation;
                if (isFlipped) {
                    saber.transform.localPosition = saber.transform.localPosition + new Vector3(0, 0, -Plugin.darthMantisOffset);
                    saber.transform.Rotate(new Vector3(180, 0, 0));
                }
                saber.gameObject.SetActive(!isDisabled);
            }
            this.saber = saber;
        }

        public static void SwapSabers(SaberPos pos1, SaberPos pos2) {
            Saber saber1 = pos1.saber;
            Saber saber2 = pos2.saber;
            pos1.SetSaber(saber2);
            pos2.SetSaber(saber1);
            pos1.saber = saber2;
            pos2.saber = saber1;
        }

    }

}
