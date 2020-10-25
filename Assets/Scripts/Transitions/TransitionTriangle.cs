﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearAnxiety {
    namespace Transitions {
        public class TransitionTriangle : MonoBehaviour {
            void Start() {
                StartCoroutine(DestroyAfterSecond());
            }

            IEnumerator DestroyAfterSecond() {
                yield return new WaitForSeconds(3.5f);

                Destroy(gameObject);
            }
        }
    }
}
