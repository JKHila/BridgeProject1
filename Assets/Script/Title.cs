﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Title : MonoBehaviour {
	public AudioClip btnSE;
	public Image fade;
	public Image cutScene;
	public Text cutText;
	public Button fastBtn;

	public GameObject optPanel;
	public GameObject creditPanel;
	public GameObject pausePanel;
	public GameObject cutPanel;
	public GameObject collectPanel;

	public Button[] On_Off = new Button[3];
	public Sprite[] On_Off_Sprite = new Sprite[2];
	public Sprite[] cutScene_Sprite = new Sprite[2];
	// Use this for initialization
	void Start () {
		Debug.Log (PlayerPrefs.GetInt ("clearedStage"));
        fade = GameObject.Find("Fade").GetComponent<Image>();
        fade.color = new Color(0,0,0,255);
        StartCoroutine ("fadein");
		if(SceneManager.GetActiveScene().name == "Title")
			StartCoroutine (startCutScene ());
	}
	void checkEndGame()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{ //Quit game
			Application.Quit();
		}
	}
	//cutscene
	IEnumerator startCutScene(){
		yield return new WaitForSeconds (3.0f);
		cutScene.CrossFadeColor (new Color (0, 0, 0,0), 0.5f, true, true);
		yield return new WaitForSeconds (0.5f);
		cutScene.sprite = cutScene_Sprite [0];
		cutText.text = "빨강머리 용사는 슬라임을 잡아 강해지기 위해 \r슬라임 마을을 습격한다! \r";
		cutText.GetComponent<RectTransform> ().localPosition = new Vector2 (-165, -68);
		cutScene.CrossFadeColor (new Color (255, 255, 255), 1.0f, false, true);

		yield return new WaitForSeconds (3.0f);
		cutScene.CrossFadeColor (new Color (0, 0, 0,0), 0.5f, true, true);
		yield return new WaitForSeconds (0.5f);
		cutScene.sprite = cutScene_Sprite [1];
		cutText.text = "라이벌인 빨간머리 용사가 더 이상 강해지지못하게 \n슬라임들을 구해라! ";
		cutText.GetComponent<RectTransform> ().localPosition = new Vector2 (230	, -120);
		cutScene.CrossFadeColor (new Color (255, 255, 255), 0.5f, false, true);

		yield return new WaitForSeconds (3.0f);
		cutScene.CrossFadeColor (new Color (0, 0, 0,0), 0.5f, true, true);
		yield return new WaitForSeconds (0.7f);
		cutPanel.SetActive (false);
	}
	//fade in/out
	IEnumerator fadein(){
        fade.CrossFadeAlpha(0.0f, 1, true);
        yield return new WaitForSeconds (1.0f);
        fade.canvasRenderer.SetAlpha(0.0f);
        fade.gameObject.SetActive(false);
	}
    IEnumerator fadeOut()
    {
        fade.gameObject.SetActive(true);
        fade.CrossFadeAlpha(255, 1.0f, false);
        yield return new WaitForSeconds(1.0f);
    }
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("isNotFirst") == 1 && SceneManager.GetActiveScene().name == "Title") {
			if (Input.GetMouseButtonDown (0)) {
				StopCoroutine (startCutScene ());
				cutPanel.SetActive (false);
			}
		}
		checkEndGame();
		debugging ();
	}
	public void allClearBtnDown(){
		PlayerPrefs.SetInt("clearedStage",8);
		GameObject.Find("Main Camera").GetComponent<StageSelete>().showStage();
	}
	void debugging()
	{
		if (Input.GetKeyDown(KeyCode.Delete))
		{
			PlayerPrefs.DeleteAll();
			Debug.Log ("deleteAll");
			PlayerPrefs.SetInt("clearedStage",-1);
		}
	}//title btn
	public void titleCloseBtnDown(){
		AudioSource.PlayClipAtPoint(btnSE,transform.position);
		creditPanel.SetActive (false);
		optPanel.SetActive (false);
		collectPanel.SetActive(false);
	}
	public void optBtnDown(){
		AudioSource.PlayClipAtPoint(btnSE,transform.position);
		optPanel.SetActive (true);
	}
	public void collBtnDown(){
		AudioSource.PlayClipAtPoint(btnSE,transform.position);
		collectPanel.SetActive(true);
	}
	public void titleOnOffBtnDown(int n){
		if (On_Off [n].image.sprite.name == "option_off")
			On_Off [n].image.sprite = On_Off_Sprite [0];
		else
			On_Off [n].image.sprite = On_Off_Sprite [1];
	}
	public void creditBtnDown(){
		AudioSource.PlayClipAtPoint(btnSE,transform.position);
		creditPanel.SetActive (true);
		optPanel.SetActive (false);
	}
	//in stage Btn
    public void fastBtnDown()
    {
		AudioSource.PlayClipAtPoint(btnSE,transform.position);
        if(Time.timeScale < 2)
            Time.timeScale = 2;
        else
            Time.timeScale = 1;
    }
	public void pausBtnDown(){
		AudioSource.PlayClipAtPoint(btnSE,transform.position);
		pausePanel.SetActive (true);
		Time.timeScale = 0;
	}
	public void ContinueBtn(){
		AudioSource.PlayClipAtPoint(btnSE,transform.position);
		pausePanel.SetActive (false);
		Time.timeScale = 1;
	}
	//menu btn
	public void nextBtnDown(){
		AudioSource.PlayClipAtPoint(btnSE,transform.position);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
	}
	public void menuBtnDown(){
		AudioSource.PlayClipAtPoint(btnSE,transform.position);
		SceneManager.LoadScene (2);
	}
	public void replayBtnDown(){
		AudioSource.PlayClipAtPoint(btnSE,transform.position);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void SelectStage(int n){
		AudioSource.PlayClipAtPoint(btnSE,transform.position);
		userData.curStageNum = n;
		SceneManager.LoadScene (3+n);
	}
	public void SelectChapter(){
		AudioSource.PlayClipAtPoint(btnSE,transform.position);
		SceneManager.LoadScene (2,LoadSceneMode.Single);
	}
	public void GameStart(){
        //StartCoroutine(fadeOut());
		AudioSource.PlayClipAtPoint(btnSE,transform.position);
        SceneManager.LoadScene (2,LoadSceneMode.Single);
       
	}
}
