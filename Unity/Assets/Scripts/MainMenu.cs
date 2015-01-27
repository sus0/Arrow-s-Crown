using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class MainMenu : MonoBehaviour {

	public GUISkin mainMenuSkin;
	public Vector2 btStartLocation;
	public Vector2 btExitLocation;
	public Vector2 btCreditLocation;
	private GUIClasses.Location center = new GUIClasses.Location();
	private string btPlay = "Assets/Sprites/Menu/play_button.png";
	private string btExit = "Assets/Sprites/Menu/play_button.png";
	private string btCredit = "Assets/Sprites/Menu/credit_button.png";
	private GUIELementScale.ScreenScale screenScale = new GUIELementScale.ScreenScale(1920, 1080);

	// Use this for initialization
	void OnGUI () {
		GUI.skin = mainMenuSkin;
		GUI.matrix = screenScale.AdjustOnGUI();
		if(GUI.Button(new Rect(center.offset.x + btStartLocation.x, center.offset.y + btStartLocation.y, 437, 325), (Texture2D)Resources.LoadAssetAtPath(btPlay, typeof(Texture2D)),GUIStyle.none)){
			//Application.LoadLevel("MainScene");
		}
		if(GUI.Button(new Rect(center.offset.x + btCreditLocation.x, center.offset.y + btCreditLocation.y, 300, 200), (Texture2D)Resources.LoadAssetAtPath(btCredit, typeof(Texture2D)),GUIStyle.none)){
			//Application.LoadLevel("MainScene");
		}
		//if(GUI.Button(new Rect(center.offset.x + btExitLocation.x, center.offset.y + btExitLocation.y, 437, 325), (Texture2D)Resources.LoadAssetAtPath(btExit, typeof(Texture2D)), GUIStyle.none)){
		//	Application.Quit();
		//}
		GUI.matrix = Matrix4x4.identity;
	}
	
	// Update is called once per frame
	void Update () {
		center.updateLocation();
	}

}
