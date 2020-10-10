using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace NearAnxiety {
    namespace Player {
        public class PlayerOnHit : MonoBehaviour {
            public int HP = 3;
            public CameraShake cameraShake;

            void OnTriggerEnter2D(Collider2D col) {
                if(col.gameObject.tag == "Bullet") {
                    HP--;
                    cameraShake.ShakeDuration = .2f;

                    if (HP == 0) {
                        StartCoroutine(RestartLevel());
                    }
                }
            }

            IEnumerator RestartLevel() {
                Time.timeScale = 0;
                yield return new WaitForSecondsRealtime(.5f);

                Time.timeScale = 1;
                SceneManager.LoadScene("Level1Scene");
            }
        }
    }
}
