using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NearAnxiety {
    namespace Enemy {
		public class EnemyMove : MonoBehaviour {
		    private Animator animator;

			void StartMove(string move) {
				if (move == "custom-anxiety") {
					InvokeRepeating("animateAnxiety", 0f, 1f);

					return;
				}
		        animator = gameObject.GetComponent<Animator>();
		        animator.SetBool(move, true);
		    }

		    void SetSpeed(float speed) {
		        animator = gameObject.GetComponent<Animator>();
		        animator.SetFloat("Speed", speed);
		    }

			private void Update() {
				Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
				bool outsideCamera = (viewPos.x < -0.2 || viewPos.x > 1.2 || viewPos.y < -0.2 || viewPos.y > 1.2);
				if (outsideCamera) {
					decreaseEnemy();
					return;
				}
			}

			private void decreaseEnemy() {
				GameObject enemySpawner = GameObject.Find("Enemies");
				enemySpawner.SendMessage("DecreaseEnemyRemaining", -1);
				Destroy(gameObject);
			}

			// custom animation
			private int animateAnxietyCounter = 0;
			private bool animateAnxietyRandom = false;
			private void animateAnxiety() {
				float xPercent, yPercent;

				Debug.Log(animateAnxietyCounter);
				if (animateAnxietyCounter == 4) animateAnxietyCounter = 0;

				if (animateAnxietyCounter == 0) {
					xPercent = 10;
					yPercent = 90;
				} else if (animateAnxietyCounter == 1) {
					xPercent = 90;
					yPercent = 90;
				} else if (animateAnxietyCounter == 2) {
					xPercent = 90;
					yPercent = 10;
				} else if (animateAnxietyCounter == 3) {
					xPercent = 10;
					yPercent = 10;
					animateAnxietyRandom = true;
				} else {
					xPercent = 10;
					yPercent = 10;
				}

				if (animateAnxietyRandom) {
					animateAnxietyCounter = Random.Range(0, 4);
				} else {
					animateAnxietyCounter++;
				}

				Camera cam = Camera.main;
				float xScreen = xPercent / 100 * Screen.width;
				float yScreen = yPercent / 100 * Screen.height;
				Vector3 point = cam.ScreenToWorldPoint(new Vector3(xScreen, yScreen, cam.nearClipPlane));
				transform.position = new Vector3(point.x, point.y, transform.position.z);
			}
		}
	}
}
