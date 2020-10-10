using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NearAnxiety {
    namespace MainScreen {
		namespace MainScreen {
		    public class ScrollBG : MonoBehaviour {
		        public float ScrollSpeed = .2f;

		        void Update() {
		            transform.position += transform.right * Time.deltaTime * ScrollSpeed;
		        }
		    }
		}
	}
}
