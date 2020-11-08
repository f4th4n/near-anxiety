using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NearAnxiety {
    public class AudioManager : MonoBehaviour {
        private bool stopIntroLoop = false;
        private AudioSource audioSource;
        private static GameObject introGO;

        private void Start() {
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update() {
            Scene scene = SceneManager.GetActiveScene();
            stopIntroLoop = scene.name != "HomeScene";

            if (stopIntroLoop) {
                //audioSource.volume = audioSource.volume - 0.0003f;
                audioSource.loop = false;
            }
        }

        private static AudioManager instance = null;
        public static AudioManager Instance {
            get { return instance; }
        }

        void Awake() {
            if (instance != null && instance != this) {
                Destroy(this.gameObject);
                return;
            } else {
                instance = this;
            }

            introGO = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        }

        public static GameObject GetIntro() {

            return introGO;
        }
    }
}