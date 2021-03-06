﻿using UnityEngine;
using System.Collections;

public class GameStatus : MonoBehaviour {

	[System.Serializable]
	public class Status{
		[HideInInspector]
		public bool isWinner;
		[HideInInspector]
		public bool isListening;
		[HideInInspector]
		public bool isDisplaying;
		[HideInInspector]
		public bool isAttacking;
		[HideInInspector]
		public bool isPaused;
		[HideInInspector]
		public bool isOver_Lose;


		public void onInitialized(){
			isWinner = true;
			isListening= false;
			isDisplaying = false;
			isAttacking = false;
			isPaused = false;
			isOver_Lose = false;
		}
	};
}
