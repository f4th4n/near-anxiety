using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NearAnxiety {
    namespace MainScreen {
        public class ResetLevel : MonoBehaviour {
            public void OnResetLevel() {
                PlayerPrefs.SetInt("wave", 1);
                SceneManager.LoadScene("HomeScene");
            }
        }
    }
}
