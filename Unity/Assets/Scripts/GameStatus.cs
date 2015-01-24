using UnityEngine;
using System.Collections;

[RequireComponent(typeof(mainGUI))]
public class GameStatus : MonoBehaviour {
	[HideInInspector]
	public bool isWin;
	[HideInInspector]
	public bool isLose;
	//isInProgress
	[HideInInspector]
	public bool isListening;
	[HideInInspector]
	public bool isDisplaying;
	public float timeLapping = 3.0f;
	public GameObject ui;
	
	private ArrayList playerInputs = new ArrayList ();
	private string[] displayNames;
	private int sizeOfDisplays;


	void Start(){
		ui = GameObject.Find("Main GUI");
		isWin = true;
		isLose = false;
		isListening = false;
		isDisplaying = false;

	}

	// record player's input
	void Update() {
		//when not in progress, request the displayNames list from mainGui class
		if(isWin || isLose){
			if(ui.GetComponent<mainGUI>().arrayReadyToSend){
				//displayNames = ui.GetComponent<mainGUI>().textureNames;
				displayNames = null;
				Resources.UnloadUnusedAssets();
				displayNames = new string[ui.GetComponent<mainGUI>().textureNames.Length];
				ui.GetComponent<mainGUI>().textureNames.CopyTo(displayNames, 0);
				sizeOfDisplays = displayNames.Length;
				ui.GetComponent<mainGUI>().arrayReadyToSend = false;
			}
		}
		if(isDisplaying){
			Invoke("SetListeningStatus", timeLapping);
		}
		// if game in listeng && playerinputs.count < sizeOfDisplayNames
		if(isListening) {
			Invoke("SetWinOrLoseStatus", timeLapping);
			if(playerInputs.Count < sizeOfDisplays){
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
			else{
				SetWinOrLoseStatus();
			}
		}
	//else	if(playerInputs.Count == size){
	//		check(genStr);
	//	}

	}

	public void SetDisplayingStatus(){
		isLose = false;
		isWin = false;
		isListening = false;
		isDisplaying = true;
	}

	public void SetListeningStatus(){
		isLose = false;
		isWin = false;
		isListening = true;
		isDisplaying = false;
	}

	private void SetWinOrLoseStatus(){
		if(playerInputs.Count >= sizeOfDisplays){
			for (int i = 0; i < sizeOfDisplays; ++i){
				if (playerInputs[i].ToString() != displayNames[i]){
					SetLoseStatus();
					return;
				}
			}
			SetWinStatus();
			return;
		}
		SetLoseStatus();
	}

	private void SetWinStatus(){
		isLose = false;
		isWin = true;
		isListening = false;
		isDisplaying = false;
	}
	private void SetLoseStatus(){
		isLose = true;
		isWin = false;
		isListening = false;
		isDisplaying = false;
	}
	
	
	
	
}
