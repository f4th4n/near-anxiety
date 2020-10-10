using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace NearAnxiety {
    namespace MainScreen {
		public class PlayButton : MonoBehaviour {
		    public void OnButtonPress() {
		        SceneManager.LoadScene("Level1Scene");
		    }
		}
	}
}
