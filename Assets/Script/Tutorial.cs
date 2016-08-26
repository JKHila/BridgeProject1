using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
	private float speed;

	public AudioClip btnSE;

	public static bool isDrillCo = false;
	public static bool isCushionCo;
	public static bool isCushionCo2;
	public static bool isWallCo;
	public static bool isJumpingCo;

	public Button fastBtn;
	public GameObject pingImg;
	public GameObject pingImg2;
	public RuntimeAnimatorController[] rac = new RuntimeAnimatorController[3];
	//public GameObject pingImg3;
	public GameObject talkImg;
	public GameObject slime;
	public Text slimeText;
	IEnumerator tuto(){
		Handler.isTuto = true;
		Handler.isPause = true;;

		talkImg.SetActive (true);
		yield return new WaitUntil (()=>Input.GetMouseButtonDown(0));
		AudioSource.PlayClipAtPoint(btnSE,transform.position);
		slimeText.text = "우리는 이 나무에서 한마리씩 나와!\n아이템을 사용해서 우리가 앞으로 갈 수 있게 해줘!";
		pingImg.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		yield return new WaitUntil (()=>Input.GetMouseButtonDown(0));
		AudioSource.PlayClipAtPoint(btnSE,transform.position);
		slimeText.text = "이 숫자는 아이템을 사용할 수 있는 총 횟수야!";
		pingImg.GetComponent<RectTransform> ().localPosition = new Vector2 (-356, -139);
		yield return new WaitForSeconds (0.5f);
		yield return new WaitUntil (()=>Input.GetMouseButtonDown(0));
		AudioSource.PlayClipAtPoint(btnSE,transform.position);
		Handler.isPause = false;
		StartCoroutine (spawnco ());
	}
	IEnumerator spawnco(){
		pingImg.SetActive (false);
		talkImg.SetActive (false);
		GameObject.Find ("Spawn").GetComponent<SlimeSpawn> ().enabled = true;
		yield return new WaitForSeconds (1.0f);
		StartCoroutine(drillco ());
	}	
	IEnumerator drillco(){
		isDrillCo = true;
		slime = GameObject.Find ("Slime(Clone)");
		pauseAction (true);
		pingImg2.SetActive (true);
		slimeText.text = "드릴 아이템을 사용하여 슬라임을 이동시켜줘! 드릴은 풀있는 땅에만 쓸 수 있어!";
		talkImg.SetActive (true);

		yield return new WaitUntil (() => !isDrillCo);
		pingImg2.SetActive (false);
		talkImg.SetActive (false);
		pauseAction (false);
		StartCoroutine (cushionco ());
	}
	IEnumerator cushionco(){
		yield return new WaitUntil (() => slime.transform.position.x > -0.5f);
		isCushionCo = true;
		pauseAction (true);
		pingImg2.GetComponent<RectTransform> ().localPosition = new Vector2 (-210, -200);
		pingImg2.GetComponent<Animator> ().runtimeAnimatorController = rac [1];
		pingImg2.SetActive (true);
		slimeText.text = "높은 곳에서 떨어지는 슬라임들은 베개 아이템을 사용해서 구해줘!";
		talkImg.SetActive (true);

		yield return new WaitUntil (() => !isCushionCo);
		pingImg2.SetActive (false);
		talkImg.SetActive (false);
		pauseAction (false);
		StartCoroutine (wallco ());
		//StartCoroutine (cushionco2 ());
	}
	IEnumerator cushionco2(){
		isCushionCo2 = true;
		pingImg2.GetComponent<RectTransform> ().localPosition = new Vector2 (100, 50);
		yield return new WaitUntil (() => !isCushionCo2);
		pingImg2.SetActive (false);
		talkImg.SetActive (false);
		pauseAction (false);
		StartCoroutine (wallco ());
	}
	IEnumerator wallco(){
		yield return new WaitUntil (() => slime.transform.position.x > 5.5);
		isWallCo = true;
		pauseAction (true);
		slimeText.text = "벽 아이템을 사용해서 슬라임의 방향을 바꿔줘!";
		pingImg2.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		pingImg2.GetComponent<Animator> ().runtimeAnimatorController = rac [3];
		pingImg2.SetActive (true);
		talkImg.SetActive (true);

		yield return new WaitUntil (() => !isWallCo);
		pingImg2.SetActive (false);
		talkImg.SetActive (false);
		pauseAction (false);
		StartCoroutine (jumpingco ());
	}
	IEnumerator jumpingco(){
		yield return new WaitUntil (() => slime.transform.position.x < 2.5f);
		isJumpingCo = true;
		pauseAction (true);
		slimeText.text = "점프대를 설치해서 슬라임이 떨어지지 않게  도와줘!";
		pingImg2.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		pingImg2.GetComponent<Animator> ().runtimeAnimatorController = rac [2];
		pingImg2.SetActive (true);
		talkImg.SetActive (true);

		yield return new WaitUntil (() => !isJumpingCo);
		pingImg2.SetActive (false);
		talkImg.SetActive (false);
		pauseAction (false);
		StartCoroutine (fastco ());
	}
	IEnumerator fastco(){
		yield return new WaitUntil (() => slime.transform.position.x < -6.5f);
		pauseAction (true);
		pingImg2.GetComponent<Button> ().enabled = true;


		fastBtn.GetComponent<Button> ().interactable = true;
		slimeText.text = "빨리 감기 기능을 사용하면 슬라임의 속도가 빨라져!";

		pingImg2.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		pingImg2.GetComponent<RectTransform> ().localPosition = new Vector2 (50, -200);
		pingImg2.GetComponent<Animator> ().runtimeAnimatorController = rac [0];
		pingImg2.SetActive (true);
		talkImg.SetActive (true);

		yield return new WaitUntil (() => Time.timeScale > 1);
		pingImg2.SetActive (false);
		talkImg.SetActive (false);
		pauseAction (false);
	}
		
	void pauseAction(bool bo){
		Handler.isPause = bo;
		if (bo) {
			speed = slime.GetComponent<Moving> ().speed;
			slime.GetComponent<Moving> ().speed = 0;
			slime.GetComponent<Slime> ().StopCoroutine ("moveAction");
		} else {
			slime.GetComponent<Moving> ().speed = speed;
			slime.GetComponent<Slime> ().StartCoroutine ("moveAction");
		}
	}
	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene ().name == "ch1 Tutorial") {
			StartCoroutine (tuto ());
		}else if (PlayerPrefs.GetInt("isNotFirst") == 0){
			PlayerPrefs.SetInt ("clearedStage", -1);
            pingImg.SetActive(true);
        } 
    }
	
	// Update is called once per frame
	void Update () {
		
    }
}
