using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NearAnxiety {
    namespace Enemy {
        public class EnemyOnHit : MonoBehaviour {
            public int HP = 100;
            public float HideExplosionDelay = 0.3f;
            public GameObject EnemyExplosion;

            private Animator animator;
            private GameObject explosion;
            private GameObject player;
            private GameObject textGO;
            private float hideExplosion = -1;

            void Start() {
                animator = transform.Find("Vibrate On Hit").gameObject.GetComponent<Animator>();
                textGO = transform.Find("Vibrate On Hit/Canvas/Text").gameObject;
                explosion = transform.Find("Enemy On Hit Explosion").gameObject;
                player = GameObject.FindGameObjectWithTag("Player");

                explosion.SetActive(false);
            }

            void Update() {
                hideExplosion = hideExplosion - Time.deltaTime;
                explosion.SetActive(hideExplosion > 0);
        	}

            void OnCollisionEnter2D(Collision2D col) {
                if (col.gameObject.name == "Player Bullet") {
                    animator.SetBool("Is On Hit", true);
                    col.gameObject.GetComponent<Renderer>().enabled = false;

                    // TODO to make realistic, set explosion.transform.position equal to
                    // distance between collision and enemy position
                    explosion.transform.position = col.transform.position;
                    hideExplosion = HideExplosionDelay;
                }
            }

            void OnCollisionExit2D(Collision2D col) {
                if (col.gameObject.name == "Player Bullet") {

                    animator.SetBool("Is On Hit", false);
                    // TODO animate enemy on hit
                    HP--;

                    if(HP % 4 == 0) {
                        //Instantiate(EnemyExplosionSmall, transform.position, Quaternion.identity);
                    }

                    if (HP == 0) {
                        Instantiate(EnemyExplosion, transform.position, Quaternion.identity);
                        Destroy(gameObject);
                    }

                    Destroy(col.gameObject);
                }
            }

            void SetHP(int HPArg) {
                HP = HPArg;
            }
        }
    }
}
