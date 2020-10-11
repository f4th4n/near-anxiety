using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearAnxiety {
    namespace Transitions {
        public class TransitionTriangle : MonoBehaviour {
            void Start() {
                //StartCoroutine(Test(1));
            }

            IEnumerator Test(int i) {
                yield return new WaitForSeconds(2f);

                StartTransition(1);
            }

            void StartTransition(int val) {
                for (var i = 0; i <= 90; i++) {
                    StartCoroutine(DisplayTransitionCoroutine(i));
                }

                StartCoroutine(DisplayTransitionCoroutine(100));
            }

            IEnumerator DisplayTransitionCoroutine(int i) {
                float delay = 0.02f + (i * 0.02f);
                yield return new WaitForSeconds(delay);

                if(i != 100) {
                    transform.Find("Triangle (" + i + ")").gameObject.SetActive(true);
                } else {
                    transform.Find("Full").gameObject.SetActive(true);
                }
            }
        }
    }
}
