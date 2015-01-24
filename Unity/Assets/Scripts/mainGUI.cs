using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
[RequireComponent(typeof(GameStatus))]
public class mainGUI : MonoBehaviour {
	public GUISkin backgroundSkin;
	public Texture[] btTextures;
	public Vector2 btStartLocation;
	public Vector2 btPauseGameLocation;
	public GUIClasses.Location center = new GUIClasses.Location();
	public GameObject player;
	public string[] textureNames;
	public bool arrayReadyToSend;


	private int numBtns = 1;
	private Texture[] tempTextures;
	//private bool isTest = true;


	/////////////////////////////////////////// 
	// Update is called once per frame
	void Start(){
		player = GameObject.Find("Player");
		arrayReadyToSend = false;
	}
	
	void Update () {
		center.updateLocation(); //in case the player is stretching the window
	}

	void aa(){
		print("*****************");
		print ("displaying" + player.GetComponent<GameStatus>().isDisplaying);
		print ("listening" +player.GetComponent<GameStatus>().isListening);
		print ("lost" + player.GetComponent<GameStatus>().isLose);
		print ("win" + player.GetComponent<GameStatus>().isWin);
	}
	void OnGUI(){
		// setting up the background
		GUI.skin = backgroundSkin;

		//if(isTest) {
		//	isTest = false;
		//	RandomTexturesGenerator();
		//	SetTextureNamesSize();
		//}
		aa ();
		if (player.GetComponent<GameStatus>().isDisplaying){
			for(int i = 0; i < numBtns; ++i){
				if(GUI.Button(new Rect(center.offset.x + btStartLocation.x + (i*50) , center.offset.y + btStartLocation.y, 50, 50), tempTextures[i])){
					textureNames[i] = tempTextures[i].name;
					//Debug.Break();
				}
			}
		}

		// if the game state is in progress
				//traverse through the texture and render them on screen

		if (player.GetComponent<GameStatus>().isWin){
			//Debug.Break();
			numBtns ++;
			//clear the array
			tempTextures = null;
			textureNames = null;
			Resources.UnloadUnusedAssets();
			// generate a new array
			RandomTexturesGenerator();
			SetTextureNamesSize();
			arrayReadyToSend = true;
			// set the game state to be in progress
			player.GetComponent<GameStatus>().SetDisplayingStatus();
			//Debug.Break();
		}

		if (player.GetComponent<GameStatus>().isLose){
			numBtns --;
			//clear the array
			tempTextures = null;
			textureNames = null;
			Resources.UnloadUnusedAssets();
			// generate a new array
			RandomTexturesGenerator();
			SetTextureNamesSize();
			arrayReadyToSend = true;
			// set the game state to be in progress
			player.GetComponent<GameStatus>().SetDisplayingStatus();
		}



		// update button location
		//if (GUI.Button(new Rect(center.offset.x + btStartServerLocation.x, center.offset.y + btStartServerLocation.y, 140, 50), "START SERVER")){

			// it wants to be a host
			//Application.LoadLevel("MainScene");
		//}
		//if (GUI.Button(new Rect(center.offset.x + btFindRoomsLocation.x, center.offset.y + btFindRoomsLocation.y, 140, 50), "FIND ROOMS")){
		//	isServer = false;
		//	isClient = true;
			// it wants to be a client
			
		//}

		///////////////////////////////////////
		/// Something for the main scene
		/// ///////////////////////////////////
		//if (GUI.Button(new Rect(center.offset.x + btExitGameLocation.x, center.offset.y + btExitGameLocation.y, 140, 50), "EXIT")){
		//	Application.Quit();
		//}
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
	private void SetTextureNamesSize(){
		textureNames = new string[numBtns]; 
	}


}
