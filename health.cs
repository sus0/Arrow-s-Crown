using UnityEngine;
using System.Collections;

public class health: MonoBehaviour {
	protected Animator animPlayer;
	public GameObject monster;
	protected Animator animMonster;
	int playerHealth = 100;
	public string player = "player's health:";
	int enemyHealth = 100;
	public string enemy = "enemy's health:";


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
	
	// Update is called once per framer4
	void Update () {
		if (Input.GetKeyDown ("k")) {
			animPlayer.Play("playerAttack");
			enemyHealth -= 10;
			StartCoroutine(wait (animPlayer));
		}

		if (Input.GetKeyDown ("l")) {
						animMonster.Play ("monsterAttack");
						playerHealth -= 10;
						StartCoroutine (wait (animMonster));
				}
	
	}

	IEnumerator wait(Animator anim){
		yield return new WaitForSeconds(3.0f);
		anim.enabled = false;
		anim.enabled = true;
		anim.Play ("IDLE");
	}
}