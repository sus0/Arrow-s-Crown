using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class mainGUI : MonoBehaviour {
	public GUISkin backgroundSkin;
	public Texture[] btTextures;
// vector2 for button locations
	public Vector2 btStartLocation;
	public Vector2 btPauseGameLocation;
	public GUIClasses.Location center = new GUIClasses.Location();
	public string[] textureNames;

	private int numBtns = 3;
	private Texture[] tempTextures;
	private bool isTest = true;
	/////////////////////////////////////////// 
	// Update is called once per frame
	void Update () {
		center.updateLocation(); //in case the player is skretching the window
	}
	void OnGUI(){
		// setting up the background
		GUI.skin = backgroundSkin;

		if(isTest) {
			isTest = false;
			RandomTexturesGenerator();
		}
		for(int i = 0; i < numBtns; ++i){
			if(GUI.Button(new Rect(center.offset.x + btStartLocation.x + (i*50) , center.offset.y + btStartLocation.y, 50, 50), tempTextures[i])){
				textureNames[i] = tempTextures[i].name;
				//Debug.Break();
			}
		}
		

		// if the game state is in progress
				//traverse through the texture and render them on screen


		// if the game state is win
			// numBtns += 1
			// generate a new array
			// set the game state to be in progress

		// if the game state loses
			// numBtns -= 1
			// generate a new array
		    // set the game state to be in progress

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
		textureNames = new string[numBtns]; 
		int randomNum;
		for(int i = 0; i < numBtns; ++i){
			randomNum = Random.Range(0, btTextures.GetLength(0));
			tempTextures[i] = btTextures[randomNum];
		}
	}


}
