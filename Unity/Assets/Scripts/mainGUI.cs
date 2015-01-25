using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
[RequireComponent(typeof(CharacterLogic))]
public class mainGUI : MonoBehaviour {
	public GUISkin backgroundSkin;
	public Texture[] btTextures;
	public Vector2 btStartLocation;
	public Vector2 btPauseGameLocation;
	public GUIClasses.Location center = new GUIClasses.Location();
	//public GameObject player;
	public string[] textureNames;
	//public bool arrayReadyToSend;
	public float displayTime =0f;
	public float inputTime = 0f; 
	public float attackTime = 0f;
	public bool paused;
	public GameObject player;

	private int numBtns = 1;
	private Texture[] tempTextures;
	private ArrayList playerInputs = new ArrayList ();
	private GameStatus.Status status = new GameStatus.Status();
	//private bool isTest = true;


	/////////////////////////////////////////// 
	// Update is called once per frame
	void Start(){
		GameLoopEntry();
	}

	private void InitializeMainGUI(){
		status.onInitialized();
		playerInputs.Clear();
		tempTextures = null;
		textureNames = null;
		Resources.UnloadUnusedAssets();
		RandomTexturesGenerator();
		SetTextureNames();
	}
	void OnGUI(){
		// setting up the background
		GUI.skin = backgroundSkin;
		//aa ();
		if (status.isDisplaying){
			for(int i = 0; i < numBtns; ++i){
				if(GUI.Button(new Rect(center.offset.x + btStartLocation.x + (i*75) , center.offset.y + btStartLocation.y, 70, 70), tempTextures[i], GUIStyle.none)){
				}
			}
		}
		if (paused)
			GUI.Label(new Rect(100, 100, 50, 30), "Game paused");
	}

	void Update () {
		center.updateLocation(); //in case the player is stretching the window
		if (status.isListening && playerInputs.Count <= numBtns){
			if (Input.GetKeyDown ("up"))
				playerInputs.Add ("up");
			if (Input.GetKeyDown ("down"))
				playerInputs.Add ("down");
			if (Input.GetKeyDown ("left"))
				playerInputs.Add ("left");
			if (Input.GetKeyDown ("right"))
				playerInputs.Add ("right");
			if (Input.GetKeyDown ("1"))
				playerInputs.Add ("1");
			if (Input.GetKeyDown ("2"))
				playerInputs.Add ("2");
			if (Input.GetKeyDown ("3"))
				playerInputs.Add ("3");
			if (Input.GetKeyDown ("4"))
				playerInputs.Add ("4");
			if (Input.GetKeyDown ("5"))
				playerInputs.Add ("5");
			if (Input.GetKeyDown ("6"))
				playerInputs.Add ("6");
			if (Input.GetKeyDown ("7"))
				playerInputs.Add ("7");
			if (Input.GetKeyDown ("8"))
				playerInputs.Add ("8");
			if (Input.GetKeyDown ("9"))
				playerInputs.Add ("9");
			
		}
		//if(ready1){
		//	StartCoroutine(OnDisplaying());
		//}
	}
	private bool ready1;
	private bool ready2;
	private void GameLoopEntry(){
		InitializeMainGUI();
		StartCoroutine(OnDisplaying());
		//CheckWinner();
		//UpdateBtnNum();
		//OnAttack();
	}
	private void UpdateBtnNum(){
		if (status.isWinner){
			numBtns ++;
		}
		else if (numBtns > 1) {
			numBtns --;
		}
	}
	private IEnumerator OnDisplaying(){
		//ready1 = false;
		status.isDisplaying = true;
		yield return new WaitForSeconds(displayTime);
		//Invoke("DisableDisplay", displayTime);
		status.isDisplaying = false;
		StartCoroutine(DetectInputs());
		//ready1 = true;
	}
	//private void DisableDisplay(){
	//	status.isDisplaying = false;
	//}
	private IEnumerator DetectInputs(){
		status.isListening = true;
		yield return new WaitForSeconds(inputTime);
			//Invoke("DisableInputs", inputTime);
		DisableInputs();	
		CheckWinner();
		UpdateBtnNum();
		StartCoroutine(OnAttack());
	}
	private void DisableInputs(){
		status.isListening = false;
	}
	private void CheckWinner(){
		if(!status.isListening){
			if(playerInputs.Count < numBtns) {
				status.isWinner = false;
				return;
			}
			for (int i = 0; i < numBtns; ++i){
				if(playerInputs[i].ToString() != textureNames[i]){
					status.isWinner = false;
					return;
				}
			}
		}
	}
	private IEnumerator OnAttack(){
		// Attack Animations here
		player.GetComponent<CharacterLogic>().whoAttack(status.isWinner);
		yield return new WaitForSeconds(attackTime);
		GameLoopEntry();
	}


	//generate random array and push into textureNames
	private void RandomTexturesGenerator(){
		tempTextures = new Texture[numBtns];
		int randomNum;
		for(int i = 0; i < numBtns; ++i){
			randomNum = UnityEngine.Random.Range(0, btTextures.GetLength(0));
			tempTextures[i] = btTextures[randomNum];
		}
	}
	private void SetTextureNames(){
		textureNames = new string[numBtns]; 
		for(int i = 0; i < numBtns; ++i){
				textureNames[i] = tempTextures[i].name;
		}
	}


	void OnApplicationPause(bool pauseStatus) {
		paused = pauseStatus;
	}

}
