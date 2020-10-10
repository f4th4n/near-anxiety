using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NearAnxiety {
    namespace MainScreen {
		public class ChooseLanguageHandler : MonoBehaviour {
			public GameObject btnPlay;
			public GameObject btnEn;
			public GameObject btnId;

			void Start() {
				PlayerPrefs.DeleteKey("language-choosen");
				HandleLanguageChooserButton();
			}

			public void HandleLanguageChooserButton() {
				bool isLanguageChoosen = PlayerPrefs.HasKey("language-choosen");

				btnPlay.SetActive(false);
				btnEn.SetActive(false);
				btnId.SetActive(false);

				if (isLanguageChoosen) {
					btnPlay.SetActive(true);
				} else {
					btnEn.SetActive(true);
					btnId.SetActive(true);
				}
			}

			public void ChangeLanguageEn() {
				PlayerPrefs.SetInt("language-choosen", 1);
				PlayerPrefs.SetString("language", "en");
				HandleLanguageChooserButton();
			}

			public void ChangeLanguageId() {
				PlayerPrefs.SetInt("language-choosen", 1);
				PlayerPrefs.SetString("language", "id");
				HandleLanguageChooserButton();
			}
		}
	}
}
