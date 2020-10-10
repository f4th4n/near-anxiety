using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearAnxiety {
    namespace Level0 {
        public class BoxOnHit : MonoBehaviour {
            public int HP = 20;
            public float HideExplosionDelay = 0.3f;
            public GameObject EnemyExplosion;

            private GameObject onHitExplosion;
            private float hideExplosion = -1;

            void Start() {
                onHitExplosion = transform.Find("Enemy On Hit Explosion").gameObject;
                onHitExplosion.SetActive(false);
            }

            void Update() {
                hideExplosion = hideExplosion - Time.deltaTime;
                onHitExplosion.SetActive(hideExplosion > 0);
            }

            void OnCollisionEnter2D(Collision2D col) {
                if (col.gameObject.name == "Player Bullet") {
                    col.gameObject.GetComponent<Renderer>().enabled = false;

                    onHitExplosion.transform.position = col.transform.position;
                    hideExplosion = HideExplosionDelay;
                }
            }

            void OnCollisionExit2D(Collision2D col) {
                if (col.gameObject.name == "Player Bullet") {
                    HP--;

                    if (HP == 0) {
                        Instantiate(EnemyExplosion, transform.position, Quaternion.identity);
                        Destroy(gameObject);
                    }

                    Destroy(col.gameObject);
                }
            }
        }
    }
}
