using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Handler : MonoBehaviour {

	// Use this for initialization
	private int score=0;
	private float time=180;
	private bool isdrillOn = false;

	public GameObject background;
	public GameObject Slime;
	public GameObject Warrior;
	public GameObject spawn;
	public GameObject slimes;
	public GameObject upDrill;
	public Text scoreText;
	public Text timeText;
	public GameObject clearPnl;
	public void drillBtnDown(){
		isdrillOn = true;
	}
	void checkClear(){
		if (score >= 5) {
			clearPnl.SetActive (true);
		}
	}
	void checkTouch(){
		for (int i = 0; i < Input.touchCount; ++i) { //touch check
			if (Input.GetTouch (i).phase == TouchPhase.Began && isdrillOn) {
				Instantiate (upDrill, Input.GetTouch (i).position, transform.rotation);
				/*RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.GetTouch (i).position), Vector2.zero);
				if (hit) {
					isdrillOn = false;
					Destroy (hit.collider.gameObject);
				}*/
			} else if (Input.GetTouch (i).phase == TouchPhase.Moved && isdrillOn) {
				upDrill.transform.position = Input.GetTouch (i).position;
			} else if (Input.GetTouch (i).phase == TouchPhase.Ended && isdrillOn) {
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.GetTouch (i).position), Vector2.zero);
				if (hit) {
					isdrillOn = false;
					Destroy (hit.collider.gameObject);
				}
			}
		}
	}
	void checkEndGame(){
		if (Input.GetKeyDown (KeyCode.Escape)) { //Quit game
			Application.Quit();
		}
	}
	void checkTime(){
		time -= Time.deltaTime;
		timeText.text = (int)time / 60 + ":";
		if ((int)time % 60 > 9) {
			timeText.text += (int)time % 60;
		} else {
			timeText.text += "0" + (int)time % 60;
		}
	}
	public void addScore(){
		score++;
		scoreText.text = score.ToString(); 
	}
	IEnumerator CreateSlime(){
		for (int i = 0; i < 5; i++) {
			float a = Random.Range (-1.0f, 1.0f);
			GameObject tmp = (GameObject)Instantiate (Slime, new Vector2 (spawn.transform.position.x+a, spawn.transform.position.y), this.transform.rotation);
			tmp.transform.SetParent (slimes.transform);
			tmp.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 10,ForceMode2D.Impulse);
			yield return new WaitForSeconds (3.0f);
		}
		yield return new WaitForSeconds (1.0f);
		Instantiate (Warrior, new Vector2 (spawn.transform.position.x, spawn.transform.position.y), this.transform.rotation);
	}

	void Start () {
		StartCoroutine (CreateSlime ());
	}
	// Update is called once per frame
	void Update () {
		checkTime ();
		checkEndGame ();
		checkTouch ();
		checkClear ();
	}

}
