using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearAnxiety {
    namespace Enemy {
        public class BulletOnHit : MonoBehaviour {
            Animator animator;
            CircleCollider2D circleCollider;

            void Start() {
                animator = gameObject.GetComponent<Animator>();
                circleCollider = gameObject.GetComponent<CircleCollider2D>();
            }

            void OnTriggerEnter2D(Collider2D col) {
                bool hitByPlayerBullet = col.gameObject.name == "Player Bullet";
                if (hitByPlayerBullet) {
                    bool isVulnerableBullet = gameObject.name == "Enemy Bullet Vulnerable(Clone)";
                    if (isVulnerableBullet) {
                        animator.SetBool("Is On Hit", true);
                        circleCollider.enabled = false;
                        Destroy(col.gameObject);
                    }
                }
            }
        }
    }
}
