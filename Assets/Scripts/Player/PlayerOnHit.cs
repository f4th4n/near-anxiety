using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace NearAnxiety {
    namespace Player {
        public class PlayerOnHit : MonoBehaviour {
            public int HP = 3;
            public CameraShake cameraShake;
            public GameObject Transition;

            private bool invulnerable = false;

			private void Start() {
                invulnerable = false;
			}

			void OnTriggerEnter2D(Collider2D col) {
                if(col.gameObject.tag == "Bullet") {
                    if (invulnerable) return;

                    HP--;
                    cameraShake.ShakeDuration = .2f;

                    if (HP == 2) {
                        GameObject.Find("HUD/Lifes/Heart 3").SetActive(false);
                    } else if (HP == 1) {
                        GameObject.Find("HUD/Lifes/Heart 2").SetActive(false);
                    } else if (HP == 0) {
                        GameObject.Find("HUD/Lifes/Heart 1").SetActive(false);
                        StartCoroutine(RestartLevel());
                    }
                }
            }

            void SetInvulnerability(bool argInvulnerable) {
                invulnerable = argInvulnerable;
            }

            IEnumerator RestartLevel() {
                Time.timeScale = 0;
                yield return new WaitForSecondsRealtime(.5f);

                Time.timeScale = 1;

                Instantiate(Transition);
                yield return new WaitForSecondsRealtime(1f);

                SceneManager.LoadScene("Level1Scene");
            }
        }
    }
}
