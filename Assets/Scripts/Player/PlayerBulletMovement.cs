using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NearAnxiety {
    namespace Player {
        public class PlayerBulletMovement : MonoBehaviour {
            public float DestroyAfterInSeconds = 1.7f;
            public float BulletSpeed = 10f;

            private float intervalLapseToDestroy;

            void Start() {
            }

            void Update() {
                // move position of bullet
                transform.position += transform.up * Time.deltaTime * BulletSpeed;

                intervalLapseToDestroy += Time.deltaTime;
                if(intervalLapseToDestroy > DestroyAfterInSeconds) {
                    Destroy(gameObject);
        		}
            }
        }
    }
}
