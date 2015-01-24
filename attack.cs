using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {
	protected Animator animator;
	bool isWin; //input value from susie
	int playerHealth = 100;
	public string player = "player's health:";
	int enemyHealth = 100;
	public string enemy = "enemy's health:";
//	bool? playerAttack = null; // output value to monster and player
	bool moveFinish = false; // output value to susie




	enum atkmethod { normalAttack, Magic };

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	void OnGUI() {
		GUI.Box(new Rect (10, 10, 150, 50), player+ playerHealth.ToString());
		GUI.Box (new Rect (500, 10 , 150, 50), enemy + enemyHealth.ToString ());
	}

	// Update is called once per frame
	void Update () {

		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo (0);
	
	}

	void whoAttack(bool isWin)
	{
		if (isWin){
			enemyHealth -= 10;
		//	playerAttack = true;
			if( Random.Range(0,1) == 0){
				//player normal attack animation
				moveFinish =true;
			}
			else
			{
				//player magic attack animation
				moveFinish = true;
			}
		}
		else
		{
			playerHealth -= 10;
		//	playerAttack = false;
			if( Random.Range(0,1) == 0){
				//monster normal attack animation
				moveFinish = true;
			}
			else
			{
				//monster magic attack animation
				moveFinish = true; 
			}
		}
	}
}
	