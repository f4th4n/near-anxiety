using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NearAnxiety {
    namespace Enemy {
		public class EnemyMove : MonoBehaviour {
		    private Animator animator;

		    void StartMove(string move) {
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
		}
	}
}
