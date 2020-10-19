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

            private string bulletMode = "single";
            private GameObject parent;
            private GameObject player;

            void Start() {
                parent = GameObject.Find("Enemy Bullets Container");
                player = GameObject.FindGameObjectWithTag("Player");

                spawn();
            }

            private void spawn() {
                if (bulletMode == "single") InvokeRepeating("fireSingle", 0f, 1f);
                if (bulletMode == "cross-plus") InvokeRepeating("fireCrossPlus", 0f, 1f);
                if (bulletMode == "plus-rotation") InvokeRepeating("firePlusWithRotation", 0f, 1f);
                else if (bulletMode == "boss1") InvokeRepeating("fireBoss1", 0f, 0.5f);
                else if (bulletMode == "boss2") InvokeRepeating("fireBoss2", 0f, 0.1f);
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

            private int fireBoss1InvulnerableCounterRotation = 3;
            private int fireBoss1Rotation = 27;
            private void fireBoss1() {
                fireBoss1Rotation -= 30;
                GameObject bullet = fireBoss1InvulnerableCounterRotation % 3 == 0 ? InvulnerableBullet : VulnerableBullet;

                List<BulletPos> axises = new List<BulletPos>();

                    axises.Add(new BulletPos(0 + fireBoss1Rotation, bullet));
                    axises.Add(new BulletPos(45 + fireBoss1Rotation, bullet));
                    axises.Add(new BulletPos(90 + fireBoss1Rotation, bullet));
                    axises.Add(new BulletPos(135 + fireBoss1Rotation, bullet));
                    axises.Add(new BulletPos(-90 + fireBoss1Rotation, bullet));
                    axises.Add(new BulletPos(-135 + fireBoss1Rotation, bullet));
                    axises.Add(new BulletPos(-180 + fireBoss1Rotation, bullet));
                    axises.Add(new BulletPos(-225 + fireBoss1Rotation, bullet));

                foreach (BulletPos axis in axises) {
                    Instantiate(axis.gameObject, transform.position, Quaternion.AngleAxis(axis.angle, Vector3.forward), parent.transform);
                }
                fireBoss1InvulnerableCounterRotation++;
            }

            // air mancur
            private int boss2Rotation = 80;
            private bool boss2RotationInverse = false;
            private void fireBoss2() {
                if(boss2Rotation > 280) {
                    boss2RotationInverse = true;
				} else if(boss2Rotation < 45) {
                    boss2RotationInverse = false;
                }

                if (boss2RotationInverse) {
                    boss2Rotation -= 15;
                } else {
                    boss2Rotation += 15;
                }

                BulletPos axis = new BulletPos(0 + boss2Rotation, InvulnerableBullet);
                Instantiate(axis.gameObject, transform.position, Quaternion.AngleAxis(axis.angle, Vector3.forward), parent.transform);
            }
        }
    }
}
