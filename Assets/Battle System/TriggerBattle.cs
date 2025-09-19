using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBattle : MonoBehaviour
{

	public string sceneToLoad;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player")
		{
			Destroy(GameObject.Find("BadGuy"));
			Application.LoadLevel(sceneToLoad);
			//LoadBattleScreen ();
		}
	}

	void LoadBattleScreen()
	{
		GameController.control.inBattle = true;
		Destroy(GameObject.Find("BadGuy"));
		GameController.control.playerDead = true;
		Application.LoadLevel(sceneToLoad);
	}
}