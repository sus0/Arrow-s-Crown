using UnityEngine;
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


		public void onInitialized(){
			isWinner = true;
			isListening= false;
			isDisplaying = false;
			isAttacking = false;
		}
	};
}
