using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class MainMenu : MonoBehaviour {
	public void StartButtonOnClick(){
		Application.LoadLevel("MainScene");
	}
	public void CreditButtonOnClick(){
		Application.LoadLevel("CreditsScreen");
	}

	public void BackButtonOnClick(){
		Application.LoadLevel("MainMenu");
	}
	public void ExitButtonOnClick(){
		Application.Quit();
	}

	public void TextColorChangeToWhite() {
		GetComponent<Text>().color = Color.white;
	}
	public void TextColorChangeToRed() {
		GetComponent<Text>().color = new Color32(129, 9, 9, 255);
	}
	public void TextColorChangeToYellow() {
		GetComponent<Text>().color = new Color32(247, 213, 19, 255);
	}
}
