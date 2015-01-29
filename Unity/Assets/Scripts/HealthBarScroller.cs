using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarScroller : MonoBehaviour {

	public Scrollbar pHealthBar;
	public Scrollbar mHealthBar;
	public GameObject player;

	private int pIniHealth;
	private int mIniHealth;
	private int pCurrHealth;
	private int mCurrHealth;

	public void Start(){
		pIniHealth = player.GetComponent<CharacterLogic>().playerHealth_initial;
		mIniHealth = player.GetComponent<CharacterLogic>().enemyHealth_initial;
		pCurrHealth = pIniHealth;
		mCurrHealth = mIniHealth;
	}

	// Use this for initialization
	public void Update(){
		pCurrHealth = player.GetComponent<CharacterLogic>().playerHealth;
		mCurrHealth= player.GetComponent<CharacterLogic>().enemyHealth;
		pHealthBar.size = (float)pCurrHealth/(float)pIniHealth;
		mHealthBar.size = (float)mCurrHealth/(float)mIniHealth;
	}
}
