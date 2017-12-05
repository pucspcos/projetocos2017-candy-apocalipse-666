using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HT_Restart : MonoBehaviour {

	public void OnMouseDown () {
        SceneManager.LoadScene("Hat Trick");
	}
}
