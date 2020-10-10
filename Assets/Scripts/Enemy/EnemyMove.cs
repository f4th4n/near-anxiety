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
		}
	}
}
