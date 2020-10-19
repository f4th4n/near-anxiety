using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NearAnxiety.Models;
using NearAnxiety.Helpers;

namespace NearAnxiety {
    namespace Intros {
        public class SetIntroText : MonoBehaviour {
            public GameObject IntroPrefab;

            void Start() {
                GameObject.Find("Intro").SetActive(true);
                List<IntroModel> intros = getIntrosData();
                int playerWave = PlayerPrefs.GetInt("wave", 1);
                float delaySpawnEnemiesAndPlayer = 3f;

                foreach (IntroModel intro in intros) {
                    if (intro.Wave != playerWave) continue;

                    StartCoroutine(createIntroText(intro));
                    delaySpawnEnemiesAndPlayer += intro.Delay;
                }

                StartCoroutine(spawnEnemiesAndPlayerThenHideIntro(delaySpawnEnemiesAndPlayer));
            }

            IEnumerator spawnEnemiesAndPlayerThenHideIntro(float delaySpawnEnemiesAndPlayer) {
                yield return new WaitForSeconds(delaySpawnEnemiesAndPlayer);

                GameObject.Find("Enemies").SendMessage("SpawnEnemiesByWave", 1);

                GameObject[] introCanvases = GameObject.FindGameObjectsWithTag("Intro Canvas");
                foreach (GameObject introCanvas in introCanvases) {
                    Animator textAnimator = introCanvas.transform.Find("Text").GetComponent<Animator>();
                    textAnimator.SetBool("Fade Out", true);
                }
            }

            IEnumerator createIntroText(IntroModel intro) {
                yield return new WaitForSeconds(intro.Delay + 1f);

                GameObject introGO = Instantiate(IntroPrefab, Vector3.zero, Quaternion.identity, transform);
                setPos(introGO, intro);

                TextMeshProUGUI textmeshPro = introGO.transform.Find("Text").GetComponent<TextMeshProUGUI>();
                textmeshPro.SetText(intro.Text);
                textmeshPro.fontSize = intro.Size;
            }

            private void setPos(GameObject introGo, IntroModel introData) {
                Camera cam = Camera.main;
                float xScreen = introData.X / 100 * Screen.width;
                float yScreen = introData.Y / 100 * Screen.height;
                Vector3 point = cam.ScreenToWorldPoint(new Vector3(xScreen, yScreen, cam.nearClipPlane));
                introGo.transform.position = new Vector3(point.x, point.y, introGo.transform.position.z);
            }

            List<IntroModel> getIntrosData() {
                // Load text from a JSON file (Assets/Resources/Intros.json)
                string jsonString = Resources.Load<TextAsset>("Intros").ToString();
                IntroModel[] intros = JsonHelper.FromJson<IntroModel>(jsonString);

                return new List<IntroModel>(intros);
            }
        }
    }
}
