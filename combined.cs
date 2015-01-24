using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	bool isWin; //input value from susie
	int playerHealth = 100;
	public string player = "player's health:";
	int enemyHealth = 100;
	public string enemy = "enemy's health:";
	bool moveFinish = false; // output value to susie
	protected Animator animPlayer;
	public GameObject monster;
	protected Animator animMonster;



	enum atkmethod { normalAttack, Magic };

	// Use this for initialization
	void Start () {
		monster = GameObject.Find ("monster");
		animPlayer = GetComponent <Animator> ();
		animMonster = monster.GetComponent<Animator> ();
	}

	void OnGUI() {
		GUI.Box(new Rect (10, 10, 150, 50), player+ playerHealth.ToString());
		GUI.Box (new Rect (500, 10 , 150, 50), enemy + enemyHealth.ToString ());
	}

	// Update is called once per frame
	void Update () {

		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo (0);
		whoAttack (isWin);
	
	}

	void whoAttack(bool isWin)
	{
		if (isWin){
			enemyHealth -= 10;
		//	playerAttack = true;
			if( Random.Range(0,1) == 0){
				//player normal attack animation
				animPlayer.Play("playerAttack");
				enemyHealth -= 10;
				StartCoroutine(wait (animPlayer));
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
				animMonster.Play ("monsterAttack");
				playerHealth -= 10;
				StartCoroutine (wait (animMonster));
				moveFinish = true;
			}
			else
			{
				//monster magic attack animation
				moveFinish = true; 
			}
		}
	}

	IEnumerator wait(Animator anim){
		yield return new WaitForSeconds(3.0f);
		anim.enabled = false;
		anim.enabled = true;
		anim.Play ("IDLE");
	}
}
	