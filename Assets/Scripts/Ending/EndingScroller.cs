using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NearAnxiety {
    namespace MainScreen {
        public class EndingScroller : MonoBehaviour {
            GameObject twitter;
            private bool stop = false;

            void Start() {
                twitter = GameObject.Find("Canvas Credit/Twitter");
            }

            void Update() {
                if (stop) return;

                float y = 1.5f * Time.deltaTime;
                transform.position = new Vector3(transform.position.x, transform.position.y + y, transform.position.z);

                if (twitter.transform.position.y > 0) {
                    stop = true;
				}
            }
        }
    }
}
