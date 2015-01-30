using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GUIElements : MonoBehaviour {

	public Vector2 btPauseGameLocation;
	public GUISkin interactiveBtn;

	private mainGUI mainGUIScript;
	private string pauseBtnPath = "Assets/Sprites/pause.png";
	private string resumeBtnPath = "Assets/Sprites/resume.png";
	private string restartBtnPath = "Assets/Sprites/restart.png";
	// Use this for initialization
	void Start () {
		mainGUIScript = GetComponent<mainGUI>();
	}

	void Update(){
		if(mainGUIScript.status.isPaused == false){
			Time.timeScale = 1;
		}
		else {
			Time.timeScale = 0;
		}
		if(Input.GetKeyDown(KeyCode.Q)){
			if(mainGUIScript.status.isPaused == true){
				mainGUIScript.status.isPaused = false;
			}
			else {
				mainGUIScript.status.isPaused = true;
			}
		}
	}

	void OnGUI(){
		GUI.matrix =mainGUIScript.screenScale.AdjustOnGUI();
		if(!mainGUIScript.status.isPaused){
			if (GUI.Button(new Rect(mainGUIScript.center.offset.x + btPauseGameLocation.x , mainGUIScript.center.offset.y + btPauseGameLocation.y, 70, 70), (Texture2D)Resources.LoadAssetAtPath(pauseBtnPath, typeof(Texture2D)) , interactiveBtn.button)){
				mainGUIScript.status.isPaused = true;
			}
		}
			if (GUI.Button(new Rect(mainGUIScript.center.offset.x + btPauseGameLocation.x + 75 , mainGUIScript.center.offset.y + btPauseGameLocation.y, 70, 70), (Texture2D)Resources.LoadAssetAtPath(resumeBtnPath, typeof(Texture2D)) , interactiveBtn.button)){
				mainGUIScript.status.isPaused = false;
			}
			if (GUI.Button(new Rect(mainGUIScript.center.offset.x + btPauseGameLocation.x + 150 , mainGUIScript.center.offset.y + btPauseGameLocation.y, 70, 70), (Texture2D)Resources.LoadAssetAtPath(restartBtnPath, typeof(Texture2D)) , interactiveBtn.button)){
				Application.LoadLevel(2);
				//mainGUIScript.GameLoopEntry();
			}



	}

	public void PauseButtonOnClick(){
		mainGUIScript.status.isPaused = true;
	}

	public void ResumeButtonOnClick(){
		mainGUIScript.status.isPaused = true;
	}
}
