using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NearAnxiety {
	namespace Models {
		[Serializable]
		public class IntroModel {
			public int Wave;
			public string Text = "Text";
			public string TextId = "Text";
			public float X = 50; // percentage of screen
			public float Y = 50; // percentage of screen
			public float Delay = 0;
			public int Size = 10;
		}
	}
}
