using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NearAnxiety {
    namespace Enemy {
		public class EnemyBulletLifetime : MonoBehaviour {
		    public float lifeTimeInSeconds = 5f;
		    private float elapsed = 0;

		    void Update() {
		        elapsed += Time.deltaTime;

		        if(elapsed > lifeTimeInSeconds) {
		            Destroy(gameObject);
		        }
		    }
		}
	}
}
