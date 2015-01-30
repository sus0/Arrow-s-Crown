using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class MainMenu : MonoBehaviour {
	public void StartButtonOnClick(){
		Application.LoadLevel("MainScene");
	}
	public void CreditButtonOnClick(){
		Application.LoadLevel("CreditsScreen");
	}



}
