using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NearAnxiety {
    namespace Enemy {
        public class EnemyBulletMovement : MonoBehaviour {
            public float BulletSpeed = 1;

            private Camera mainCamera;

            void Start() {
                mainCamera = Camera.main;
            }

            void Update() {
                transform.position += transform.up * Time.deltaTime * BulletSpeed;

                Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);
                if (viewPos.x < -0.2 || viewPos.x > 1.2 || viewPos.y < -0.2 || viewPos.y > 1.2) {
                    Destroy(gameObject);
                    return;
                }
            }
        }
    }
}
