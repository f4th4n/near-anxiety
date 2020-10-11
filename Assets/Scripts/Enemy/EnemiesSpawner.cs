using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using NearAnxiety.Models;
using NearAnxiety.Helpers;

namespace NearAnxiety {
    namespace Enemy {
        public class EnemiesSpawner : MonoBehaviour {
            public GameObject enemyPrefab;
            private int enemyRemaining = 0;

            void Start() {
                spawnEnemiesByLevel();
            }

            void spawnEnemiesByLevel() {
                PlayerPrefs.SetInt("level", 2);
                List<EnemyModel> enemiesData = getEnemiesData();
                int playerLevel = PlayerPrefs.GetInt("level", 1);

                foreach (EnemyModel enemyData in enemiesData) {
                    if (enemyData.Level != playerLevel) continue;

                    StartCoroutine(createEnemy(enemyData));
                    enemyRemaining++;
                }
            }

            // EnemyOnHit.cs
            void DecreaseEnemyRemaining(int val) {
                enemyRemaining--;

                if(enemyRemaining == 0) {
                    GameObject.Find("Transition").SendMessage("StartTransition", 1);
				}
            }

            IEnumerator createEnemy(EnemyModel enemyData) {
                yield return new WaitForSeconds(enemyData.Delay);

                GameObject enemyGO = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity, transform);
                setPos(enemyGO, enemyData);
                GameObject enemyMove = enemyGO.transform.Find("Enemy Move").gameObject;

                enemyMove.SendMessage("SetText", enemyData.Text); // EnemySetText.cs
                enemyMove.SendMessage("StartMove", enemyData.Animation); // EnemyMove.cs
                enemyMove.SendMessage("SetSpeed", enemyData.Speed); // EnemyMove.cs
                enemyMove.SendMessage("SetHP", enemyData.HP); // EnemyMove.cs
                enemyMove.SendMessage("SetBullet", enemyData.Bullet); // EnemyShoot.cs
            }

            private void setPos(GameObject enemyGO, EnemyModel enemyData) {
                Camera cam = Camera.main;
                float xScreen = enemyData.X / 100 * Screen.width;
                float yScreen = enemyData.Y / 100 * Screen.height;
                Vector3 point = cam.ScreenToWorldPoint(new Vector3(xScreen, yScreen, cam.nearClipPlane));
                enemyGO.transform.position = new Vector3(point.x, point.y, enemyGO.transform.position.z);

            }

            List<EnemyModel> getEnemiesData() {
                // Load text from a JSON file (Assets/Resources/Enemies.json)
                string jsonString = Resources.Load<TextAsset>("Enemies").ToString();
                EnemyModel[] enemies = JsonHelper.FromJson<EnemyModel>(jsonString);

                return new List<EnemyModel>(enemies);
            }
        }
    }
}
