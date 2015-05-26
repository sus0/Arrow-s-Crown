using UnityEngine;
using System.Collections;

public class CharacterLogic : MonoBehaviour {
	//bool? isWin; //input value from susie
	public int playerHealth_initial = 100;
	public int enemyHealth_initial = 100;
	public string player = "player's health:";
	public string enemy = "enemy's health:";
	bool moveFinish = false; // output value to susie
	protected Animator animPlayer;
	public GameObject monster;
	protected Animator animMonster;

	[HideInInspector]
	public int playerHealth;
	[HideInInspector]
	public int enemyHealth;
	
	
	enum atkmethod { normalAttack, Magic };
	
	// Use this for initialization
	void Start () {
		playerHealth = playerHealth_initial;
		enemyHealth = enemyHealth_initial;
		monster = GameObject.Find ("Monster");
		animPlayer = GetComponent <Animator> ();
		animMonster = monster.GetComponent<Animator> ();
	}
	
	void OnGUI() {
	//	GUI.Box(new Rect (10, 10, 150, 50), player+ playerHealth.ToString());
	//	GUI.Box (new Rect (500, 10 , 150, 50), enemy + enemyHealth.ToString ());
	}
	
	// Update is called once per frame
	void Update () {
	
		
	}
	
	public void whoAttack(bool isWin)
	{
		if (isWin==true){
			//	playerAttack = true;
			if( Random.Range(0,1) == 0){
				//player normal attack animation
				animPlayer.Play("playerAttack");
				enemyHealth -= 10;
				StartCoroutine(wait (animPlayer));
				moveFinish = true;
			}
			else 
			{
				//player magic attack animation
				moveFinish = true;
			}
		}
		else if(isWin == false)
		{
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