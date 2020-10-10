using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearAnxiety {
    namespace Player {
        public class PlayerShoot : MonoBehaviour {
            public float FireBulletEveryInSeconds = 1f;
            public GameObject projectile;
            public bool EnableShoot = true;

            private float lastTimeSpawn;
            private GameObject playerBulletsContainer;
            private AudioSource source;

            void Start() {
                playerBulletsContainer = GameObject.Find("Player Bullets Container");
                source = GetComponent<AudioSource>();
            }

            void Update() {
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
