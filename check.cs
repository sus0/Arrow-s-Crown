using UnityEngine;
using System.Collections;

public class playerStatus
{
	public bool win;
	public bool lose;
	public bool inProgress;
}

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization




	// Update is called once per frame
	public playerStatus check (string[] genStr) {
		playerStatus player = new playerStatus ();
		ArrayList playerPress = new ArrayList ();
		int buttonlength = genStr.Length;
		player.win = false;
		player.lose = false;
		player.inProgress = true;
		for (int n=0 ; n < buttonlength; n++) // recording down player's input 
		{
						while(!Input.anyKeyDown){	}	
						if (Input.GetKeyDown ("up"))
								playerPress.Add ("up");
						if (Input.GetKeyDown ("down"))
								playerPress.Add ("down");
						if (Input.GetKeyDown ("left"))
								playerPress.Add ("left");
						if (Input.GetKeyDown ("right"))
								playerPress.Add ("right");
						if (Input.GetKeyDown ("1"))
								playerPress.Add ("1");
						if (Input.GetKeyDown ("2"))
								playerPress.Add ("2");
						if (Input.GetKeyDown ("3"))
								playerPress.Add ("3");
						if (Input.GetKeyDown ("4"))
								playerPress.Add ("4");
						if (Input.GetKeyDown ("5"))
								playerPress.Add ("5");
						if (Input.GetKeyDown ("6"))
								playerPress.Add ("6");
						if (Input.GetKeyDown ("2"))
								playerPress.Add ("2");
						if (Input.GetKeyDown ("3"))
								playerPress.Add ("3");
						if (Input.GetKeyDown ("4"))
								playerPress.Add ("4");
						if (Input.GetKeyDown ("5"))
								playerPress.Add ("5");
						if (Input.GetKeyDown ("6"))
								playerPress.Add ("6");
						if (Input.GetKeyDown ("7"))
								playerPress.Add ("7");
						if (Input.GetKeyDown ("8"))
								playerPress.Add ("8");
						if (Input.GetKeyDown ("9"))
								playerPress.Add ("9");
		}

		for (int n=0; n < buttonlength; n++) { // compare player's input with the generatored input	
				if (playerPress [n] != genStr [n]) {
				player.lose = true;
				player.inProgress = false;
				goto right;
				}
			}			
		player.win = true;
		player.inProgress = false;
	right:
		return player;
	}


}
