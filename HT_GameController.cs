using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HT_GameController : MonoBehaviour {
	
	public Camera cam;
	public GameObject[] balls;
    public GameObject[] jumpscares;
    public float timeLeft;
	public Text timerText;
	public GameObject gameOverText;
	public GameObject restartButton;
	public GameObject splashScreen;
	public GameObject startButton;
    public GameObject ExitButton;
	public HT_HatController hatController;
    //public GameObject hat;
	
	private float maxWidth;
	private bool counting;
	
	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
        //hat.SetActive(false);
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float ballWidth = balls[0].GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - ballWidth;
		timerText.text = "TIME LEFT:\n" + Mathf.RoundToInt (timeLeft);
	}

	void FixedUpdate () {
		if (counting) {
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				timeLeft = 0;
			}
			timerText.text = "TIME LEFT:\n" + Mathf.RoundToInt (timeLeft);
		}
	}

	public void StartGame () {
		splashScreen.SetActive (false);
		startButton.SetActive (false);
        ExitButton.SetActive(false);
        //hat.SetActive(true);
		hatController.ToggleControl (true);
		StartCoroutine (Spawn ());
        StartCoroutine(Jumpscares());
	}


	public IEnumerator Spawn () {
		yield return new WaitForSeconds (2.0f);
		counting = true;

		while (timeLeft > 0) {
			GameObject ball = balls [Random.Range (0, balls.Length)];

			Vector3 spawnPosition = new Vector3 (
				transform.position.x + Random.Range (-maxWidth, maxWidth), 
				transform.position.y, 
				0.0f
			);

			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (ball, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (Random.Range (1.0f, 2.0f));
		}

		yield return new WaitForSeconds (1.0f);
		gameOverText.SetActive (true);
		yield return new WaitForSeconds (2.0f);
		restartButton.SetActive (true);
        ExitButton.SetActive(true);
        StopCoroutine(Jumpscares());
        //hat.SetActive(false);
    }

    public IEnumerator Jumpscares()
    {
        while (true)
        {
            int i = Random.Range(0, 4);
            yield return new WaitForSeconds(15 + Random.Range(0, 10));
            jumpscares[i].SetActive(true);
            yield return new WaitForSeconds(2);
            jumpscares[i].SetActive(false);

        }
    }
}
