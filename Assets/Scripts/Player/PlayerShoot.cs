using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearAnxiety {
    namespace Player {
        public class PlayerShoot : MonoBehaviour {
            public float FireBulletEveryInSeconds = 1f;
            public GameObject projectile;
            public bool EnableShoot = false;

            private float lastTimeSpawn;
            private GameObject playerBulletsContainer;
            private AudioSource source;

            void Start() {
                playerBulletsContainer = GameObject.Find("Player Bullets Container");
                source = GetComponent<AudioSource>();

                Invoke("enableShootDelay", 2f);
            }

            void enableShootDelay() {
                EnableShoot = true;
			}

            void Update() {
                Debug.Log("EnableShoot " + EnableShoot);
                if (!EnableShoot) return;

                lastTimeSpawn += Time.deltaTime;
                if (lastTimeSpawn > FireBulletEveryInSeconds) {
                    GameObject bullet = Instantiate(projectile, transform.position, gameObject.transform.rotation, playerBulletsContainer.transform);

                    bullet.name = "Player Bullet";
                    lastTimeSpawn = 0;
                    source.Play();
                }
            }
        }
    }
}
