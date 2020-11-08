using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearAnxiety {
    public class SetStateLevel1 : MonoBehaviour {
        void Start() {
            // test test
            //PlayerPrefs.SetInt("wave", 5);
            //PlayerPrefs.SetString("language", "en");

            OnReset();
            playBG();
        }

        void OnReset() {
            GameObject[] hearts = GameObject.FindGameObjectsWithTag("Heart");
            foreach (GameObject heart in hearts) {
                heart.SetActive(true);
            }
        }

        private void playBG() {
            GameObject intro = AudioManager.GetIntro();
            if (intro == null) return;

            if (PlayerPrefs.GetInt("wave") == 4 || PlayerPrefs.GetInt("wave") == 5) {                intro.GetComponent<AudioSource>().Stop();

                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.mute = false;
            }
		}
    }
}