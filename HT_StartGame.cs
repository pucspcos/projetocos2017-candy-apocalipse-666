using UnityEngine;
using System.Collections;

public class HT_StartGame : MonoBehaviour {

	public HT_GameController gameController;

	public void newGame () {
		gameController.StartGame();
	}

    public void exitGame()
    {
        Application.Quit();
    }

}