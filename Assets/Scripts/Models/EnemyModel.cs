using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace NearAnxiety {
    namespace Models {
		[Serializable]
		public class EnemyModel {
		    public string Animation;
			public int Level;
			public string Text = "Text";
			public float X = 50; // percentage of screen
		    public float Y = 50; // percentage of screen
		    public float Delay = 0;
		    public float Speed = 1;
		    public int HP = 10;
		    public string Bullet = "single";
		}
	}
}
