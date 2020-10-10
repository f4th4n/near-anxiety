using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NearAnxiety.Player;

namespace NearAnxiety {
    namespace Level0 {
        public class CameraFollow : MonoBehaviour {
            private GameObject player;
            private PlayerShoot playerShoot;
            private bool followPlayer = false;
            private float speed = 2.0f;

            void Start() {
                player = GameObject.FindGameObjectWithTag("Player");
                playerShoot = player.GetComponent<PlayerShoot>();
                playerShoot.EnableShoot = false;
            }

            void Update() {
                if (followPlayer) {
                    float interpolation = speed * Time.deltaTime;
                    float x = Mathf.Lerp(transform.position.x, player.transform.position.x, interpolation);
                    float y = Mathf.Lerp(transform.position.y, player.transform.position.y, interpolation);
                    Vector3 newPos = new Vector3(x, y, transform.position.z);

                    transform.position = newPos;
                }
            }

            void OnCameraAnimationFinish() {
                playerShoot.EnableShoot = true;
                followPlayer = true;

                Animator animator = gameObject.GetComponent<Animator>();
                animator.enabled = false;
            }
        }
    }
}