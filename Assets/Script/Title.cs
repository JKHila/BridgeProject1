using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Title : MonoBehaviour {
	Image fade;
	// Use this for initialization
	void Start () {
		//StartCoroutine (fadeIn ());

	}
	IEnumerator fadeIn(){
		while (fade.color.a < 255) {
			yield return new WaitForSeconds (0.1f);
		}
	}
	// Update is called once per frame
	void Update () {
	}
	public void SelectStage(){
		SceneManager.LoadScene ("main");
	}
	public void SelectChapter(){
		SceneManager.LoadScene (2,LoadSceneMode.Single);
	}
	public void GameStart(){
		SceneManager.LoadScene (1,LoadSceneMode.Single);
	}
}
