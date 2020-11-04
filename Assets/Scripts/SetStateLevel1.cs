﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearAnxiety {
    public class SetStateLevel1 : MonoBehaviour {
        void Start() {
            // test test
            PlayerPrefs.SetInt("wave", 4);
            PlayerPrefs.SetString("language", "en");

            OnReset();
        }

        void OnReset() {
            GameObject[] hearts = GameObject.FindGameObjectsWithTag("Heart");
            foreach (GameObject heart in hearts) {
                heart.SetActive(true);
            }
        }
    }
}