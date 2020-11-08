using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearAnxiety {
    namespace Ending {
        public class GoToTwitter : MonoBehaviour {
            public void OnGoToTwitter() {
                Application.OpenURL("https://twitter.com/wildanfathann");
            }
        }
    }
}
