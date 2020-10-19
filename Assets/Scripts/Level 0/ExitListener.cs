using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NearAnxiety {
    namespace Level0 {
        public class ExitListener : MonoBehaviour {
            void OnTriggerEnter2D(Collider2D col) {
                if (col.gameObject.name != "Player") return;

                StartCoroutine(GoToLevel1());
            }

            IEnumerator GoToLevel1() {
                Time.timeScale = 0.1f;
                yield return new WaitForSecondsRealtime(1.0f);

                Time.timeScale = 1;
                PlayerPrefs.SetInt("is-finish-tutorial", 1);
                SceneManager.LoadScene("Level1Scene");
            }
        }
    }
}
