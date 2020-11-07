using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace NearAnxiety {
    namespace MainScreen {
		public class PlayButton : MonoBehaviour {
			GameObject canvasBlack;
			GameObject canvasBlackImage;

			private void Start() {
				canvasBlack = GameObject.Find("Canvas Black");
				canvasBlackImage = GameObject.Find("Canvas Black/Image");
			}

			public void OnButtonPress() {
				Debug.Log("go to scene");

				canvasBlackImage.transform.position = new Vector3(0, 0, canvasBlackImage.transform.position.z);
				Animator animator = canvasBlackImage.GetComponent<Animator>();
				animator.SetBool("Go To Black Screen", true);

				Invoke("goToScene", 3.0f);
			}

			private void goToScene() {
				bool isFinishTutorial = PlayerPrefs.HasKey("is-finish-tutorial");
				if (isFinishTutorial) {
					SceneManager.LoadScene("Level1Scene");
				} else {
					SceneManager.LoadScene("Level0Scene");
				}
			}
		}
	}
}
