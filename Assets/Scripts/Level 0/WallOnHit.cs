using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NearAnxiety {
    namespace Level0 {
        public class WallOnHit : MonoBehaviour {
            void OnTriggerEnter2D(Collider2D col) {
                if (col.gameObject.name == "Player Bullet") {
                    Destroy(col.gameObject);
                }
            }
        }
    }
}