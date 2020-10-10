using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearAnxiety {
    namespace Enemy {
        class BulletPos {
            public float angle;
            public GameObject gameObject;

            public BulletPos(float angleArg, GameObject gameObjectArg) {
                angle = angleArg;
                gameObject = gameObjectArg;
            }
        }
        
        public class EnemyShoot : MonoBehaviour {
            public GameObject VulnerableBullet;
            public GameObject InvulnerableBullet;

            private float shootEveryInSeconds = 1f;
            private float elapsed = 0f;
            private string bulletMode = "single";
            private GameObject parent;
            private GameObject player;

            void Start() {
                parent = GameObject.Find("Enemy Bullets Container");
                player = GameObject.FindGameObjectWithTag("Player");
            }

            void Update() {
                elapsed += Time.deltaTime;
                if (elapsed < shootEveryInSeconds) return;
                elapsed = elapsed % 1f;

                if (bulletMode == "single") fireSingle();
                else if (bulletMode == "cross-plus") fireCrossPlus();
                else if (bulletMode == "plus-rotation") firePlusWithRotation();
                else if (bulletMode == "boss1") fireBoss1();
            }

            void SetBullet(string bulletModeArg) {
                bulletMode = bulletModeArg;
            }

            private void fireSingle() {
                Vector3 direction = player.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                angle -= 90;

                angle += Random.Range(-20.0f, 20.0f);

                bool isVulnerableBullet = (Random.value < 0.8);
                GameObject gameObject = isVulnerableBullet ? VulnerableBullet : InvulnerableBullet;
                Instantiate(gameObject, transform.position, Quaternion.AngleAxis(angle, Vector3.forward), parent.transform);
            }

            private bool firePlusFlipFlop = false;
            private int firePlusInvulnerableCounter = 1;
            private void fireCrossPlus() {
                firePlusFlipFlop = !firePlusFlipFlop;

                List<BulletPos> axises = new List<BulletPos>();
                GameObject bullet = firePlusInvulnerableCounter % 4 == 0 ? InvulnerableBullet : VulnerableBullet;
                if (firePlusFlipFlop) {
                    axises.Add(new BulletPos(0, bullet));
                    axises.Add(new BulletPos(90, bullet));
                    axises.Add(new BulletPos(-90, bullet));
                    axises.Add(new BulletPos(-180, bullet));
                } else {
                    axises.Add(new BulletPos(0 + 45, bullet));
                    axises.Add(new BulletPos(90 + 45, bullet));
                    axises.Add(new BulletPos(-90 + 45, bullet));
                    axises.Add(new BulletPos(-180 + 45, bullet));
                }

                foreach(BulletPos axis in axises) {
                    Instantiate(axis.gameObject, transform.position, Quaternion.AngleAxis(axis.angle, Vector3.forward), parent.transform);
                }

                firePlusInvulnerableCounter++;
            }

            private int firePlusWithRotationInvulnerableCounter = 3;
            private int firePlusLastRotation = 27;
            private void firePlusWithRotation() {
                firePlusLastRotation += 10;
                GameObject bullet = firePlusWithRotationInvulnerableCounter % 3 == 0 ? InvulnerableBullet : VulnerableBullet;
                List<BulletPos> axises = new List<BulletPos>();
                axises.Add(new BulletPos(0 + firePlusLastRotation, bullet));
                axises.Add(new BulletPos(90 + firePlusLastRotation, bullet));
                axises.Add(new BulletPos(-90 + firePlusLastRotation, bullet));
                axises.Add(new BulletPos(-180 + firePlusLastRotation, bullet));

                foreach (BulletPos axis in axises) {
                    Instantiate(axis.gameObject, transform.position, Quaternion.AngleAxis(axis.angle, Vector3.forward), parent.transform);
                }
                firePlusWithRotationInvulnerableCounter++;
            }

            private void fireBoss1() {
                // TODO
        	}
        }
    }
}
