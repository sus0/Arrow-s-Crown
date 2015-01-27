using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
[RequireComponent(typeof(CharacterLogic))]
public class mainGUI : MonoBehaviour {
	public Texture[] btTextures;
	public Vector2 btStartLocation;
	public Vector2 btStartSecond;
	public GUIClasses.Location center = new GUIClasses.Location();
	public float displayTime =0f;
	public float inputTime = 0f; 
	public float attackTime = 0f;
	public GameObject player;
	public Vector2 speechboxPos1;
	public Vector2 speechboxPos2;
	[HideInInspector]
	public string[] textureNames;
	[HideInInspector]
	public GameStatus.Status status = new GameStatus.Status();
	[HideInInspector]
	public GUIELementScale.ScreenScale screenScale = new GUIELementScale.ScreenScale(1920, 1080);

	private int numBtns = 1;
	private Texture[] tempTextures;
	private ArrayList playerInputs = new ArrayList ();
	private string speechbox1Path = "Assets/Sprites/speech_bubble2.png";
	private string speechbox2Path = "Assets/Sprites/speech_bubble.png";
	private string speechbox1Path_p = "Assets/Sprites/speech_bubble_p.png";
	private string speechbox2Path_p = "Assets/Sprites/speech_bubble2_p.png";
	private string gameOverPath = "Assets/Sprites/game_over.png";
	/////////////////////////////////////////// 
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
		// set GUI.matrix to adapt to different screen resolutionss
		GUI.matrix = screenScale.AdjustOnGUI();
		if (status.isDisplaying && !status.isPaused){
			if (numBtns > 5){
				GUI.DrawTexture(new Rect(center.offset.x + speechboxPos2.x, center.offset.y + speechboxPos2.y, 485, 155), (Texture2D)Resources.LoadAssetAtPath(speechbox2Path, typeof(Texture2D)), ScaleMode.ScaleToFit, true, 0f);	
			}
			GUI.DrawTexture(new Rect(center.offset.x + speechboxPos1.x, center.offset.y + speechboxPos1.y, 485, 180), (Texture2D)Resources.LoadAssetAtPath(speechbox1Path, typeof(Texture2D)), ScaleMode.ScaleToFit, true, 0f);	

			for(int i = 0; i < numBtns; ++i){
				if (i < 5){
					GUI.Button(new Rect(center.offset.x + btStartLocation.x + (i*75) , center.offset.y + btStartLocation.y, 70, 70), tempTextures[i], GUIStyle.none);
				}
				else {
					GUI.Button(new Rect(center.offset.x + btStartSecond.x + ((i-6)*75) , center.offset.y + btStartSecond.y, 70, 70), tempTextures[i], GUIStyle.none);
				}
			}
		}
		if (status.isListening && playerInputs.Count > 0) {
			if (numBtns > 5){
				GUI.DrawTexture(new Rect(center.offset.x + speechboxPos2.x, center.offset.y + speechboxPos2.y, 485, 155), (Texture2D)Resources.LoadAssetAtPath(speechbox2Path_p, typeof(Texture2D)), ScaleMode.ScaleToFit, true, 0f);	
			}
			GUI.DrawTexture(new Rect(center.offset.x + speechboxPos1.x, center.offset.y + speechboxPos1.y, 485, 175), (Texture2D)Resources.LoadAssetAtPath(speechbox1Path_p, typeof(Texture2D)), ScaleMode.ScaleToFit, true, 0f);	
			Texture2D loadedTexture;
			string loadedPath;
			for(int i = 0; i < playerInputs.Count; ++i){
				if(i < numBtns){
					if (playerInputs[i].Equals(textureNames[i])){
						loadedPath = "Assets/Sprites/UserInputs/" + playerInputs[i]+".png";
					}
					else {
						loadedPath = "Assets/Sprites/UserInputs/wrong.png";
						status.isWinner = false;
					}
					loadedTexture = (Texture2D)Resources.LoadAssetAtPath(loadedPath, typeof(Texture2D));
					if (loadedTexture) {
						if (i < 5){
							GUI.Button(new Rect(center.offset.x + btStartLocation.x + (i*75) , center.offset.y + btStartLocation.y, 70, 70), loadedTexture, GUIStyle.none);
						}
						else {
							GUI.Button(new Rect(center.offset.x + btStartSecond.x + ((i-6)*75) , center.offset.y + btStartSecond.y, 70, 70), loadedTexture, GUIStyle.none);
						}
					}
				}
			}	
		}

		if(status.isOver_Lose){
			GUI.matrix = Matrix4x4.identity;
			GUI.DrawTexture(new Rect(0, 0, Screen.width,Screen.height), (Texture2D)Resources.LoadAssetAtPath(gameOverPath, typeof(Texture2D)), ScaleMode.ScaleToFit, true, 0f);	
		}

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
		if (player.GetComponent<CharacterLogic>().playerHealth <= 0) {
			status.isOver_Lose = true;	
			status.isPaused = true;
		}
	}

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
		status.isDisplaying = true;
		yield return new WaitForSeconds(displayTime);
		status.isDisplaying = false;
		StartCoroutine(DetectInputs());
	}

	private IEnumerator DetectInputs(){
		status.isListening = true;
		yield return new WaitForSeconds(inputTime);
		status.isListening = false;
		CheckWinner();
		UpdateBtnNum();
		StartCoroutine(OnAttack());
	}

	private void CheckWinner(){
		if(!status.isListening){
			if(playerInputs.Count < numBtns) {
				status.isWinner = false;
				return;
			}
		//	for (int i = 0; i < numBtns; ++i){
		//		if(playerInputs[i].ToString() != textureNames[i]){
		//			status.isWinner = false;
		//			return;
		//		}
		//	}
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

}
