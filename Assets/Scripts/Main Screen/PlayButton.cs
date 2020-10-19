using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace NearAnxiety {
    namespace MainScreen {
		public class PlayButton : MonoBehaviour {
		    public void OnButtonPress() {
				bool isFinishTutorial = PlayerPrefs.HasKey("is-finish-tutorial");
				if(isFinishTutorial) {
					SceneManager.LoadScene("Level1Scene");
				} else {
					SceneManager.LoadScene("Level0Scene");
				}
			}
		}
	}
}
