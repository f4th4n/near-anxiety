using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NearAnxiety {
    namespace Player {
		public class PlayerSmoke : MonoBehaviour {
		    GameObject player;

		    void Start() {
		        player = GameObject.FindGameObjectWithTag("Player");
		    }

		    void Update() {
		        transform.position = player.transform.position;
		    }
		}
	}
}
