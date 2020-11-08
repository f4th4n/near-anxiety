using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NearAnxiety {
    namespace Ending {
        public class ResetLevel : MonoBehaviour {
            private int titleClickCounter = 0;

            public void OnResetLevel() {
                PlayerPrefs.SetInt("wave", 1);
                PlayerPrefs.DeleteKey("language");
                PlayerPrefs.DeleteKey("language-choosen");
                SceneManager.LoadScene("HomeScene");
            }

            public void OnResetTitleClick5Times() {
                titleClickCounter++;
                if (titleClickCounter % 5 == 0) {
                    OnResetLevel();
                    Debug.Log("reset all data");
                }
            }
        }
    }
}
