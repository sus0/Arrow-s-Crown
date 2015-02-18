using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class MainMenu : MonoBehaviour {
	public Text text;
	void OnStart(){

	}
	public void StartButtonOnClick(){
		Application.LoadLevel("MainScene");
	}
	public void CreditButtonOnClick(){
		Application.LoadLevel("CreditsScreen");
	}

	public void BackButtonOnClick(){
		Application.LoadLevel("MainMenu");
	}

	public void TextColorChangeToWhite() {
		text.color = Color.white;
	}
	public void TextColorChangeToRed() {
		text.color = new Color32(129, 9, 9, 255);
	}
}
