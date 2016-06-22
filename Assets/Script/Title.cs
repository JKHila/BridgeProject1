using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Title : MonoBehaviour {
	Image fade;
    public Button fastBtn;
	// Use this for initialization
	void Awake () {
        fade = GameObject.Find("Fade").GetComponent<Image>();
        fade.color = new Color(0, 0,0,255);
        fade.CrossFadeAlpha(0,1.0f,false);
        StartCoroutine (fadeIn ());

	}
	IEnumerator fadeIn(){
		while (fade.color.a < 255) {
			yield return new WaitForSeconds (0.1f);
            
		}
	}
	// Update is called once per frame
	void Update () {
	}
    public void fastBtnDown()
    {
        if(Time.timeScale < 2)
            Time.timeScale = 2;
        else
            Time.timeScale = 1;
      
    }
	public void nextBtnDown(){
		SceneManager.LoadScene (++userData.curStageNum+3);
	}
	public void menuBtnDown(){
		SceneManager.LoadScene (2);
	}
	public void replayBtnDown(){
		SceneManager.LoadScene (3+userData.curStageNum);
	}
	public void pausBtnDown(){
		if (Time.timeScale > 0)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}
	public void SelectStage(int n){
		userData.curStageNum = n;
		SceneManager.LoadScene (3+n);
	}
	public void SelectChapter(){
		SceneManager.LoadScene (2,LoadSceneMode.Single);
	}
	public void GameStart(){
		SceneManager.LoadScene (1,LoadSceneMode.Single);
	}
}
