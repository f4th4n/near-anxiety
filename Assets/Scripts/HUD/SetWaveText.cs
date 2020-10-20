using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace NearAnxiety {
    namespace HUD {
        public class SetWaveText : MonoBehaviour {
            void Start() {
                TextMeshProUGUI textmeshPro = gameObject.transform.Find("Wave Text").GetComponent<TextMeshProUGUI>();
                textmeshPro.SetText("Wave " + PlayerPrefs.GetInt("wave", 1).ToString());
            }
        }
    }
}
