using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearAnxiety {
		public class CameraShake : MonoBehaviour {
			// Transform of the camera to shake. Grabs the gameObject's transform
			// if null.
			private Transform camTransform;

			// How long the object should shake for.
			public float ShakeDuration = 0f;

			// Amplitude of the shake. A larger value shakes the camera harder.
			private float shakeAmount = 0.3f;
			private float decreaseFactor = 1.0f;

			Vector3 originalPos;

			void Awake() {
				if (camTransform == null) {
					camTransform = GetComponent(typeof(Transform)) as Transform;
				}
			}

			void OnEnable() {
				originalPos = camTransform.localPosition;
			}

			void Update() {
				if (ShakeDuration > 0) {
					camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

					ShakeDuration -= Time.deltaTime * decreaseFactor;
				} else {
					ShakeDuration = 0f;
					camTransform.localPosition = originalPos;
				}
			}
		}
}