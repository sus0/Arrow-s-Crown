using UnityEngine;
using System.Collections;

public class health: MonoBehaviour {
	protected Animator anim;
	int playerHealth = 100;
	public string player = "player's health:";
	int enemyHealth = 100;
	public string enemy = "enemy's health:";


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	void OnGUI() {
		GUI.Box(new Rect (10, 10, 150, 50), player+ playerHealth.ToString());
		GUI.Box (new Rect (500, 10 , 150, 50), enemy + enemyHealth.ToString ());
	}
	
	// Update is called once per framer4
	void Update () {
		if (Input.GetKeyDown ("k")) {
			anim.Play("playerAttack");
			playerHealth -= 10;
			StartCoroutine(wait ());
		}
		if (Input.GetKeyDown ("l"))
				enemyHealth -= 10;

		}

	IEnumerator wait(){
				yield return new WaitForSeconds(3.0f);
				anim.enabled = false;
		}
}