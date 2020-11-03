using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NearAnxiety.Models;
using NearAnxiety.Helpers;
using UnityEngine.SceneManagement;

/*
 * enemies spawned by SetIntroText, after intro is shown
 */
namespace NearAnxiety {
    namespace Enemy {
        public class EnemiesSpawner : MonoBehaviour {
            public GameObject EnemyPrefab;
            private int enemyRemaining = 0;
            public GameObject Transition;
            private GameObject player;

            void Start() {
                player = GameObject.Find("Player");
            }

            // called by SetIntroText.cs
            void SpawnEnemiesByWave(int _ignore) {
                List<EnemyModel> enemiesData = getEnemiesData();
                int playerWave = PlayerPrefs.GetInt("wave", 1);

                foreach (EnemyModel enemyData in enemiesData) {
                    if (enemyData.Wave != playerWave) continue;

                    // TODO ftest
                    //enemyData.Delay -= 13;

                    StartCoroutine(createEnemy(enemyData));
                    enemyRemaining++;
                }

                if(enemyRemaining == 0) {
                    SceneManager.LoadScene("TheEndScene");
                }
            }

            // EnemyOnHit.cs
            void DecreaseEnemyRemaining(int val) {
                enemyRemaining--;

                if(enemyRemaining == 0) {
                    int playerWave = PlayerPrefs.GetInt("wave", 1);
                    playerWave++;
                    PlayerPrefs.SetInt("wave", playerWave);

                    player.SendMessage("SetInvulnerability", true);

                    StartCoroutine(showTransitionThenNextWave());
                }
            }

            IEnumerator showTransitionThenNextWave() {
                yield return new WaitForSecondsRealtime(1f);

                Instantiate(Transition);
                yield return new WaitForSecondsRealtime(1f);

                SceneManager.LoadScene("Level1Scene");
            }

            IEnumerator createEnemy(EnemyModel enemyData) {
                yield return new WaitForSeconds(enemyData.Delay);

                GameObject enemyGO = Instantiate(EnemyPrefab, Vector3.zero, Quaternion.identity, transform);
                setPos(enemyGO, enemyData);
                GameObject enemyMove = enemyGO.transform.Find("Enemy Move").gameObject;
                string lang = PlayerPrefs.GetString("language", "en");
                string text = lang == "en" ? enemyData.Text : enemyData.TextId;

                enemyMove.SendMessage("SetHP", enemyData.HP); // EnemyMove.cs, EnemySetText.cs
                enemyMove.SendMessage("SetText", text); // EnemySetText.cs
                enemyMove.SendMessage("StartMove", enemyData.Animation); // EnemyMove.cs
                enemyMove.SendMessage("SetSpeed", enemyData.Speed); // EnemyMove.cs
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
